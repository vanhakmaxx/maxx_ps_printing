using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using maxx_pos.Services;
using maxx_pos.Helpers;
using Newtonsoft.Json.Linq;
using System.Data;

namespace maxx_pos
{
    public partial class FRMMAIN : Form
    {

        private int printIndex = 0;
        private List<DataGridViewRow> printRows = new List<DataGridViewRow>();

        //public string url = "https://payroll.beautysilkscreen.com.kh/api-hcm/v1/get-employee-payroll";
        //public string url = "https://dev-bsl.maxx4business.com/api-hcm/v1/get-employee-payroll";
        public string token = "";
        public string url = "";
        public List<string> payslipUrls = new List<string>();
        public string printerName;

        private ApiService apiService;
        private DataLoaderService dataLoader;
        private PdfService pdfService;
        private DataSet ds = new DataSet();

        public FRMMAIN()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\maxx_configuration.json";
            //cboPayslipOption.SelectedIndex = 1;
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                dynamic config = JObject.Parse(readText);
                token = config.token.ToString();
                url = config.cloud_url.ToString();
                url = url + "/get-employee-payroll-new";
            }
            InitializeComponent();
            apiService = new ApiService(token);
            dataLoader = new DataLoaderService(token);
            pdfService = new PdfService(apiService);
        }
        private async void FRMMAIN_Shown(object sender, EventArgs e)
        {
            InitializeComboBoxes();
            await LoadDataAsync();
            cboPayslipOption.SelectedIndex = 1;
        }
        private void InitializeComboBoxes()
        {
            ComboBoxHelper.PopulateWithYears(cmbYear, 2020, 2030);
            ComboBoxHelper.PopulateWithMonths(cmbMonth);
            ComboBoxHelper.Populate(cmbStep, new List<string> { "1", "2" });
            ComboBoxHelper.PopulateWithPrinters(comboBoxPrinters);
            cboEmployeeStatus.SelectedIndex = 0;
        }
        private async Task LoadDataAsync()
        {
            try
            {
                await LoadDepartmentsAsync();
                await LoadBranchesAsync();
                await LoadCategoriesAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadDepartmentsAsync()
        {
            try
            {
                var departments = await dataLoader.LoadDepartmentsAsync(includeInactive: false);
                ComboBoxHelper.Populate(cboDepartment, departments);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDepartment.Enabled = false;
            }
        }
        private async Task LoadBranchesAsync()
        {
            try
            {

                var branches = await dataLoader.LoadBranchesAsync();
                //if(branches.Count == 1)
                //{
                //    cboBranch.Enabled = false;
                //}
                ComboBoxHelper.Populate(cboBranch, branches);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading branches: {ex.Message}", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //cboBranch.Enabled = false;
            }
        }
        private async Task LoadCategoriesAsync()
        {
            try
            {

                var categories = await dataLoader.LoadCategoriesAsync();
                if (categories.Count <= 1)
                {
                    comboCategory.Enabled = false;
                }
                ComboBoxHelper.Populate(comboCategory, categories);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboCategory.Enabled = false;
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string response = await GetEmployeePRAsync();
            btnPrint.Enabled = true;
            displayRecords(response);
        }
        private async Task<string> GetEmployeePRAsync()
        {
            int year = Convert.ToInt32(cmbYear.Text);
            int month = Convert.ToInt32(cmbMonth.Text);
            int step = Convert.ToInt32(cmbStep.Text);
            string departmentCode = cboDepartment.SelectedItem?.ToString();
            string categoryCode = comboCategory.SelectedItem?.ToString();
            string employeeNo = txtEmployeeNo.Text;
            string branch = cboBranch.Text;
            string ma_or_resigned = cboEmployeeStatus.SelectedItem?.ToString();
            string payslip_option = cboPayslipOption.SelectedItem?.ToString();

            if (ma_or_resigned == "All")
            {
                ma_or_resigned = "";
            } else if (ma_or_resigned == "MA")
            {
                ma_or_resigned = "ma";
            } else if (ma_or_resigned == "Resigned")
            {
                ma_or_resigned = "resigned";
            } else
            {
                ma_or_resigned = "exclude_both";
            }
            var data = new
            {
                year = year,
                month = month,
                step = step,
                department_code = departmentCode,
                category_code = categoryCode,
                employee_no = employeeNo,
                branch = branch,
                ma_or_resigned = ma_or_resigned,
                payslip_option = payslip_option,
            };
            string apiUrl = $"{url}?token={token}";
            return await apiService.PostAsync(apiUrl, data);
        }

        private void displayRecords(string jsonResponse)
        {
            try
            {
                dgvDevice.Rows.Clear();
                payslipUrls.Clear();
                string payslip = cboPayslipOption.SelectedItem?.ToString();

                dynamic result = JsonConvert.DeserializeObject(jsonResponse);

                if (result.status.ToString() != "success")
                {
                    MessageBox.Show("No record found!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var records = result.records;
                int i = 1;
                foreach (var record in records)
                {
                    DataGridViewRow row = dgvDevice.Rows[dgvDevice.Rows.Add()];
                    row.Cells["colID"].Value = i++;
                    row.Cells["colEmpNo"].Value = record["employee_no"].ToString();
                    row.Cells["colEmpName"].Value = record["name"].ToString();
                    row.Cells["colPayInYear"].Value = record["department_code"].ToString();
                    row.Cells["colPayInMonth"].Value = record["position_code"].ToString();
                    row.Cells["payInStep"].Value = record["team_code"].ToString();

                    if (string.IsNullOrEmpty(record["tax_er_pay_amount_o_o"]?.ToString()))
                    {
                        record["tax_er_pay_amount_o_o"] = 0;
                    }
                }                
                ds.Tables.Clear();
                DataTable dt = App.JArrayToDataTable(records);
                dt.TableName = "employee_payroll";
                ds.Tables.Add(dt);                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying records: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {            
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Payslips");
            string payslip = cboPayslipOption.SelectedItem?.ToString();
            string reportName = "payslip";
            //if (payslip == "Payslip (Option 1)")
            //{
            //    folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Payslip (Option 1)");
            //    reportName = "payslip1";
            //}
            //else if(payslip == "Payslip (Option 2)")
            //{
            //    folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Payslip (Option 2)");
            //    reportName = "payslip1";
            //}
            //else
            //{
            folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Payslip");
            reportName = "payslip1";
            //}




            btnPrint.Enabled = false;
            btnSearch.Enabled = false;

            try
            {
                App.previewReport(reportName, ds);
                //await pdfService.DownloadPayslipsAsync(payslipUrls, folderPath);
                //pdfService.PrintDirect(folderPath, printerName);
                //MessageBox.Show($"Payslips downloaded and sent to printer.\nLocation: {folderPath}",
                //    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPrint.Enabled = true;
                btnSearch.Enabled = true;
            }
        }

        private void comboBoxPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            printerName = comboBoxPrinters.SelectedItem?.ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var row = printRows[printIndex];
            Font font = new Font("Arial", 12);
            float y = 100;

            e.Graphics.DrawString($"Employee ID: {row.Cells["colID"].Value}", font, Brushes.Black, 100, y); y += 30;
            e.Graphics.DrawString($"Employee No: {row.Cells["colEmpNo"].Value}", font, Brushes.Black, 100, y); y += 30;
            e.Graphics.DrawString($"Employee Name: {row.Cells["colEmpName"].Value}", font, Brushes.Black, 100, y); y += 30;
            e.Graphics.DrawString($"Pay Year: {row.Cells["colPayInYear"].Value}", font, Brushes.Black, 100, y); y += 30;
            e.Graphics.DrawString($"Pay Month: {row.Cells["colPayInMonth"].Value}", font, Brushes.Black, 100, y); y += 30;
            e.Graphics.DrawString($"Step: {row.Cells["payInStep"].Value}", font, Brushes.Black, 100, y); y += 30;

            e.HasMorePages = false;
            printIndex++;
        }

        private void timerPrint_Tick(object sender, EventArgs e)
        {
            if (printIndex < printRows.Count)
            {
                printDocument1.Print();
            }
            else
            {
                timerPrint.Stop();
                MessageBox.Show("Finished printing all records.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all data and delete downloaded PDFs?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                ClearAllData();
            }
        }

        private void ClearAllData()
        {
            try
            {
                dgvDevice.Rows.Clear();
                payslipUrls.Clear();
                DeleteDownloadedPdfs();

                cmbYear.SelectedItem = DateTime.Now.Year;
                cmbMonth.SelectedItem = DateTime.Now.Month;
                cmbStep.SelectedIndex = 0;

                if (cboDepartment.Items.Count > 0)
                    cboDepartment.SelectedIndex = 0;

                if (cboBranch.Items.Count > 0)
                    cboBranch.SelectedIndex = 0;

                MessageBox.Show("All data cleared and PDF files deleted successfully", "Clear",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteDownloadedPdfs()
        {
            try
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Payslips");

                if (Directory.Exists(folderPath))
                {
                    string[] pdfFiles = Directory.GetFiles(folderPath, "*.pdf");

                    int deletedCount = 0;
                    foreach (string file in pdfFiles)
                    {
                        try
                        {
                            File.Delete(file);
                            deletedCount++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not delete {file}: {ex.Message}");
                        }
                    }

                    Console.WriteLine($"Deleted {deletedCount} PDF file(s)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting PDFs: {ex.Message}");
            }
        }

        private void FRMMAIN_Load(object sender, EventArgs e)
        {

        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDevice.Rows.Clear();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDevice.Rows.Clear();
        }

        private void cmbStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDevice.Rows.Clear();
        }

        private void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDevice.Rows.Clear();
        }

        private void txtEmployeeNo_TextChanged(object sender, EventArgs e)
        {
            dgvDevice.Rows.Clear();
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDevice.Rows.Clear();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDevice.Rows.Clear();
        }

        private void cboPayslipOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            btnSearch.Focus();
        }
    }
}

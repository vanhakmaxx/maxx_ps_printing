using maxx_pos;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maxx_pos
{
    class App
    {
        public static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return (result);
            }
            catch (ConfigurationErrorsException)
            {
                return "Not Found";
            }
        }
        public static string previewReport(string reportName, DataSet ds)
        {
            try
            {                
                ReportParameter[] objReportParams = {  };
                FRMPRINTPREVIEW frm = new FRMPRINTPREVIEW();
                string rptPath = Application.StartupPath + @"\reports\" + reportName + ".rdl";
                if (File.Exists(rptPath)) frm.reportViewer.LocalReport.ReportPath = rptPath;
                else frm.reportViewer.LocalReport.ReportEmbeddedResource = "maxx_pos." + reportName;
                foreach (DataTable dt in ds.Tables)
                {
                    ReportDataSource Rptds = new ReportDataSource();
                    BindingSource rpt = new BindingSource();
                    rpt.DataMember = dt.TableName;
                    rpt.DataSource = ds;
                    Rptds.Name = rpt.DataMember;
                    Rptds.Value = rpt;
                    frm.reportViewer.LocalReport.DataSources.Add(Rptds);
                }

                frm.reportViewer.LocalReport.SetParameters(objReportParams);
                frm.reportViewer.RefreshReport();
                frm.ShowDialog();
                frm.Dispose();
                frm = null;
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }       
        public static DataTable JArrayToDataTable(JArray array)
        {
            DataTable table = new DataTable();

            foreach (JObject obj in array)
            {
                // Create columns
                foreach (var prop in obj.Properties())
                {
                    if (!table.Columns.Contains(prop.Name))
                        table.Columns.Add(prop.Name, typeof(string));
                }

                // Create rows
                DataRow row = table.NewRow();
                foreach (var prop in obj.Properties())
                {
                    row[prop.Name] = prop.Value?.ToString();
                }
                table.Rows.Add(row);
            }

            return table;
        }

    }
}

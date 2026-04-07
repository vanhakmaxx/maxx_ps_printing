using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace maxx_pos.Services
{
    public class PdfService
    {
        private readonly ApiService apiService;

        public PdfService(ApiService apiService)
        {
            this.apiService = apiService;
        }

       
        public async Task DownloadPayslipsAsync(List<string> urls, string folderPath, IProgress<int> progress = null)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            int index = 1;
            int total = urls.Count;

            foreach (var url in urls)
            {
                try
                {
                    string fileName = $"payslip_{index}.pdf";
                    string filePath = Path.Combine(folderPath, fileName);
                    byte[] fileBytes = await apiService.DownloadFileAsync(url);
                    File.WriteAllBytes(filePath, fileBytes);

                    progress?.Report((index * 100) / total);
                    index++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to download PDF {index} from {url}\n{ex.Message}",
                        "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void PrintAllPdfs(string folderPath, string printerName)
        {
           
            try
            {                
                foreach (string file in Directory.GetFiles(folderPath, "*.pdf"))
                {                    
                    using (var document = PdfiumViewer.PdfDocument.Load(file))
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        printDocument.PrinterSettings.PrinterName = printerName;
                        printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                        printDocument.DefaultPageSettings.PrinterResolution = new PrinterResolution{
                            Kind = PrinterResolutionKind.High
                        };                        
                        printDocument.Print();
                    }                    
                }
                MessageBox.Show("All PDFs printed successfully", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to print:\n{ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PrintDirect(string folderPath, string printerName)
        {

            try
            {
                foreach (string file in Directory.GetFiles(folderPath, "*.pdf"))
                {
                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = file,
                        Verb = "printto", // Use "print" to print to default printer
                        Arguments = $"\"{printerName}\"",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process process = new Process();
                    process.StartInfo = psi;
                    process.Start();

                    // Optional: Wait a few seconds and then close
                    process.WaitForExit(10000); // Wait max 10 seconds
                    process.Close();
                }
                MessageBox.Show("All PDFs printed successfully", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to print:\n{ex.Message}", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }                   
    }
}

using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;

namespace maxx_pos
{
    public class RdlcPrinterDirect : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        LocalReport report;
        string paperSize = "80mm";
        string orientation = "Portrait";

        private DataTable LoadSalesData()
        {
            // Create a new DataSet and read sales data file 
            //    data.xml into the first DataTable.
            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataSet.ReadXml(@"..\..\data.xml");
            return dataSet.Tables[0];
        }
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            try
            {
                string deviceInfo = "";

                if(paperSize == "80mm")
                {
                    deviceInfo =
                                          @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>2.91339in</PageWidth>
                        <PageHeight>11.6929in</PageHeight>
                        <MarginTop>0in</MarginTop>
                        <MarginLeft>0in</MarginLeft>
                        <MarginRight>0in</MarginRight>
                        <MarginBottom>0in</MarginBottom>
                    </DeviceInfo>";
                }
                else if(paperSize == "A5")
                {
                   if(orientation == "Portrait")
                    {
                        deviceInfo =
                                         @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>5.83in</PageWidth>
                        <PageHeight>8.27in</PageHeight>
                        <MarginTop>0in</MarginTop>
                        <MarginLeft>0in</MarginLeft>
                        <MarginRight>0in</MarginRight>
                        <MarginBottom>0in</MarginBottom>
                        </DeviceInfo>";
                    }
                    else
                    {
                        deviceInfo =
                                         @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>8.27in</PageWidth>
                        <PageHeight>5.83in</PageHeight>
                        <MarginTop>0in</MarginTop>
                        <MarginLeft>0in</MarginLeft>
                        <MarginRight>0in</MarginRight>
                        <MarginBottom>0in</MarginBottom>
                        </DeviceInfo>";
                    }
                }
                else
                {
                    deviceInfo =
                      @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>2.91339in</PageWidth>
                        <PageHeight>11.6929in</PageHeight>
                        <MarginTop>0in</MarginTop>
                        <MarginLeft>0in</MarginLeft>
                        <MarginRight>0in</MarginRight>
                        <MarginBottom>0in</MarginBottom>
                    </DeviceInfo>";
                }


                
                Microsoft.Reporting.WinForms.Warning[] warnings;
                m_streams = new List<Stream>();
                report.Render("Image", deviceInfo, CreateStream, out warnings);

                foreach (Stream stream in m_streams)
                    stream.Position = 0;

            }
            catch (Exception ex)
            {
                string e = ex.Message

                           + " <>" + ex.InnerException.Message
                          + " <>" + ex.InnerException.InnerException.Message;
            }

        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
            Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);

        }
        private void Print(Service service, string printer_name = "")
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();        
            ps.PrinterName = printer_name;
            printDoc.PrinterSettings = ps;

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the local printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;

                printDoc.Print();
            }

            printDoc.Dispose();  // for clean memory
            printDoc = null;
            ps = null;
        }
        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
        public RdlcPrinterDirect(LocalReport report, string paperSize = "80mm", string orientation= "Portrait")
        {
            this.report = report;

            // Paper
            this.paperSize = paperSize;
            this.orientation = orientation;
        }        
    }
}

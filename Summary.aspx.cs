using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataSet1TableAdapters;
using System.IO;
using System.Text;
using System.Drawing.Printing;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Drawing.Imaging;

public partial class Summary : System.Web.UI.Page
{    private int m_currentPageIndex;
    private IList<Stream> m_streams;
    DataSet1.Transactions_ATMDataTable dt=new DataSet1.Transactions_ATMDataTable();
        Transactions_ATMTableAdapter tadap = new Transactions_ATMTableAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
      

            dt = tadap.GetDataBy(Request.QueryString[1].ToString(), Request.QueryString[0].ToString());
            Console.Write(dt.Count.ToString());
      

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }




    private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,
                              string mimeType, bool willSeek)
    {
        Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
        m_streams.Add(stream);
        return stream;
    }

    private void Export(LocalReport report)
    {
        string deviceInfo =
          "<DeviceInfo>" +
          "  <OutputFormat>EMF</OutputFormat>" +
          "  <PageWidth>8.5in</PageWidth>" +
          "  <PageHeight>11in</PageHeight>" +
          "  <MarginTop>0.25in</MarginTop>" +
          "  <MarginLeft>0.25in</MarginLeft>" +
          "  <MarginRight>0.25in</MarginRight>" +
          "  <MarginBottom>0.25in</MarginBottom>" +
          "</DeviceInfo>";
        Warning[] warnings;
        m_streams = new List<Stream>();
        report.Render("Image", deviceInfo, CreateStream, out warnings);

        foreach (Stream stream in m_streams)
            stream.Position = 0;
    }

    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
        Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
        ev.Graphics.DrawImage(pageImage, ev.PageBounds);

        m_currentPageIndex++;
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
    }

    private void Print()
    {
        const string printerName = "Send To OneNote 2007";

        if (m_streams == null || m_streams.Count == 0)
            return;

        PrintDocument printDoc = new PrintDocument();
        printDoc.PrinterSettings.PrinterName = printerName;
        if (!printDoc.PrinterSettings.IsValid)
        {
            string msg = String.Format("Can't find printer \"{0}\".", printerName);
            Console.WriteLine(msg);
            return;
        }
        printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
        printDoc.Print();
    }

    private void Run()
    {
        LocalReport report = new LocalReport();
        report.ReportPath = "Report1.rdlc";
        report.DataSources.Add(new ReportDataSource("DataSet1_Transactions_ATM", dt));

        Export(report);

        m_currentPageIndex = 0;
        Print();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Run();
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Transactions.aspx");
    }
}

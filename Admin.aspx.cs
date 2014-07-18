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
using Microsoft.Reporting.WebForms;

public partial class Admin : System.Web.UI.Page
{

    Administrator_ATMTableAdapter admin = new Administrator_ATMTableAdapter();
    Customer_ATMTableAdapter cadap = new Customer_ATMTableAdapter();
        ATM_MachineTableAdapter atm = new ATM_MachineTableAdapter();
    Transactions_ATMTableAdapter trans = new Transactions_ATMTableAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
           
            GridView1.DataSource =(DataTable)Session["data"];
            GridView1.DataBind();
        }
       

    }
    protected void cutomer_Click(object sender, EventArgs e)
    {  DataSet1.Customer_ATMDataTable dt = new DataSet1.Customer_ATMDataTable();
    
        cadap.Fill(dt);
        GridView1.DataSource = dt;
        Session["data"] = dt;
        GridView1.DataMember = "Customer";
        GridView1.DataBind();
        admin.Insert(Request.QueryString[0].ToString(), null, "Check Customer Records");
        

    }
    protected void ATM_Click(object sender, EventArgs e)
    {
  
        DataSet1.ATM_MachineDataTable dt = new DataSet1.ATM_MachineDataTable();
        atm.FillBy(dt);
        GridView1.DataSource = dt;
        Session["data"] = dt;
        GridView1.DataBind();
        GridView1.DataMember = "ATM";
        admin.Insert(Request.QueryString[0].ToString(), null, "Check ATM Records");

    }
    protected void Transaction_Click(object sender, EventArgs e)
    {
        Label4.Visible = true;
        DropDownList1.Visible = true;
   
    }
    protected void adminrec_Click(object sender, EventArgs e)
    {
        DataSet1.Administrator_ATMDataTable dt = new DataSet1.Administrator_ATMDataTable();
        admin.Fill(dt,Request.QueryString[0].ToString());
            GridView1.DataSource = dt;
        Session["data"] = dt;
        GridView1.DataBind(); GridView1.DataMember = "Admin";
                admin.Insert(Request.QueryString[0].ToString(), null, "Check Admin Records");

    }
    protected void viewTransactionHistory_Click(object sender, EventArgs e)
    {
        admin.Insert(Request.QueryString[0].ToString(), null, "View Transaction History");
        //ReportParameter p = new
        //              ReportParameter("ShowDescriptions", checkBox1.Checked ? "true" : "false");
        //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p });
        //this.reportViewer1.RefreshReport();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet1.Transactions_ATMDataTable dt = new DataSet1.Transactions_ATMDataTable();
        trans.FillBy1(dt, DropDownList1.SelectedValue.ToString());
        GridView1.DataSource = dt;
        Session["data"] = dt;
        GridView1.DataBind();
        GridView1.DataMember = "ATM_TRANS";
        admin.Insert(Request.QueryString[0].ToString(), null, "Check Transaction Records for ATM" + DropDownList1.SelectedItem.Text);
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        
        ReportViewer1.LocalReport.Refresh();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView1_RowUpdated1(object sender, GridViewUpdatedEventArgs e)
    {
            switch (GridView1.DataMember)
        {
            case "Customer":
                cadap.Update((DataSet1.Customer_ATMDataTable)GridView1.DataSource);
                break;
            case "ATM":
                atm.Update((DataSet1.ATM_MachineDataTable)GridView1.DataSource);
                break;
            case "ATM_TRANS":
                trans.Update((DataSet1.Transactions_ATMDataTable)GridView1.DataSource);
                break;
            case "Admin":
                admin.Update((DataSet1.Administrator_ATMDataTable)GridView1.DataSource);
                break;
            }
    }
    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex; 


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
             DataSet1.Transactions_ATMDataTable dt = new DataSet1.Transactions_ATMDataTable();
        trans.FillBy2(dt,Convert.ToDateTime(TextBox1.Text),Convert.ToDateTime(TextBox2.Text));
        ReportViewer1.ProcessingMode=ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath="Report2.RDlc";
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1_Transactions_ATM", dt));
        ReportViewer1.LocalReport.Refresh();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    
        
    }
}

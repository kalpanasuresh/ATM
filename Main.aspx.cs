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

public partial class Main : System.Web.UI.Page
{
    private Button btn;
    private bool userAuthenticated; // true if user is authenticated
    private int currentAccountNumber; // user's account number

    protected void Page_Load(object sender, EventArgs e)
    {
        userAuthenticated = false; // user is not authenticated to start
        currentAccountNumber = 0; // no current account number to start


    }
    protected void Pin_Click(object sender, EventArgs e)
    {
        btn = (Button)sender;
        TextBox1.Text = TextBox1.Text + btn.Text;
    }

    protected void Enter_Click(object sender, EventArgs e)
    {
        Customer_Card_ATMTableAdapter adap = new Customer_Card_ATMTableAdapter();


        string accountNumber = (TextBox2.Text.Trim());

        string pin = (TextBox1.Text.Trim());
        int k = adap.GetDataBy(accountNumber, pin).Count;

        if (k >= 1)
        {

            Server.Transfer(string.Format("~/Transaction.aspx?Cust={0} & cN={1}&ATM={2}", pin, accountNumber, DropDownList1.SelectedValue.ToString()));
        }// save user's account #
        else

            Label3.Text = "Invalid Card Number or PIN. Please try again.";

    }

    protected void Cancel_Click(object sender, EventArgs e)
    {

    }
    protected void back_Click(object sender, EventArgs e)
    {

    }
}

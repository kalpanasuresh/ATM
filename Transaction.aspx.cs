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
using System.Drawing;

public partial class Transaction : System.Web.UI.Page
{
    private CashDispenser cashDispenser; // ref to ATM's cash dispenser
    private DepositSlot depositSlot; // reference to ATM's deposit slot
    private BankDatabase bankDatabase; // ref to account info database
    public decimal saving;
    public decimal checking;
    private string cAccID;
    private string sAccID;
    Accounts_ATMTableAdapter adap = new Accounts_ATMTableAdapter();
    DataSet1.Accounts_ATMDataTable dt = new DataSet1.Accounts_ATMDataTable();
    Transactions_ATMTableAdapter tadap = new Transactions_ATMTableAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(!IsPostBack)
        {
        adap.FillBy1(dt, Request.QueryString[0]);
     foreach (DataRow row in dt.Rows)
            {
                if (row["acc_type"].ToString() == "Checkings")
                {
                    lblChecking.Text = "  $" + row["acc_balance"].ToString();
                    checking=Convert.ToDecimal(row["acc_balance"]);
                }
                if (row["acc_type"].ToString() == "Savings")
                    lblSavings.Text = "$"+ row["acc_balance"].ToString();
                saving=Convert.ToDecimal(row["acc_balance"]);
         

            }
            lblTransfer.Text = "Savings";
            ViewState["C"] = checking;
            ViewState["S"] = saving;
        }
        cashDispenser = new CashDispenser(); // create cash dispenser
        depositSlot = new DepositSlot(); // create deposit slot
        bankDatabase = new BankDatabase();
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int acctNo=Convert.ToInt32(Request.QueryString[0]);
        MultiView1.ActiveViewIndex = 0;
        decimal bal=bankDatabase.GetAvailableBalance(acctNo);
        lblChecking.Text = "You have a balance of $" + bal + "in your account";
    }

    protected void checkBalance_Click(object sender, EventArgs e)
    {
        try
        {
            message.Text = string.Empty;

            adap.FillBy1(dt, Request.QueryString[0]);
            MultiView1.ActiveViewIndex = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["acc_type"].ToString() == "Checkings")
                {
                    lblChecking.Text = "  $" + row["acc_balance"].ToString();
                    checking=Convert.ToDecimal(row["acc_balance"]);
                   cAccID=row["acc_id"].ToString();
                }
                if (row["acc_type"].ToString() == "Savings")
                {
                    lblSavings.Text = "$"+ row["acc_balance"].ToString();
                saving=Convert.ToDecimal(row["acc_balance"]);
                sAccID=row["acc_id"].ToString();
                }

            }
          
            tadap.Insert(Request.QueryString[2].ToString(), Request.QueryString[0].ToString(), cAccID, sAccID, Request.QueryString[1].ToString(), "Balance Check", "000",DateTime.Now,"C");
         
        }
        catch (Exception ex)
        {
        }
    }
    protected void TransferAccount_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void withdraw_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;

    }
    protected void print_Click(object sender, EventArgs e)
    {
       Response.Redirect(string.Format("~/summary.aspx?Cust={0}& ATM={1} & cn={2}",Request.QueryString[0].ToString(),Request.QueryString[2].ToString(),Request.QueryString[1].ToString()));
    }
    protected void ok_Click(object sender, EventArgs e)
    {
        bool success = false;
        decimal wAmt=0;
        message.Text = string.Empty;
        checking = Convert.ToDecimal(ViewState["C"]);
        saving = Convert.ToDecimal(ViewState["S"]);
        if (TextBox1.Text != string.Empty)
        {
            wAmt = Convert.ToDecimal(TextBox1.Text);
        }
        else
        {
          wAmt   = Convert.ToDecimal(ViewState["btn"].ToString().Substring(1));
        }
            if (DropDownList1.SelectedIndex == 0)
            {
                if (wAmt < checking && (checking - wAmt) >= 200)
                {

                    checking = checking - wAmt;

                    success = true;
                }

            }
            else
            {
                if (wAmt < saving && (saving - wAmt) >= 200)
                {

                    saving = saving - wAmt;
                    success = true;

                }

            }
        
      
        if (success == true)
        {

            ATM_MachineTableAdapter atmmach = new ATM_MachineTableAdapter();
            DataSet1.ATM_MachineDataTable atm;
            atm = atmmach.GetData("111");
            int billsRequired = ((int)wAmt) / 20;
            if (Convert.ToInt32(atm[0]["cash"]) >= billsRequired)
            {
              atm[0]["cash"]= Convert.ToInt32(atm[0]["cash"]) - billsRequired;

                atmmach.Update(atm);
                message.Text = "Please take your cash from the cash dispenser.";
                adap.FillBy1(dt, Request.QueryString[0]);
                foreach (DataRow row in dt.Rows)
                {
                    if (row["acc_type"].ToString() == "Checkings")
                    {
                        row["acc_balance"] = checking.ToString();
                   
                    }
                    if (row["acc_type"].ToString() == "Savings")

                        row["acc_balance"] = saving.ToString();
                   
                }

                adap.Update(dt);
                adap.FillBy1(dt, Request.QueryString[0]);
                foreach (DataRow row in dt.Rows)
                {
                    if (row["acc_type"].ToString() == "Checkings")
                    {

                        checking = Convert.ToDecimal(row["acc_balance"]);
                        cAccID = row["acc_id"].ToString();

                    }
                    if (row["acc_type"].ToString() == "Savings")

                        saving = Convert.ToDecimal(row["acc_balance"]);
                    sAccID = row["acc_id"].ToString();


                }

                ViewState["C"] = checking;
                ViewState["S"] = saving;
                if (DropDownList1.SelectedIndex == 0)
                    tadap.Insert(Request.QueryString[2].ToString(), Request.QueryString[0].ToString(), cAccID, sAccID, Request.QueryString[1].ToString(), "Electronic Transfer from Checking",wAmt.ToString(), DateTime.Now,"C");
                else
                    tadap.Insert(Request.QueryString[2].ToString(), Request.QueryString[0].ToString(), sAccID, cAccID, Request.QueryString[1].ToString(), "Electronic Transfer from savings", wAmt.ToString(), DateTime.Now,"C");

            }
            else
            {
                message.Text = "Insufficient cash available in the ATM." +
                     "\n\nPlease choose a smaller amount.";
            }


        }
        else
        {  
            message.Text="\nInsufficient cash available in your account." +
                  "\n\nPlease choose a smaller amount." ;

        }
        
    }
    protected void cancel_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 0)
            lblTransfer.Text = "Savings";
        else
            lblTransfer.Text = "Checking";

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        bool success=false;
        message.Text = string.Empty;
        checking = Convert.ToDecimal(ViewState["C"]);
        saving = Convert.ToDecimal(ViewState["S"]);
        decimal trans=Convert.ToDecimal(txtAmountTrns.Text);

        if (DropDownList1.SelectedIndex == 0)
        {
            if (trans < checking && (checking - trans) >= 200)
            {
                saving = saving + trans;
                checking = checking - trans;

                success = true;
            }

        }
        else
        {
            if (trans < saving && (saving - trans) >= 200)
            {
                checking = checking + trans;
                saving = saving - trans;
                success = false;
                message.Text = "Transfeered successfully";
            }

        }
        if (success == true)
        {
            adap.FillBy1(dt, Request.QueryString[0]);
            foreach (DataRow row in dt.Rows)
            {
                if (row["acc_type"].ToString() == "Checkings")
                {
                    row["acc_balance"] = checking.ToString();


                }
                if (row["acc_type"].ToString() == "Savings")

                    row["acc_balance"] = saving.ToString();
            }

            adap.Update(dt);
            adap.FillBy1(dt, Request.QueryString[0]);
            foreach (DataRow row in dt.Rows)
            {
                if (row["acc_type"].ToString() == "Checkings")
                {

                    checking = Convert.ToDecimal(row["acc_balance"]);
                    cAccID = row["ACC_iD"].ToString();
                }
                if (row["acc_type"].ToString() == "Savings")

                    saving = Convert.ToDecimal(row["acc_balance"]);
                sAccID = row["acc_id"].ToString();


            }

            ViewState["C"] = checking;
            ViewState["S"] = saving;

            message.Text = "Transferred successfully!";
            if(DropDownList1.SelectedIndex==0)
            tadap.Insert("111", Request.QueryString[0].ToString(), cAccID, sAccID, Request.QueryString[1].ToString(), "Electronic Transfer from Checking to Savings", trans.ToString(), DateTime.Now,"C");
            else
            tadap.Insert("111", Request.QueryString[0].ToString(), sAccID, cAccID, Request.QueryString[1].ToString(), "Electronic Transfer from savings to checking", trans.ToString(), DateTime.Now,"C");

        }
        }

    protected void Button5_Click(object sender, EventArgs e)
    {

    }
    protected void Button8_Click(object sender, EventArgs e)
    {
  
       
    }
    protected void Button5_Click1(object sender, EventArgs e)
    {
        Button btn;
        btn = (Button)sender;
        foreach (Control ctl in this.MultiView1.Views[2].Controls)
        {
            if (ctl.GetType() == typeof(Button))
            {
                if (((Button)ctl).BackColor==Color.LightSalmon && (Button)ctl!=btn)
                    ((Button)ctl).BackColor = Color.FromName("0");
            }
        }


   
        if (btn.BackColor.Name == "0")
        {
            btn.BackColor = Color.LightSalmon;
            ViewState["btn"] = btn.Text;
        }
        else
          btn.BackColor  = Color.FromName("0");
    
    


    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        foreach (Control ctl in this.MultiView1.Views[2].Controls)
        {
            if (ctl.GetType() == typeof(Button))
            {
              
                    ((Button)ctl).BackColor = Color.FromName("0");
            }
        }

    }
}

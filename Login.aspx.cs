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

public partial class Login : System.Web.UI.Page
{
    AdminTableAdapter adap = new AdminTableAdapter();
    DataSet1.AdminDataTable dt = new DataSet1.AdminDataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        adap.Fill(dt,Login1.UserName, Login1.Password);
        if (dt.Rows.Count == 1)
        {
            e.Authenticated = true;
        
          Response.Redirect(string.Format("~/Admin.aspx?ad={0}",Login1.UserName));
           
        }
       
    }
}

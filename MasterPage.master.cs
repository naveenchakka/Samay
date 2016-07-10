using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspfiles_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //userdata();
    }
    public void userdata()
    {
        Session.Timeout = 60;
        int userid = Convert.ToInt32(Session["Userid"].ToString());
        string fullname = Session["FullName"].ToString();
        lblUserName.Text = fullname;
        string username = Session["UserName"].ToString();
        int UserTypeId = Convert.ToInt32(Session["UserTypeId"].ToString());       
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {           
             Session.Clear();
        Session.Abandon();
            Response.Write("<script>window.location='Login.aspx';</script>");
        }       
    }
}

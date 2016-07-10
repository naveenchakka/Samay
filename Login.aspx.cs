using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Aspfiles_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }   
    private void getdata()
    {
       
        BusinessObject bo=new BusinessObject();
        bo.Username = txtUserName.Text;
        bo.Password = txtPassword.Text;
        DataSet ds = CheckLogin(bo);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["UserName"] = txtUserName.Text;
            Session["Userid"] = ds.Tables[0].Rows[0][0].ToString();
            Session["FirstName"] = ds.Tables[0].Rows[0][2].ToString();
            Session["LastName"] = ds.Tables[0].Rows[0][3].ToString();
            Session["FullName"] = ds.Tables[0].Rows[0][2].ToString() + " " + ds.Tables[0].Rows[0][3].ToString();
            Session["UserTypeId"] = ds.Tables[0].Rows[0][4].ToString();
            Session["Mobile"] = ds.Tables[0].Rows[0][5].ToString();
            Session["Email"] = ds.Tables[0].Rows[0][6].ToString();
            Session["Organization"] = ds.Tables[0].Rows[0][7].ToString(); 
            Response.Redirect("Index.aspx");
        }
        else
        {
            Response.Write("<script>alert('Login Failed! username or password is wrong');</script>");
            Response.Write("<script>window.location='Login.aspx';</script>");
        }          
    }

  
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        getdata();
    }
    public DataSet CheckLogin(BusinessObject bo)
    {
        DataAccess da = new DataAccess();
        SqlCommand cmd = new SqlCommand();
        SqlParameter[] params1 ={new SqlParameter("@Username",bo.Username),
        new SqlParameter("@Password",bo.Password)};
        DataSet ds = da.ExecuteDataset( CommandType.StoredProcedure, "SPCheckLogin", params1);
        return ds;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public partial class Aspfiles_Default : System.Web.UI.Page
{
    int Userid;
    DataAccess da = new DataAccess();
    BusinessObject bo=new BusinessObject();
    protected void Page_Load(object sender, EventArgs e)
    {
        Userid = Convert.ToInt32(Session["Userid"].ToString());
        Panel2.Visible = true;
        Panel1.Visible = false;
        if (IsPostBack == false)
        {
            BindCarrierCode();
            BindSendersId();
            BindTemplateNames();
        }
        ddl_carriercode.Enabled = false;

    }
    public void BindCarrierCode()
    {
        DataSet ds = da.ExecuteDataset(CommandType.StoredProcedure, "SPBindCarrierCode");
        ddl_carriercode.DataSource = ds;
        ddl_carriercode.DataTextField = "CarrierCode";
        ddl_carriercode.DataValueField = "CarrierId";
        ddl_carriercode.DataBind();
     
    }
    public void BindSendersId()
    {
       
        bo.Userid=Userid;
        SqlParameter[] params1 = { new SqlParameter("@UserID", bo.Userid) };
        DataSet ds = da.ExecuteDataset(CommandType.StoredProcedure, "SPBindSendersID", params1);
        ddl_senderids.DataSource = ds;
        ddl_senderids.DataTextField = "SenderValue";
        ddl_senderids.DataValueField = "SenderId";
        ddl_senderids.DataBind();
        ddl_senderids.Items.Insert(0, "--Select SenderId--");
      
    }
    public void BindTemplateNames()
    {
       
        bo.Userid = Userid;
        SqlParameter[] params1 = { new SqlParameter("@UserID", bo.Userid) };
        DataSet ds = da.ExecuteDataset(CommandType.StoredProcedure, "SPBindTemplatesName", params1);
        ddl_templates.DataSource = ds;
        ddl_templates.DataTextField = "TempleteName";
        ddl_templates.DataValueField = "UserTempletId";
        ddl_templates.DataBind();
        ddl_templates.Items.Insert(0, new ListItem("--Select Template--", "0"));
        
    }
   
    protected void btnmblnoclear_Click(object sender, EventArgs e)
    {
        txtmessage.Text = "";
    }
    protected void ddl_templates_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_templates.SelectedItem.Text != "--Select Template--")
        {
            bo.Userid = Userid;
            SqlParameter[] params1 = { new SqlParameter("@UserID", bo.Userid), new SqlParameter("@TemplateId", ddl_templates.SelectedValue) };
            DataSet ds = da.ExecuteDataset(CommandType.StoredProcedure, "SPGetTemplateMsg", params1);
            txtmessage.Text = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            Response.Write("<script>alert('Please select the Template')</script>");
        }
    }
    protected void btnpreview_Click(object sender, EventArgs e)
    {
    
        bo.Userid = Userid;
            if(ddl_senderids.SelectedItem.Text=="--Select SenderId--")
            {
                Response.Write("<script>alert('Please Select Sender ID')</script>");
            }
           else
            {  
            Panel2.Visible = false;
            lbl_senderid.Text = ddl_senderids.SelectedItem.Text;
            lbldisplaycarrierid.Text = ddl_carriercode.SelectedItem.Text;
            lbl_mblno.Text = txtmobileno.Text;
            lbl_templatemsg.Text = txtmessage.Text;
            Panel1.Visible = true;
            }
           

    }
  
    protected void btnmsgclear_Click(object sender, EventArgs e)
    {
        ddl_templates.SelectedItem.Text = "--Select Template--";
        txtmessage.Text = "";

    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        SqlParameter[] params1 = {new SqlParameter("@CarrierID",ddl_carriercode.SelectedValue), new SqlParameter("@UserID", Userid), new SqlParameter("@TemplateID",ddl_templates.SelectedValue),
                                     new SqlParameter("@SenderID",ddl_senderids.SelectedValue),new SqlParameter("@MobileNo",txtmobileno.Text),
                                  new SqlParameter("@Message",txtmessage.Text),new SqlParameter("@Date",DateTime.Now),new SqlParameter("@Status","processing")};
        int res = da.ExecuteNonQuery(CommandType.StoredProcedure, "SPSingleSMS", params1);
        if (res > 0)
        {
            Response.Write("<script>alert('Message Sent Successfully')</script>");
            txtmobileno.Text = "";
            txtmessage.Text = "";
            Panel1.Visible = false;
            Panel2.Visible = true;
            BindSendersId();
            BindCarrierCode();
            BindTemplateNames();
        }
        else
        {
            Response.Write("<script>alert('Message Sent Failure')</script>");
            txtmobileno.Text = "";
            txtmessage.Text = "";

        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        txtmessage.Text = "";
        txtmobileno.Text = "";
        BindSendersId();
        BindTemplateNames();
    }
}
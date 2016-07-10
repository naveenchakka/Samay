using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for BusinessLayer
/// </summary>
public class BusinessLayer
{
    int i = 0;
    string msg=null;
	public BusinessLayer()
	{
	}
    //No use
    //public string CreatePassword(int length)
    //{
    //    string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    //    string res = "";
    //    Random rnd = new Random();
    //    while (0 < length--)
    //        res += valid[rnd.Next(valid.Length)];
    //    return res;
    //}
    //public int InsertUserInfo(BusinessObject bo)
    //{
    //    DataAccess da = new DataAccess();
    //    SqlCommand cmd=new SqlCommand();
    //    SqlParameter[] params1 ={ new SqlParameter("@FirstName",bo.Firstname),
    //                     new SqlParameter("@UserName",bo.Username),
    //    new SqlParameter("@LastName",bo.Lastname),
    //    new SqlParameter("@Password",bo.Password),
    //    new SqlParameter("@Mobile",bo.Mobile),
    //    new SqlParameter("@Email",bo.Email),
    //    new SqlParameter("@Organization",bo.Organization),
    //    new SqlParameter("@Address",bo.Address),
    //    new SqlParameter("@UserTypeId",bo.Usertypeid),
    //    new SqlParameter("@IsAdmin",bo.Isadmin),
    //    new SqlParameter("@ParentUserId",bo.Parentuserid) };
    //    return i = da.ExecuteNonQuery(Connection(), CommandType.StoredProcedure,"SpTblUsers", params1);            
    //}
    //public int UpdateUserInfo(BusinessObject bo)
    //{
    //    DataAccess da = new DataAccess();
    //    SqlCommand cmd = new SqlCommand();
    //    SqlParameter[] params1 ={ new SqlParameter("@FirstName",bo.Firstname),
    //                     new SqlParameter("@UserName",bo.Username),
    //    new SqlParameter("@LastName",bo.Lastname),
    //    new SqlParameter("@Mobile",bo.Mobile),
    //    new SqlParameter("@Email",bo.Email),
    //    new SqlParameter("@Organization",bo.Organization),
    //    new SqlParameter("@Address",bo.Address),
    //    new SqlParameter("@UserTypeId",bo.Usertypeid),
    //    new SqlParameter("@IsAdmin",bo.Isadmin)};
    //    return i = da.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, "SPUpdateUserDetails", params1);   
    //}
    //public DataSet RetriveUserInfo(BusinessObject bo)
    //{     
    //      DataAccess da = new DataAccess();
    //      SqlParameter[] params1 = { new SqlParameter("@userid", bo.Userid) };
    //      DataSet ds = da.ExecuteDataset(Connection(), CommandType.StoredProcedure, "SPSelectUserData",params1);
    //      return ds;
    //}

    //public DataSet CheckLogin(BusinessObject bo)
    //{
    //    DataAccess da = new DataAccess();
    //    SqlCommand cmd=new SqlCommand();
    //    SqlParameter[] params1 ={new SqlParameter("@Username",bo.Username),
    //    new SqlParameter("@Password",bo.Password)
    //                            };
    //    DataSet ds = da.ExecuteDataset(Connection(),CommandType.StoredProcedure,"SPCheckLogin", params1);
    //    return ds;
    //}
    //public int InsertGroupName(BusinessObject bo)
    //{
    //    DataAccess da = new DataAccess();
    //    SqlCommand cmd=new SqlCommand();
    //    SqlParameter[] params1 ={ new SqlParameter("@UserID",bo.Userid),
    //                     new SqlParameter("@GroupName",bo.Groupname)};
    //    return i = da.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, "SPInsertGroupName", params1);            
    //}
    //public string RequestSenderId(BusinessObject bo)
    //{
    //    string msg = null;
    //    DataAccess da = new DataAccess();
    //      SqlCommand cmd=new SqlCommand();
    //      SqlParameter[] params1 = { new SqlParameter("@SenderId", bo.Senderid) };
    //      int i = da.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, "SPInsertSenderID", params1);
    //      SqlParameter[] params2 = { new SqlParameter("@sendervalue", bo.Senderid),
    //                               new SqlParameter("@userid", bo.Userid),
    //                               new SqlParameter("@statusid","1")};
    //      int j = da.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, "SPInsertSenderIDRequest", params2);
    //      if (i ==1)
    //      {

    // Latter
    //public DataSet CheckLogin(BusinessObject bo)
    //{
    //    DataAccess da = new DataAccess();
    //    SqlCommand cmd=new SqlCommand();
    //    SqlParameter[] params1 ={new SqlParameter("@Username",bo.Username),
    //    new SqlParameter("@Password",bo.Password)
    //                            };
    //    DataSet ds = da.ExecuteDataset(Connection(),CommandType.StoredProcedure,"SPCheckLogin", params1);
    //    return ds;
    //}
    //public int InsertGroupName(BusinessObject bo)
    //{
    //    DataAccess da = new DataAccess();
    //    SqlCommand cmd=new SqlCommand();
    //    SqlParameter[] params1 ={ new SqlParameter("@UserID",bo.Userid),
    //                     new SqlParameter("@GroupName",bo.Groupname)};
    //   // return i = da.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, "SPInsertGroupName", params1);            
    //}
    //public string RequestSenderId(BusinessObject bo)
    //{
    //    string msg = null;
    //    DataAccess da = new DataAccess();
    //      SqlCommand cmd=new SqlCommand();
    //      SqlParameter[] params1 = { new SqlParameter("@SenderId", bo.Senderid) };
    //      int i = da.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, "SPInsertSenderID", params1);
    //      SqlParameter[] params2 = { new SqlParameter("@sendervalue", bo.Senderid),
    //                               new SqlParameter("@userid", bo.Userid),
    //                               new SqlParameter("@statusid","1")};
    //      int j = da.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, "SPInsertSenderIDRequest", params2);
    //      if (i ==1)
    //      {

    //          msg = "Reguest Send Sucessfully!";
    //      }
    //      else
    //      {
    //          msg="Requesting sending Failed";
    //      }
    //      return msg;
    //}
    //public DataSet GroupName_DDl()
    //{
    //    DataAccess da = new DataAccess();        
    //    DataSet ds=da.ExecuteDataset(Connection(), CommandType.StoredProcedure, "SPGetGroupNameDDL");
    //    return ds; 
    //}

    //          msg = "Reguest Send Sucessfully!";
    //      }
    //      else
    //      {
    //          msg="Requesting sending Failed";
    //      }
    //      return msg;
    //}
    //public DataSet GroupName_DDl()
    //{
    //    DataAccess da = new DataAccess();        
    //    DataSet ds=da.ExecuteDataset( CommandType.StoredProcedure, "SPGetGroupNameDDL");
    //    return ds; 
    //}

}
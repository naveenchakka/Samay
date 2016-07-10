using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BusinessObject
/// </summary>
public class BusinessObject
{
	public BusinessObject()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   
    private string username;

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    private string password;

    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    private string firstname;

    public string Firstname
    {
        get { return firstname; }
        set { firstname = value; }
    }
    private string lastname;

    public string Lastname
    {
        get { return lastname; }
        set { lastname = value; }
    }
    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    private string mobile;

    public string Mobile
    {
        get { return mobile; }
        set { mobile = value; }
    }
    private string organization;

    public string Organization
    {
        get { return organization; }
        set { organization = value; }
    }
    private string address;

    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    private string usertypeid;

    public string Usertypeid
    {
        get { return usertypeid; }
        set { usertypeid = value; }
    }
    private string isadmin;

    public string Isadmin
    {
        get { return isadmin; }
        set { isadmin = value; }
    }
    private string parentuserid;

    public string Parentuserid
    {
        get { return parentuserid; }
        set { parentuserid = value; }
    }
    private string groupname;

    public string Groupname
    {
        get { return groupname; }
        set { groupname = value; }
    }
    private int userid;

    public int Userid
    {
        get { return userid; }
        set { userid = value; }
    }
    private string senderid;

    public string Senderid
    {
        get { return senderid; }
        set { senderid = value; }
    }
    private int groupid;

    public int Groupid
    {
        get { return groupid; }
        set { groupid = value; }
    }

    private string[] contacts;

    public string[] Contacts
    {
        get { return contacts; }
        set { contacts = value; }
    }
    private string contactname;

    public string Contactname
    {
        get { return contactname; }
        set { contactname = value; }
    }
    private string contactnumber;

    public string Contactnumber
    {
        get { return contactnumber; }
        set { contactnumber = value; }
    }
    private string requestcredits;

    public string Requestcredits
    {
        get { return requestcredits; }
        set { requestcredits = value; }
    }
    private string date;

    public string Date
    {
        get { return date; }
        set { date = value; }
    }
    private string prefix;

    public string Prefix
    {
        get { return prefix; }
        set { prefix = value; }
    }
    private string dob;

    public string Dob
    {
        get { return dob; }
        set { dob = value; }
    }
    private string gender;

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    private string fax;

    public string Fax
    {
        get { return fax; }
        set { fax = value; }
    }
    private string newpassword;

    public string Newpassword
    {
        get { return newpassword; }
        set { newpassword = value; }
    }
    private int templateid;

    public int Templateid
    {
        get { return templateid; }
        set { templateid = value; }
    }
    private string carrierid;

    public string Carrierid
    {
        get { return carrierid; }
        set { carrierid = value; }
    }

    private string messagecontent;

    public string Messagecontent
    {
        get { return messagecontent; }
        set { messagecontent = value; }
    }
    private string campaignname;

    public string Campaignname
    {
        get { return campaignname; }
        set { campaignname = value; }
    }
    private int messageid;

    public int Messageid
    {
        get { return messageid; }
        set { messageid = value; }
    }
}
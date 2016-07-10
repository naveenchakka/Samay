using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
	public DataAccess()
	{	}
    string connectionString;
    int EventId = 8;

    private string strConnection()
    {
        return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }

    public int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        string connectionString = strConnection();

        if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

        // Create & open a SqlConnection, and dispose of it after we are done
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            if (connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;

            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();
            return retval;
        }
    }

    public int ExecuteScalar( CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        string connectionString = strConnection();

        if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

        // Create & open a SqlConnection, and dispose of it after we are done
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            if (connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;

            PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = Convert.ToInt16(cmd.ExecuteScalar());

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();
            return retval;
        }
    }

    private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, out bool mustCloseConnection)
    {
        if (command == null) throw new ArgumentNullException("command");
        if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

        // If the provided connection is not open, we will open it
        if (connection.State != ConnectionState.Open)
        {
            mustCloseConnection = true;
            connection.Open();
        }
        else
        {
            mustCloseConnection = false;
        }

        // Associate the connection with the command
        command.Connection = connection;

        // Set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText;

        // If we were provided a transaction, assign it
        if (transaction != null)
        {
            if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            command.Transaction = transaction;
        }

        // Set the command type
        command.CommandType = commandType;

        // Attach the command parameters if they are provided
        if (commandParameters != null)
        {
            AttachParameters(command, commandParameters);
        }
        return;
    }

    private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
    {
        if (command == null) throw new ArgumentNullException("command");
        if (commandParameters != null)
        {
            foreach (SqlParameter p in commandParameters)
            {
                if (p != null)
                {
                    // Check for derived output value with no value assigned
                    if ((p.Direction == ParameterDirection.InputOutput ||
                        p.Direction == ParameterDirection.Input) &&
                        (p.Value == null))
                    {
                        p.Value = DBNull.Value;
                    }
                    command.Parameters.Add(p);
                }
            }
        }
    }

    public DataSet ExecuteDataset( CommandType commandType, string commandText)
    {
        string connectionString = strConnection();
        // Pass through the call providing null for the set of SqlParameters

        return ExecuteDataset( commandType, commandText, (SqlParameter[])null);

    }

    public DataSet ExecuteDataset( CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        string connectionString = strConnection();
        if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

        // Create & open a SqlConnection, and dispose of it after we are done
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Call the overload that takes a connection in place of the connection string
            return ExecuteDataset(connection, commandType, commandText, commandParameters);
        }
    }

    public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        if (connection == null) throw new ArgumentNullException("connection");

        // Create a command and prepare it for execution
        SqlCommand cmd = new SqlCommand();
        bool mustCloseConnection = false;
        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

        // Create the DataAdapter & DataSet
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            DataSet ds = new DataSet();

            // Fill the DataSet using default values for DataTable names, etc
            da.Fill(ds);

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();

            if (mustCloseConnection)
                connection.Close();

            // Return the dataset
            return ds;
        }
    }

    private DataTable ExecuteDatatable(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        if (connectionString == null || connectionString.Length == 0)
            throw new ArgumentNullException("connectionString");

        // Create & open a SqlConnection, and dispose of it after we are done
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();

            // Associate the connection with the command
            cmd.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            cmd.CommandText = commandText;

            // Set the command type
            cmd.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(cmd, commandParameters);
            }

            // Create the DataAdapter & DataSet
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dt);

                // Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                connection.Close();

                // Return the dataset
                return dt;
            }
        }
    }

    //private string sendMail(string sSubject, string selMIds, string sCompanyName, string sJobTitle)
    //{
    //    string sMessage = string.Empty;

    //    MailAddress To = new MailAddress(txtEmail.Text.Trim(), txtFirstName.Text + " " + txtLastName.Text);
    //    //MailAddress To = new MailAddress("venu.kadiyala@selectstaffing.com", "venu");
    //    MailAddress From = new MailAddress("meetings@selectstaffing.com");

    //    // Create a new message object
    //    MailMessage message = new MailMessage(From, To);
    //    message.CC.Add("meetings@selectstaffing.com");

    //    sMessage += "Emails to:<br>meetings@selectstaffing.com<br>";

    //    //if (EventId == 8 || EventId == 9)
    //    //{
    //    //    message.CC.Add("David.Bolde@selectfamily.com");
    //    //    message.CC.Add("Clarissa.Ersoz@selectfamily.com");
    //    //}      


    //    StringBuilder sbMailBody = new StringBuilder();

    //    sbMailBody.Append("<table cellspacing='0' style='font-family: verdana; font-size: 12px' cellpadding='1'><tr><td>");
    //    //sbMailBody.Append(sMessage);    
    //    sbMailBody.Append("Dear " + txtFirstName.Text + " " + txtLastName.Text + ",<br><br>" + lblMailMessage.Text + "<br><br>");
    //    sbMailBody.Append("<b><font color='maroon'>---YOU ARE REGISTERED FOR THE FOLLOWING EVENTS---</font></b><br><br>");
    //    sbMailBody.Append("<table cellspacing='0' style='font-family: verdana; font-size: 12px' cellpadding='1'>");
    //    string sEventName = string.Empty, sEventDate = string.Empty;

    //    foreach (GridViewRow gvRow in gvCommercialRemx.Rows)
    //    {
    //        CheckBox chk = (CheckBox)gvRow.Cells[0].FindControl("ChkAttending");
    //        if (chk.Checked)
    //        {
    //            Label lblMeetingName = (Label)gvRow.Cells[1].FindControl("lblMeetingName");
    //            sbMailBody.Append("<tr><td width='250px'><b><font color='maroon'>" + lblMeetingName.Text + ":</font></b></td><td>" + gvRow.Cells[2].Text + "</td></tr>");
    //        }
    //    }

    //    foreach (GridViewRow gvRow in gvFranchise.Rows)
    //    {
    //        CheckBox chk = (CheckBox)gvRow.Cells[0].FindControl("ChkAttending");
    //        if (chk.Checked)
    //        {
    //            Label lblMeetingName = (Label)gvRow.Cells[1].FindControl("lblMeetingName");
    //            sbMailBody.Append("<tr><td><b><font color='maroon'>" + lblMeetingName.Text + ":</b></font></td><td>" + gvRow.Cells[2].Text + "</td></tr>");
    //        }
    //    }

    //    sbMailBody.Append("</table><br><br><font color='maroon'><b>--------HOTEL INFORMATION--------</b></font><br><br>");
    //    sbMailBody.Append("<table cellspacing='0' style='font-family: verdana; font-size: 12px' cellpadding='1'>");
    //    //sbMailBody.Append("<tr><td><b><font color='maroon'>Hotel:</font></b></font></td><td>JW Marriott Desert Springs Resort & Spa in Palm Desert, CA</br></td></tr>");
    //    DateTime dtSelected = new DateTime();

    //    if (ddlCheckIn.SelectedIndex == ddlCheckIn.Items.Count - 1)
    //    {
    //        sbMailBody.Append("<tr><td><b><font color='maroon'>Not Staying in Hotel</font></b></td></tr>");
    //    }
    //    else
    //    {
    //        if (ddlCheckIn.SelectedIndex > 0 && ddlCheckIn.SelectedIndex != ddlCheckIn.Items.Count - 1)
    //        {
    //            dtSelected = Convert.ToDateTime(ddlCheckIn.SelectedItem.Text);
    //            sbMailBody.Append("<tr><td><font color='maroon'><b>CheckIn:</b></font></td><td>" + dtSelected.ToString("dd-MMM-yyyy") + "</td></tr>");
    //        }
    //        if (ddlCheckOut.SelectedIndex > 0 && ddlCheckOut.SelectedIndex != ddlCheckOut.Items.Count - 1)
    //        {
    //            dtSelected = Convert.ToDateTime(ddlCheckOut.SelectedItem.Text);
    //            sbMailBody.Append("<tr><td><font color='maroon'><b>CheckOut:</b></font></td><td>" + dtSelected.ToString("dd-MMM-yyyy") + "</td></tr>");
    //        }
    //        sbMailBody.Append("</table>");

    //        bool isNightsChecked = false;

    //        foreach (ListItem Li in chkLstNightStay.Items)
    //        {
    //            if (Li.Selected)
    //            {
    //                isNightsChecked = true;
    //                break;
    //            }
    //        }
    //        if (isNightsChecked)
    //        {
    //            sbMailBody.Append("<table cellspacing='0' style='font-family: verdana; font-size: 12px' cellpadding='1'>");
    //            sbMailBody.Append("<tr><td><br><u><font color='maroon'><b>Nights Booked</b></font><u><br></td></tr>");
    //            for (int iStart = 0; iStart < chkLstNightStay.Items.Count; iStart++)
    //            {
    //                if (chkLstNightStay.Items[iStart].Selected)
    //                {
    //                    sbMailBody.Append("<tr><td>" + chkLstNightStay.Items[iStart].Text + "</td></tr>");
    //                }
    //            }
    //            /*
    //            if (chkSharedRoom.Checked == true)
    //            {
    //                if (txtSharedPersonName.Text.Trim() != "")
    //                {
    //                    sbMailBody.Append("<tr><td><br><font color='maroon'><b>Sharing Room:</b></font> YES </td></tr>");
    //                    sbMailBody.Append("<tr><td><font color='maroon'><b>Shared Person Name:</b></font> " + txtSharedPersonName.Text.Trim() + "</td></tr>");
    //                }
    //            }
    //            else
    //                sbMailBody.Append("<tr><td><font color='maroon'><br><b>Sharing Room:</b></font> NO </td></tr>");
    //            */
    //            sbMailBody.Append("</table>");
    //        }
    //    }
    //    sbMailBody.Append("<table cellspacing='0' style='font-family: verdana; font-size: 12px' cellpadding='1'>");
    //    sbMailBody.Append("<tr><td><font color='maroon'><b>Special Hotel Requests:</b></font> " + txtSpecialHousingRequests.Text.Trim() + "</td></tr>");
    //    sbMailBody.Append("</table>");
    //    sbMailBody.Append("<br>-------------------------------------------------------<br>");
    //    sbMailBody.Append(lblMailFooter.Text);
    //    sbMailBody.Append("</td></tr></table>");

    //    if (From.ToString().Trim() != "" && To.ToString().Trim() != "")
    //    {


    //        if (sSubject == "NEW")
    //        {
    //            message.Subject = lblEventHeading.Text + " ( " + txtFirstName.Text + " " + txtLastName.Text + " )";
    //        }
    //        else
    //        {
    //            message.Subject = "Updated " + lblEventHeading.Text + " ( " + txtFirstName.Text + " " + txtLastName.Text + " )";
    //        }

    //        message.IsBodyHtml = true;


    //        DataTable dtMailIds = ExecuteDatatable(CommandType.Text, "select Mids, CCMailId from MailInfo where EventId = " + EventId, null);

    //        if (selMIds.Length > 0)  // 16,17,18,19,20,21
    //        {
    //            foreach (DataRow dtRow in dtMailIds.Rows)
    //            {
    //                string strMids = dtRow["MIds"].ToString();

    //                string[] MeetingIds = strMids.Split(',');

    //                foreach (string id in MeetingIds)
    //                {
    //                    if (selMIds.Contains(id) && id != "")
    //                    {
    //                        message.CC.Add(dtRow["CCMailId"].ToString());
    //                        break;
    //                    }
    //                }

    //            }
    //        }


    //        message.Body = sbMailBody.ToString();
    //        SmtpClient oClient = new SmtpClient("10.200.8.246");
    //        try
    //        {
    //            oClient.Send(message);
    //        }
    //        catch (Exception ex)
    //        {

    //        }
    //    }
    //    return sbMailBody.ToString();
    //}
}
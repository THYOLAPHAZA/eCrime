using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    public static String LogoText = "eCrime";
    public static String MainHeaderText = "Welcome to eCrime!";
    public static String FooterText = "Online Crime Reporting &copy; 2020 (CR)";


    public static string CreateMenu(string usertype)
    {
        string mMenu = "";
        if (usertype == "Administrator")
        {
            mMenu = mMenu + "<a href='Default.aspx' title='Home'>&nbsp;&nbsp;Home</a>";
            mMenu = mMenu + "<a href='ManageUser.aspx' title='Manage User'>&nbsp;&nbsp;Manage User</a>";
            mMenu = mMenu + "<a href='ViewComplaint.aspx' title='View Complaint'>&nbsp;&nbsp;View Complaint</a>";
            mMenu = mMenu + "<a href='ViewReports.aspx' title='View Reports'>&nbsp;&nbsp;View Reports</a>";
            mMenu = mMenu + "<a href='Logout.aspx' title='Logout'>&nbsp;&nbsp;Logout</a>";
        }
        else if (usertype == "Department")
        {
            mMenu = mMenu + "<a href='Default.aspx' title='Home'>&nbsp;&nbsp;Home</a>";
            mMenu = mMenu + "<a href='UserRegistration.aspx?type=citi&tag=edit&id=0' title='Citizen Registration'>&nbsp;&nbsp;Citizen Registration</a>";
            mMenu = mMenu + "<a href='ManageCriminalData.aspx' title='Manage Criminal Data'>&nbsp;&nbsp;Manage Criminal Data</a>";
            mMenu = mMenu + "<a href='ManageMissingCitizen.aspx' title='Manage Missing Citizen'>&nbsp;&nbsp;Manage Missing Citizen</a>";
            mMenu = mMenu + "<a href='ManageUser.aspx' title='View Profile'>&nbsp;&nbsp;View Profile</a>";
            mMenu = mMenu + "<a href='ViewComplaint.aspx' title='View Complaint'>&nbsp;&nbsp;View Complaint</a>";
            mMenu = mMenu + "<a href='UpdateStatus.aspx' title='Update Status'>&nbsp;&nbsp;Update Status</a>";
            mMenu = mMenu + "<a href='Search.aspx' title='Search'>&nbsp;&nbsp;Search</a>";
            mMenu = mMenu + "<a href='ChangePassword.aspx' title='Change Password'>&nbsp;&nbsp;Change Password</a>";
            mMenu = mMenu + "<a href='Logout.aspx' title='Logout'>&nbsp;&nbsp;Logout</a>";
        }
        else if (usertype == "Citizen")
        {
            mMenu = mMenu + "<a href='Default.aspx' title='Home'>&nbsp;&nbsp;Home</a>";
            mMenu = mMenu + "<a href='LogComplaint.aspx' title='Log Complaint'>&nbsp;&nbsp;Log Complaint</a>";
            mMenu = mMenu + "<a href='ViewStatus.aspx' title='View Status'>&nbsp;&nbsp;View Status</a>";
            mMenu = mMenu + "<a href='ViewComplaint.aspx' title='Complaint History'>&nbsp;&nbsp;Complaint History</a>";
            mMenu = mMenu + "<a href='ManageMissingCitizen.aspx' title='View Missing Citizen'>&nbsp;&nbsp;View Missing Citizen</a>";
            mMenu = mMenu + "<a href='ChangePassword.aspx' title='Change Password'>&nbsp;&nbsp;Change Password</a>";
            mMenu = mMenu + "<a href='Logout.aspx' title='Logout'>&nbsp;&nbsp;Logout</a>";
        }
        else
        {
            mMenu = mMenu + "<a href='Default.aspx' title='Home'>&nbsp;&nbsp;Home</a>";
            mMenu = mMenu + "<a href='Login.aspx' title='Login'>&nbsp;&nbsp;Login</a>";
        }

        return mMenu;
    }

    public static System.Data.SqlClient.SqlConnection OpenConn(System.Data.SqlClient.SqlConnection oCn)
    {
        string connStr = ConfigurationManager.AppSettings["ConnInfo"];
        oCn.ConnectionString = connStr;
        if (oCn.State == ConnectionState.Closed)
        {
            oCn.Open();
        }
        return oCn;
    }

    public static int iUserId()
    {
        HttpCookie ckUid = HttpContext.Current.Request.Cookies["ckUserID"];
        int mId = 0;
        if (ckUid != null)
            mId = Convert.ToInt16(ckUid.Value.ToString());

        return mId;
    }

    public static String sUserName()
    {
        HttpCookie ck = HttpContext.Current.Request.Cookies["ckUserName"];
        String mId = "";
        if (ck != null)
            mId = ck.Value.ToString();

        return mId;
    }

    public static String sUserType()
    {
        HttpCookie ck = HttpContext.Current.Request.Cookies["ckUserType"];
        String mId = "";
        if (ck != null)
            mId = ck.Value.ToString();

        return mId;
    }

    public static String sUserLocation()
    {
        HttpCookie ck = HttpContext.Current.Request.Cookies["ckUserLocation"];
        String mId = "";
        if (ck != null)
            mId = ck.Value.ToString();

        return mId;
    }

    public static string SendMail(String FromId, String ToId, String Sub, String Body)
    {
        try
        {
            MailMessage MailMsg = new MailMessage(new MailAddress("a.epmo@yahoo.com"), new MailAddress("xyz@abc.com"));
            MailMsg.To.Clear();
            String a = ",";
            char mc = a[0];
            String[] mTo = ToId.ToString().Split(mc);
            for (int i = 0; i <= mTo.Length - 1; i++)
            {
                if (mTo[i].ToString() != "")
                    MailMsg.To.Add(mTo[i]);
            }

            MailMsg.Subject = Sub;
            MailMsg.Body = Body;
            MailMsg.Priority = MailPriority.Normal;
            MailMsg.IsBodyHtml = true;

            //'Smtpclient to send the mail message
            SmtpClient SmtpMail = new SmtpClient();
            SmtpMail.Host = "smtp.mail.yahoo.com";
            SmtpMail.Port = 25;
            SmtpMail.Credentials = new System.Net.NetworkCredential("a.epmo@yahoo.com", "abcd123");
            SmtpMail.Send(MailMsg);
            return "OK";
        }
        catch (Exception ex)
        {
            return "ERR";
        }
    }
}

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
using System.Data.SqlClient;

public partial class ViewReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblCurDate.InnerHtml = String.Format("{0:dd MMMM, yyyy}", DateTime.Now);
        mainlogo.InnerHtml = Class1.LogoText;
        title.InnerHtml = Class1.MainHeaderText;
        // --> Checking Cookie
        HttpCookie ckType = HttpContext.Current.Request.Cookies["ckUserType"];
        String UserType = "";
        if (ckType != null)
            UserType = ckType.Value.ToString();
        linksmenu.InnerHtml = Class1.CreateMenu(UserType);
        HttpCookie ckName = HttpContext.Current.Request.Cookies["ckUserName"];
        String UserName = "";
        if (ckName != null && ckName.Value.ToString() != "")
            UserName = ckName.Value.ToString() + "." + " (" + ckType.Value.ToString() + ")";
        lblusername.InnerHtml = UserName;
        footer.InnerHtml = Class1.FooterText;
        if (Class1.sUserName() == "")
            Response.Redirect("Login.aspx");

        bool bValue = true;
        String StrSql = "select EntryBy,FirType,LastStatusUpdStatus,count(*) as FirCount from FirLogDetails group by EntryBy,FirType,LastStatusUpdStatus";
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlCommand Cmd = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        String Data = "";
        Data = Data + "<table style='background-color:#f8f8ff;' width='100%'>";
        Data = Data + "<tr>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Username</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Fir Type</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Fir Status</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Fir Count</td>";
        Data = Data + "</tr>";
        while (Dr.Read())
        {
            if (bValue == true)
            {
                Data = Data + "<tr><td colspan='4' class='gridhead' style='background-color:#EEEEEE;'></td></tr>";
                Data = Data + "<tr><td colspan='4' class='gridhead' style='background-color:#EEEEEE;'>Fir Details</td></tr>";
                bValue = false;
            }
            Data = Data + "<tr>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[0].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[1].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[2].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[3].ToString() + "</td>";
            Data = Data + "</tr>";
        }
        Dr.Close();
        Cmd.Dispose();

        bValue = true;
        StrSql = "select CreatedBy,FirType,LastStatus,count(*) as FirCount from MissingCitizenMaster group by CreatedBy,FirType,LastStatus";
        SqlCommand Cmd1 = new SqlCommand(StrSql, Cn);
        Dr = Cmd1.ExecuteReader();
        while (Dr.Read())
        {
            if (bValue == true)
            {
                Data = Data + "<tr><td colspan='4' class='gridhead' style='background-color:#EEEEEE;'></td></tr>";
                Data = Data + "<tr><td colspan='4' class='gridhead' style='background-color:#EEEEEE;'>Missing Citizen Details</td></tr>";
                bValue = false;
            }
            Data = Data + "<tr>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[0].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>Missing Citizen</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[2].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[3].ToString() + "</td>";
            Data = Data + "</tr>";
        }
        Dr.Close();
        Cmd1.Dispose();

        bValue = true;
        StrSql = "select CreatedBy,FirType,LastStatus,count(*) as FirCount from FoundCitizenMaster group by CreatedBy,FirType,LastStatus";
        SqlCommand Cmd2 = new SqlCommand(StrSql, Cn);
        Dr = Cmd2.ExecuteReader();
        while (Dr.Read())
        {
            if (bValue == true)
            {
                Data = Data + "<tr><td colspan='4' class='gridhead' style='background-color:#EEEEEE;'></td></tr>";
                Data = Data + "<tr><td colspan='4' class='gridhead' style='background-color:#EEEEEE;'>Founded Citizen Details</td></tr>";
                bValue = false;
            }
            Data = Data + "<tr>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[0].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>Found Citizen</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[2].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr[3].ToString() + "</td>";
            Data = Data + "</tr>";
        }
        Dr.Close();
        Cmd2.Dispose();

        Data = Data + "</table>";
        tbData.InnerHtml = Data;

    }
}

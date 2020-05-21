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

public partial class ManageMissingCitizen : System.Web.UI.Page
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

        if (Class1.sUserType().ToString() == "Citizen")
            lnkAddnew.Visible = false;
        String StrSql = "Select *,m.FName+' '+m.LName as CName from MissingCitizenMaster m, UserMaster u where m.CreatedById = u.UID order by UserType,m.FName";
        if (Class1.sUserType().ToString() == "Citizen")
            StrSql = "Select *,m.FName+' '+m.LName as CName from MissingCitizenMaster m, UserMaster u where m.CreatedById = u.UID and u.UID = " + Convert.ToInt16(Class1.iUserId().ToString()) + " order by UserType,m.FName";
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlCommand Cmd = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        String Data = "";
        Data = Data + "<table style='background-color:#f8f8ff;' width='100%'>";
        Data = Data + "<tr>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Citizen Name</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Entry By</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Mobile No</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Status</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Profile</td>";
        Data = Data + "</tr>";
        while (Dr.Read())
        {
            Data = Data + "<tr>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["CName"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["UserType"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["MobileNo"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["LastStatus"].ToString() + "</td>";
            if (Class1.sUserType().ToString() == "Citizen")
                Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'><a class='gridlink' href='ViewMissing.aspx?fcid=0&mid=" + Dr["MID"].ToString() + "'>View</a></td>";
            else
                Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'><a class='gridlink' href='ViewMissing.aspx?fcid=0&mid=" + Dr["MID"].ToString() + "'>View</a><span style='color:#339933'>|</span><a class='gridlink' href='LogMissing.aspx?type=citi&tag=edit&mid=" + Dr["MID"].ToString() + "'>Edit</a></td>";
            Data = Data + "</tr>";
        }
        Dr.Close();
        Cmd.Dispose();

        StrSql = "Select *,m.FName+' '+m.LName as CName from FoundCitizenMaster m, UserMaster u where m.CreatedById = u.UID order by UserType,m.FName";
        SqlCommand Cmd1 = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr1 = Cmd1.ExecuteReader();
        while (Dr1.Read())
        {
            Data = Data + "<tr>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr1["CName"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr1["UserType"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr1["MobileNo"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr1["LastStatus"].ToString() + "</td>";
            if (Class1.sUserType().ToString() == "Citizen")
                Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'><a class='gridlink' href='ViewMissing.aspx?mid=0&fcid=" + Dr1["FCID"].ToString() + "'>View</a></td>";
            else
                Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'><a class='gridlink' href='ViewMissing.aspx?mid=0&fcid=" + Dr1["FCID"].ToString() + "'>View</a><span style='color:#339933'>|</span><a class='gridlink' href='LogMissing.aspx?type=dept&tag=edit&mid=" + Dr1["FCID"].ToString() + "'>Edit</a></td>";
            Data = Data + "</tr>";
        }
        Dr1.Close();
        Cmd1.Dispose();
        Data = Data + "</table>"; 
        tbData.InnerHtml = Data;
    }
}

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

public partial class ManageUser : System.Web.UI.Page
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

        if (Class1.sUserType().ToString() == "Department")
            lblNewDept.Visible = false;
        String StrSql = "Select * from UserMaster where UserType <> 'Administrator' order by UserType desc,FName";
        if (ckType.Value.ToString() == "Administrator")
            StrSql = "Select * from UserMaster order by FName";
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlCommand Cmd = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        String Data = "";
        Data = Data + "<table style='background-color:#f8f8ff;' width='100%'>";
        Data = Data + "<tr>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Username</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>User Type</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Email Id</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Mobile No</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Profile</td>";
        Data = Data + "</tr>";
        while (Dr.Read())
        {
            Data = Data + "<tr>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["FName"].ToString() + " " + Dr["LName"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["UserType"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["EmailId"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["MobileNo"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'><a class='gridlink' href='UserRegistration.aspx?type=na&tag=view&id=" + Dr["UID"].ToString() + "'>View</a><span style='color:#339933'>|</span><a class='gridlink' href='UserRegistration.aspx?type=na&tag=edit&id=" + Dr["UID"].ToString() + "'>Edit</a></td>";
            Data = Data + "</tr>";
        }
        Data = Data + "</table>";
        Dr.Close();
        Cmd.Dispose();
        tbData.InnerHtml = Data;
    }
}

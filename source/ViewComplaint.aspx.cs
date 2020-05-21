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

public partial class ViewComplaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == true) return;
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

        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        String StrSql = "Select * from LocationMaster order by Location";
        SqlCommand Cmd2 = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr = Cmd2.ExecuteReader();
        ddlLocation.Items.Clear();
        ddlLocation.Items.Add("-- All --");
        while (Dr.Read())
        {
            ddlLocation.Items.Add(Dr["Location"].ToString());
        }
        Dr.Close();
        Cmd2.Dispose();
        ddlLocation.Text  = Class1.sUserLocation().ToString();

        DisplayData(Class1.sUserType());
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayData(Class1.sUserType());
    }

    protected void DisplayData(String UType)
    {
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        HttpCookie ckType = HttpContext.Current.Request.Cookies["ckUserType"];
        String StrSql = "Select * from FirLogDetails where EntryById = " + Class1.iUserId() + " order by EntryDate desc";
        if (UType.ToString() == "Administrator" || UType.ToString() == "Department")
            if (ddlLocation.SelectedIndex == 0)
                StrSql = "Select * from FirLogDetails order by EntryDate desc";
            else
                StrSql = "Select * from FirLogDetails where Location = '" + ddlLocation.SelectedItem.Text.ToString() + "' order by EntryDate desc";
        SqlCommand Cmd = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        String Data = "";
        Data = Data + "<table style='background-color:#f8f8ff;' width='100%'>";
        Data = Data + "<tr>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Id</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Type</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Date</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Complaint By</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Status</td>";
        Data = Data + "<td class='gridhead' style='background-color:#EEEEEE;'>Complaint</td>";
        Data = Data + "</tr>";
        while (Dr.Read())
        {
            Data = Data + "<tr>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["LID"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["FirType"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["EntryDate"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["EntryBy"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr["LastStatusUpdStatus"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'><a class='gridlink' href='ComplaintFir.aspx?tag=view&fid=0&lid=" + Dr["LID"].ToString() + "'>View</a></td>";
            Data = Data + "</tr>";
        }
        Dr.Close();
        Cmd.Dispose();

        StrSql = "Select * from MissingCitizenMaster where CreatedById = " + Class1.iUserId() + " order by CreatedDate desc";
        if (UType.ToString() == "Administrator" || UType.ToString() == "Department")
            if (ddlLocation.SelectedIndex == 0)
                StrSql = "Select * from MissingCitizenMaster where CreatedById in (select UID from UserMaster where UserType = 'Citizen') order by CreatedDate desc";
            else
                StrSql = "Select * from MissingCitizenMaster where Location = '" + ddlLocation.Text + "' and CreatedById in (select UID from UserMaster where UserType = 'Citizen') order by CreatedDate desc";
        SqlCommand Cmd1 = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr1 = Cmd1.ExecuteReader();
        while (Dr1.Read())
        {
            Data = Data + "<tr>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr1["MID"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>Missing Citizen</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr1["CreatedDate"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr1["CreatedBy"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'>" + Dr1["LastStatus"].ToString() + "</td>";
            Data = Data + "<td class='griddata' style='background-color:#EEEEEE;'><a class='gridlink' href='ViewMissing.aspx?fcid=0&mid=" + Dr1["MID"].ToString() + "'>View</a></td>";
            Data = Data + "</tr>";
        }
        Dr1.Close();
        Cmd1.Dispose();
        Data = Data + "</table>";

        tbData.InnerHtml = Data;
    }
}

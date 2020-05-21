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

public partial class Search : System.Web.UI.Page
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
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false) return;
        if (ddlFirType.SelectedIndex == 0)
        {
            lblMessage.InnerHtml = "Select complaint type !!!";
            lblMessage.Visible = true;
            return;
        }

        String StrSql = "";
        String Str = "";
        if (ddlFirType.SelectedItem.Text == "Complaint")
        {
            StrSql = "select * from FirLogDetails where LID = " + Convert.ToInt16(txtComplaintNo.Text.ToString());
            Str = "ComplaintFir.aspx?tag=view&fid=0&lid=" + txtComplaintNo.Text.ToString();
        }
        else
        {
            StrSql = "select * from MissingCitizenMaster where MID = " + Convert.ToInt16(txtComplaintNo.Text.ToString());
            Str = "ViewMissing.aspx?fcid=0&mid=" + txtComplaintNo.Text.ToString();
        }

        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlCommand Cmd = new SqlCommand(StrSql, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            Dr.Close();
            Cmd.Dispose();
            Response.Redirect(Str);
        }
        else
        {
            Dr.Close();
            Cmd.Dispose();
            lblMessage.InnerHtml = "Complaint number not found !!!";
            lblMessage.Visible = true;
        }
    }
}

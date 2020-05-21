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

public partial class ChangePassword : System.Web.UI.Page
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
        if (txtNewPassword.Text != txtConfirmPassword.Text)
        {
            lblMessage.InnerHtml = "New password and confirm password not match !!!";
            lblMessage.Visible = true;
            return;
        }

        lblMessage.Visible = false;
        bool chkValid = false;
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlCommand Cmd = new SqlCommand("Select * from UserMaster where UID = " + Class1.iUserId() , Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            if (Dr["Password"].ToString() == txtOldPassword.Text.ToString())
                chkValid = true;
        }
        Dr.Close();
        Cmd.Dispose();

        if (chkValid)
        {
            SqlCommand Cmd1 = new SqlCommand("Update UserMaster set Password = '" + txtNewPassword.Text.ToString() + "' where UID = " + Class1.iUserId(), Cn);
            Cmd1.ExecuteNonQuery();
            Cmd1.Dispose();

            lblMessage.InnerHtml = "Password change successfully.";
            lblMessage.Visible = true;
        }
        else
        {
            lblMessage.InnerHtml = "Invalid password !!!";
            lblMessage.Visible = true;
        }
    }
}

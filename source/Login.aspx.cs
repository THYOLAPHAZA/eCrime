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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblCurDate.InnerHtml = String.Format("{0:dd MMMM, yyyy}", DateTime.Now);
        mainlogo.InnerHtml = Class1.LogoText;
        title.InnerHtml = Class1.MainHeaderText;
        linksmenu.InnerHtml = Class1.CreateMenu("");
        footer.InnerHtml = Class1.FooterText;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false) return;

        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlCommand Cmd = new SqlCommand("Select * from UserMaster where EmailId = '" + txtUsername.Text.ToString() + "'", Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            if (Dr["Password"].ToString() == txtPassword.Text.ToString())
            {
                // --> Create Cookie for User
                HttpCookie ckId = new HttpCookie("ckUserID");
                ckId.Value = Dr["UID"].ToString();
                Response.Cookies.Add(ckId);

                HttpCookie ckName = new HttpCookie("ckUserName");
                ckName.Value = Dr["FName"].ToString() + " " + Dr["LName"].ToString();
                Response.Cookies.Add(ckName);

                HttpCookie ckType = new HttpCookie("ckUserType");
                ckType.Value = Dr["UserType"].ToString();
                Response.Cookies.Add(ckType);

                HttpCookie ckLocation = new HttpCookie("ckUserLocation");
                ckLocation.Value = Dr["Location"].ToString();
                Response.Cookies.Add(ckLocation);

                HttpCookie ckF = new HttpCookie("ckFirst");
                ckF.Value = "YES";
                Response.Cookies.Add(ckF);

                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.InnerHtml = "Invalid password !!!";
                lblMessage.Visible = true;
            }
        }
        else
        {
            lblMessage.InnerHtml = "Invalid username !!!";
            lblMessage.Visible = true;
        }
    }
}

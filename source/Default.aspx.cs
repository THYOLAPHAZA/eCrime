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

public partial class _Default : System.Web.UI.Page
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
        HttpCookie ckFirst = HttpContext.Current.Request.Cookies["ckFirst"];
        if (ckName != null && ckName.Value.ToString() != "")
            if (ckFirst.Value.ToString() == "YES")
                UserName = "welcome, " + ckName.Value.ToString() + ". (" + ckType.Value.ToString() + ")";
            else
                UserName = ckName.Value.ToString() + ". (" + ckType.Value.ToString() + ")";
        lblusername.InnerHtml = UserName;
        footer.InnerHtml = Class1.FooterText;

        HttpCookie ckF = new HttpCookie("ckFirst");
        ckF.Value = "No";
        Response.Cookies.Add(ckF);
    }
}

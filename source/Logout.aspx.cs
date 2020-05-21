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

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // --> Clear Cookie
        HttpCookie ckId = Request.Cookies["ckUserID"];
        ckId.Value = "";
        Response.Cookies.Add(ckId);

        HttpCookie ckName = Request.Cookies["ckUserName"];
        ckName.Value = "";
        Response.Cookies.Add(ckName);

        HttpCookie ckType = Request.Cookies["ckUserType"];
        ckType.Value = "";
        Response.Cookies.Add(ckType);

        HttpCookie ckLocation = Request.Cookies["ckUserLocation"];
        ckLocation.Value = "";
        Response.Cookies.Add(ckLocation);

        Response.Redirect("Default.aspx");
    }
}

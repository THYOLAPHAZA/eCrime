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

public partial class LogComplaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (this.IsPostBack == true) return;
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
        SqlCommand Cmd = new SqlCommand("Select * from FirMaster order by FirType", Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        ddlComplaintType.Items.Clear();
        ListItem mLstItem1 = new ListItem("-- Select --","");
        ddlComplaintType.Items.Add(mLstItem1);
        ListItem mLstItem2 = new ListItem("Missing", "Missing");
        ddlComplaintType.Items.Add(mLstItem2);
        while (Dr.Read())
        {
            ListItem mLstItem = new ListItem();
            mLstItem.Value = Dr["FirID"].ToString(); mLstItem.Text = Dr["FirType"].ToString();
            ddlComplaintType.Items.Add(mLstItem);
        }
        Dr.Close();
        Cmd.Dispose();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        if (ddlComplaintType.SelectedValue.ToString() == "")
        {
            lblMessage.InnerHtml = "Select Option from the list for Complaint type.";
            lblMessage.Visible = true;
        }
        else if (ddlComplaintType.SelectedValue.ToString() == "Missing")
            Response.Redirect("LogMissing.aspx?type=citi&tag=edit&mid=0");
        else
            Response.Redirect("ComplaintFir.aspx?tag=edit&lid=0&fid="+ ddlComplaintType.SelectedValue.ToString());
    }
}

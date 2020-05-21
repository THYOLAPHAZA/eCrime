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

public partial class UserRegistration : System.Web.UI.Page
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

        int mUserId = 0;
        if (Request.QueryString["id"].ToString() != "")
            mUserId = Convert.ToInt16(Request.QueryString["id"].ToString());
        lblUserId.InnerText = mUserId.ToString();

        if (Request.QueryString["type"].ToString() == "dept")
        {
            lblUserType.InnerHtml = "Department";
            lblHead.InnerHtml = "Department Registration";
        }
        else
        {
            lblUserType.InnerHtml = "Citizen";
            lblHead.InnerHtml = "Citizen Registration";
        }

        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);

        SqlCommand Cmd1 = new SqlCommand("Select Location from LocationMaster order by Location", Cn);
        SqlDataReader Dr = Cmd1.ExecuteReader();
        ddlLocation.Items.Clear();
        ddlLocation.Items.Add("-- Select --");
        while (Dr.Read())
        {
            ddlLocation.Items.Add(Dr["Location"].ToString());
        }
        Dr.Close();
        Cmd1.Dispose();


        SqlCommand Cmd = new SqlCommand("Select * from UserMaster where UID = " + mUserId, Cn);
        Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            txtFName.Text = Dr["FName"].ToString();
            txtMName.Text = Dr["MName"].ToString();
            txtLName.Text = Dr["LName"].ToString();
            txtMobileNo.Text = Dr["MobileNo"].ToString();
            txtResiNo.Text = Dr["ResiNo"].ToString();
            txtEmailId.Text = Dr["EmailId"].ToString();
            txtBirthDate.Text = Dr["DOB"].ToString();
            txtDetails.Text = Dr["Details"].ToString();
            ddlLocation.SelectedValue = Dr["Location"].ToString();
            if (Dr["PhotoName"].ToString() != "")
                imgPhoto.ImageUrl = ("photos/User/" + Dr["PhotoName"].ToString());
        }
        Dr.Close();
        Cmd.Dispose();
        if (Request.QueryString["tag"].ToString() == "view")
            btnSubmit.Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        if (Page.IsValid == false) return;
        if (ddlLocation.SelectedIndex == 0)
        {
            lblMessage.InnerHtml = "Select Location from the List";
            lblMessage.Visible = true;
            return;
        }

        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);

        int mUserId = Convert.ToInt16(lblUserId.InnerText.ToString());
        if (mUserId == 0)
        {
            String strR = "";
            SqlCommand Cmd = new SqlCommand("Select Max(UID) from UserMaster", Cn);
            strR = Cmd.ExecuteScalar().ToString();
            if (strR != "")
                mUserId = Convert.ToInt16(strR);
            mUserId = mUserId + 1;
        }

        SqlDataAdapter Da = new SqlDataAdapter("Select * from UserMaster where UID = " + mUserId, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        DataTable Ds = new DataTable();
        DataRow r;
        Da.Fill(Ds);

        if (Convert.ToInt16(lblUserId.InnerText.ToString()) == 0)
        {
            r = Ds.NewRow();
            r["UID"] = mUserId;
            r["CreatedBy"] = Class1.sUserName();
            r["CreatedDate"] = DateTime.Now;
            r["Password"] = "123";
        }
        else
            r = Ds.Rows[0];
        r["FName"] = txtFName.Text.ToString();
        r["MName"] = txtMName.Text.ToString();
        r["LName"] = txtLName.Text.ToString();
        r["MobileNo"] = txtMobileNo.Text.ToString();
        r["ResiNo"] = txtResiNo.Text.ToString();
        r["EmailId"] = txtEmailId.Text.ToString();
        if (txtBirthDate.Text.ToString() != "")
            r["DOB"] = Convert.ToDateTime(txtBirthDate.Text.ToString());
        r["UserType"] = lblUserType.InnerHtml.ToString();
        r["Details"] = txtDetails.Text.ToString();
        r["Location"] = ddlLocation.SelectedItem.Text.ToString();
        if (Fupd.FileName.ToString() != "")
        {
            r["PhotoName"] = mUserId + Fupd.FileName.ToString();
            Fupd.SaveAs(Server.MapPath ("~/") + "photos/User/" + mUserId.ToString() + Fupd.FileName.ToString());
        }

        if (Convert.ToInt16(lblUserId.InnerText.ToString()) == 0)
            Ds.Rows.Add(r);
        Da.Update(Ds);
        Da.Dispose();
        Cb.Dispose();
        Ds.Dispose();

        Response.Redirect("ManageUser.aspx");
    }
}

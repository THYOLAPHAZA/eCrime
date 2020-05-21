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

public partial class ViewMissing : System.Web.UI.Page
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

        int mId = 0;
        int mFCid = 0;
        mId = Convert.ToInt16(Request.QueryString["mid"].ToString());
        mFCid = Convert.ToInt16(Request.QueryString["fcid"].ToString());
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlCommand Cmd = new SqlCommand("Select * from MissingCitizenMaster where MID = " + mId, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            lblFName.Text = Dr["FName"].ToString();
            lblMName.Text = Dr["MName"].ToString();
            lblLName.Text = Dr["LName"].ToString();
            lblMobileNo.Text = Dr["MobileNo"].ToString();
            lblResiNo.Text = Dr["ResiNo"].ToString();
            lblAddress.Text = Dr["Address"].ToString();
            lblBirthDate.Text = Dr["DOB"].ToString();
            txtDetails.Text = Dr["Details"].ToString();
            if (Dr["Photo"].ToString() != "")
                imgPhoto.ImageUrl = ("photos\\Citizen\\" + Dr["Photo"].ToString());
            lblComplaintLocation.Text = Dr["Location"].ToString();
            lblLastStatus.InnerHtml = Dr["LastStatus"].ToString();
            lblStatusUpdBy.InnerHtml = Dr["LastStatusUpdBy"].ToString();
            lblStatusUpdDate.InnerHtml = Dr["LastStatusUpdDate"].ToString();
            mFCid = Convert.ToInt16(Dr["PID"].ToString());
        }
        Dr.Close();
        Cmd.Dispose();

        SqlCommand Cmd1 = new SqlCommand("Select * from FoundCitizenMaster where FCID = " + mFCid, Cn);
        Dr = Cmd1.ExecuteReader();
        if (Dr.Read())
        {
            if (mId == 0)
            {
                lblFName.Text = Dr["FName"].ToString();
                lblMName.Text = Dr["MName"].ToString();
                lblLName.Text = Dr["LName"].ToString();
                lblMobileNo.Text = Dr["MobileNo"].ToString();
                lblResiNo.Text = Dr["ResiNo"].ToString();
                lblAddress.Text = Dr["Address"].ToString();
                lblBirthDate.Text = Dr["DOB"].ToString();
                txtDetails.Text = Dr["Details"].ToString();
                lblFoundLocation.Text = Dr["Location"].ToString();
                if (Dr["Photo"].ToString() != "")
                    imgFCPhoto.ImageUrl = ("photos\\Citizen\\" + Dr["Photo"].ToString());
            }
        }
        Dr.Close();
        Cmd1.Dispose();

        if (mId > 0)
        {
            SqlCommand Cmd2 = new SqlCommand("Select * from PhysicalApperanceMaster where MID = " + mId, Cn);
            Dr = Cmd2.ExecuteReader();
            if (Dr.Read())
            {
                lblSkinColor.Text = Dr["SkinColor"].ToString();
                lblHairColor.Text = Dr["HairColor"].ToString();
                lblHeight.Text = Dr["Height"].ToString();
                lblWeight.Text = Dr["Weight"].ToString();
                lblScars.Text = Dr["Scars"].ToString();
                lblPhyDeformity.Text = Dr["PhysicalDeformity"].ToString();
                if (Dr["Photo"].ToString() != "")
                    imgFCPhoto.ImageUrl = ("photos/Citizen/" + Dr["Photo"].ToString());
            }
            Dr.Close();
            Cmd1.Dispose();
        }
    }
}

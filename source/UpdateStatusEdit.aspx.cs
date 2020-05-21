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

public partial class UpdateStatusEdit : System.Web.UI.Page
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
        // Filling Criminal Data
        SqlCommand Cmd1 = new SqlCommand("Select * from CriminalMaster order by FName", Cn);
        SqlDataReader Dr1 = Cmd1.ExecuteReader();
        ddlCriminalList.Items.Clear();
        ListItem mLstItem1 = new ListItem("-- Select --", "");
        ddlCriminalList.Items.Add(mLstItem1);
        while (Dr1.Read())
        {
            ListItem mLstItem = new ListItem(Dr1["FName"].ToString() + " " + Dr1["LName"].ToString(), Dr1["CID"].ToString());
            ddlCriminalList.Items.Add(mLstItem);
        }
        Dr1.Dispose();
        Cmd1.Dispose();

        int iFirId = 0;
        lblFirLogId.InnerHtml = Request.QueryString["lid"].ToString();

        SqlDataAdapter Da = new SqlDataAdapter("Select * from FirLogDetails where LID = " + Convert.ToInt16(lblFirLogId.InnerHtml.ToString()), Cn);
        DataTable Dt = new DataTable();
        DataRow r;
        Da.Fill(Dt);
        if (Dt.Rows.Count > 0)
        {
            r = Dt.Rows[0];
            iFirId = Convert.ToInt16(r["FirID"].ToString());
            lblComplaintId.InnerHtml = r["LID"].ToString();
            lblComplaintBy.InnerHtml = r["EntryBy"].ToString();
            lblComplaintDate.InnerHtml = r["EntryDate"].ToString();
            lblAns1.Text = r["Q1Ans"].ToString();
            lblAns2.Text = r["Q2Ans"].ToString();
            lblAns3.Text = r["Q3Ans"].ToString();
            lblAns4.Text = r["Q4Ans"].ToString();
            lblAns5.Text = r["Q5Ans"].ToString();
            lblAns6.Text = r["Q6Ans"].ToString();
            lblLastStatus.InnerHtml = r["LastStatusUpdStatus"].ToString();
            lblStatusUpdBy.InnerHtml = r["LastStatusUpdBy"].ToString();
            lblStatusUpdDate.InnerHtml = r["LastStatusUpdDate"].ToString();
        }

        lblFirId.InnerHtml = iFirId.ToString();
        SqlCommand Cmd = new SqlCommand("Select * from FirMaster where FirID = " + iFirId, Cn);
        SqlDataReader Dr = Cmd.ExecuteReader();
        if (Dr.Read())
        {
            lblComplaintType.InnerHtml = Dr["FirType"].ToString();
            if (Dr["Q1"].ToString() != "")
                Q1.InnerHtml = Dr["Q1"].ToString();
            else
            {
                Q1.Visible = false;
                lblAns1.Visible = false;
            }
            if (Dr["Q2"].ToString() != "")
                Q2.InnerHtml = Dr["Q2"].ToString();
            else
            {
                Q2.Visible = false;
                lblAns2.Visible = false;
            }
            if (Dr["Q3"].ToString() != "")
                Q3.InnerHtml = Dr["Q3"].ToString();
            else
            {
                Q3.Visible = false;
                lblAns3.Visible = false;
            }
            if (Dr["Q4"].ToString() != "")
                Q4.InnerHtml = Dr["Q4"].ToString();
            else
            {
                Q4.Visible = false;
                lblAns4.Visible = false;
            }
            if (Dr["Q5"].ToString() != "")
                Q5.InnerHtml = Dr["Q5"].ToString();
            else
            {
                Q5.Visible = false;
                lblAns5.Visible = false;
            }
            if (Dr["Q6"].ToString() != "")
                Q6.InnerHtml = Dr["Q6"].ToString();
            else
            {
                Q6.Visible = false;
                lblAns6.Visible = false;
            }
        }
        ddlFirStatus.SelectedIndex = 0;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int mFirLogId = Convert.ToInt16(lblFirLogId.InnerHtml.ToString());
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);

        int iPid = 0;
        if (ddlCriminalList.SelectedIndex > 0)
        {
            String strR = "";
            SqlCommand Cmd = new SqlCommand("Select max(PID) from PhysicalApperanceMaster", Cn);
            strR = Cmd.ExecuteScalar().ToString();
            if (strR != "")
                iPid = Convert.ToInt16(strR);
            iPid = iPid + 1;
            Cmd.Dispose();

            SqlDataAdapter Da1 = new SqlDataAdapter("Select * from PhysicalApperanceMaster where 1=2", Cn);
            SqlCommandBuilder Cb1 = new SqlCommandBuilder(Da1);
            DataTable Ds1 = new DataTable();
            DataRow r;
            Da1.Fill(Ds1);

            r = Ds1.NewRow();
            r["PID"] = iPid;
            r["CID"] = Convert.ToInt16(lblCriminalId.InnerHtml.ToString());
            r["MID"] = 0;
            r["SkinColor"] = txtSkinColor.Text.ToString();
            r["HairColor"] = txtHairColor.Text.ToString();
            r["Height"] = txtHeight.Text.ToString();
            r["Weight"] = txtWeight.Text.ToString();
            r["Scars"] = txtScars.Text.ToString();
            r["PhysicalDeformity"] = txtPhyDeformity.Text.ToString();
            r["AdditianlDetails"] = txtAddDetails.Text.ToString();
            if (lblPhotoName.InnerHtml.ToString() != "")
                r["Photo"] = lblPhotoName.InnerHtml.ToString();

            r["EntryBy"] = Class1.sUserName();
            r["EntryDate"] = DateTime.Now;
            Ds1.Rows.Add(r);
            Da1.Update(Ds1);
            Da1.Dispose();
            Cb1.Dispose();
            Ds1.Dispose();
        }

        SqlDataAdapter Da = new SqlDataAdapter("Select * from FirLogDetails where LID = " + mFirLogId, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        DataTable Ds = new DataTable();
        DataRow R1;
        Da.Fill(Ds);
        R1 = Ds.Rows[0];
        R1["PID"] = iPid;
        R1["LastStatusUpdBy"] = Class1.sUserName();
        R1["LastStatusUpdDate"] = DateTime.Now;
        R1["LastStatusUpdStatus"] = ddlFirStatus.SelectedValue.ToString();
        Da.Update(Ds);
        Da.Dispose();
        Cb.Dispose();
        Ds.Dispose();

        Response.Redirect("UpdateStatus.aspx");
    }

    protected void ddlFirStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFirStatus.SelectedValue == "Closed")
        {
            if (ddlCriminalList.SelectedIndex != 0)
            {
                lblCriminalId.InnerHtml = ddlCriminalList.SelectedValue.ToString();
                SqlConnection Cn = new SqlConnection();
                Class1.OpenConn(Cn);
                SqlCommand Cmd = new SqlCommand("Select * from CriminalMaster where CID = " + Convert.ToInt16(lblCriminalId.InnerHtml.ToString()), Cn);
                SqlDataReader Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    txtSkinColor.Text = Dr["SkinColor"].ToString();
                    txtHairColor.Text = Dr["HairColor"].ToString();
                    txtHeight.Text = Dr["Height"].ToString();
                    txtWeight.Text = Dr["Weight"].ToString();
                    txtScars.Text = Dr["Scars"].ToString();
                    txtPhyDeformity.Text = Dr["PhysicalDeformity"].ToString();
                    if (Dr["Photo"].ToString() != "")
                        imgPhoto.ImageUrl = ("photos/Dept/" + Dr["Photo"].ToString());
                    lblPhotoName.InnerHtml = Dr["Photo"].ToString();
                }
                Dr.Close();
                Cmd.Dispose();
            }
            else
            {
                txtSkinColor.Text = "";
                txtHairColor.Text = "";
                txtHeight.Text = "";
                txtWeight.Text = "";
                txtScars.Text = "";
                txtPhyDeformity.Text = "";
                imgPhoto.ImageUrl = "~/photos/nopic.jpg";
            }
            trCloseFir.Visible = true;
        }
        else
            trCloseFir.Visible = false;
        btnSubmit.Focus();
    }
}

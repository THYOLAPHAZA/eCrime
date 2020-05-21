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

public partial class ComplaintFir : System.Web.UI.Page
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

        if (Request.QueryString["tag"].ToString() != "edit") btnSubmit.Visible = false;
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        int iFirId = 0;
        lblFirLogId.InnerHtml = Request.QueryString["lid"].ToString();
        if (lblFirLogId.InnerHtml.ToString() == "0")
        {
            iFirId = Convert.ToInt16(Request.QueryString["fid"].ToString());
            lblComplaintId.InnerHtml = "New";
            lblComplaintBy.InnerHtml = Class1.sUserName();
            lblComplaintDate.InnerHtml = DateTime.Now.ToString();
        }

        SqlDataAdapter Da = new SqlDataAdapter("Select * from FirLogDetails where LID = " + Convert.ToInt16(lblFirLogId.InnerHtml.ToString()), Cn);
        DataTable Dt = new DataTable();
        DataRow r;
        Da.Fill(Dt);
        if (Dt.Rows.Count > 0)
        {
            r = Dt.Rows[0];
            iFirId = Convert.ToInt16(r["FirID"].ToString());
            lblComplaintId.InnerHtml = r["LID"].ToString();
            lblComplaintLocation.InnerHtml = r["Location"].ToString();
            lblComplaintBy.InnerHtml = r["EntryBy"].ToString();
            lblComplaintDate.InnerHtml = r["EntryDate"].ToString();
            txtAns1.Text = r["Q1Ans"].ToString();
            txtAns2.Text = r["Q2Ans"].ToString();
            txtAns3.Text = r["Q3Ans"].ToString();
            txtAns4.Text = r["Q4Ans"].ToString();
            txtAns5.Text = r["Q5Ans"].ToString();
            txtAns6.Text = r["Q6Ans"].ToString();
            lblCriminalId.InnerHtml = r["PID"].ToString();
            lblLastStatus.InnerHtml = r["LastStatusUpdStatus"].ToString();
            lblStatusUpdBy.InnerHtml = r["LastStatusUpdBy"].ToString();
            lblStatusUpdDate.InnerHtml = r["LastStatusUpdDate"].ToString();
            lblLastStatus1.Visible = true;
            lblLastStatus.Visible = true;
            lblStatusUpdBy1.Visible = true;
            lblStatusUpdBy.Visible = true;
            lblStatusUpdDate1.Visible = true;
            lblStatusUpdDate.Visible = true;
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
                txtAns1.Visible = false;
            }
            if (Dr["Q2"].ToString() != "")
                Q2.InnerHtml = Dr["Q2"].ToString();
            else
            {
                Q2.Visible = false;
                txtAns2.Visible = false;
            }
            if (Dr["Q3"].ToString() != "")
                Q3.InnerHtml = Dr["Q3"].ToString();
            else
            {
                Q3.Visible = false;
                txtAns3.Visible = false;
            }
            if (Dr["Q4"].ToString() != "")
                Q4.InnerHtml = Dr["Q4"].ToString();
            else
            {
                Q4.Visible = false;
                txtAns4.Visible = false;
            }
            if (Dr["Q5"].ToString() != "")
                Q5.InnerHtml = Dr["Q5"].ToString();
            else
            {
                Q5.Visible = false;
                txtAns5.Visible = false;
            }
            if (Dr["Q6"].ToString() != "")
                Q6.InnerHtml = Dr["Q6"].ToString();
            else
            {
                Q6.Visible = false;
                txtAns6.Visible = false;
            }
        }
        Dr.Close();
        Cmd.Dispose();

        int mPid = 0;
        if (lblCriminalId.InnerHtml.ToString() != "")
            mPid = Convert.ToInt16(lblCriminalId.InnerHtml.ToString());
        SqlCommand Cmd5 = new SqlCommand("Select * from PhysicalApperanceMaster where PID = " + mPid, Cn);
        SqlDataReader Dr5 = Cmd5.ExecuteReader();
        if (Dr5.Read())
        {
            lblSkinColor.Text = Dr5["SkinColor"].ToString();
            lblHairColor.Text = Dr5["HairColor"].ToString();
            lblHeight.Text = Dr5["Height"].ToString();
            lblWeight.Text = Dr5["Weight"].ToString();
            lblScars.Text = Dr5["Scars"].ToString();
            lblPhyDeformity.Text = Dr5["PhysicalDeformity"].ToString();
            lblAddDetails.Text = Dr5["AdditianlDetails"].ToString();
            if (Dr5["Photo"].ToString() != "")
                imgPhoto.ImageUrl = ("photos/Dept/" + Dr5["Photo"].ToString());
            trCloseFir.Visible = true;
        }
        Dr5.Close();
        Cmd5.Dispose();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int mFirLogId = Convert.ToInt16(lblFirLogId.InnerHtml.ToString());
        SqlConnection Cn = new SqlConnection();
        Class1.OpenConn(Cn);
        SqlDataAdapter Da = new SqlDataAdapter("Select * from FirLogDetails where LID = " + mFirLogId, Cn);
        SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
        DataTable Ds = new DataTable();
        DataRow r;
        Da.Fill(Ds);

        if (mFirLogId == 0)
        {
            r = Ds.NewRow();
            r["EntryById"] = Class1.iUserId();
            r["EntryBy"] = Class1.sUserName();
            r["EntryDate"] = DateTime.Now;
            r["LastStatusUpdStatus"] = "New";
            r["Location"] = Class1.sUserLocation();
        }
        else
            r = Ds.Rows[0];

        r["FirType"] = lblComplaintType.InnerHtml.ToString();
        r["FirID"] = lblFirId.InnerHtml.ToString();
        r["Q1Ans"] = txtAns1.Text.ToString();
        r["Q2Ans"] = txtAns2.Text.ToString();
        r["Q3Ans"] = txtAns3.Text.ToString();
        r["Q4Ans"] = txtAns4.Text.ToString();
        r["Q5Ans"] = txtAns5.Text.ToString();
        r["Q6Ans"] = txtAns6.Text.ToString();
        if (mFirLogId == 0)
            Ds.Rows.Add(r);

        Da.Update(Ds);
        Da.Dispose();
        Cb.Dispose();
        Ds.Dispose();



        SqlCommand com1=new SqlCommand("select emailid from usermaster where uid=" + Class1.iUserId(),Cn);


        //send email
        String StrTo = "";
        StrTo = com1.ExecuteScalar().ToString();
        string strbody = Class1.sUserName() + ", your fir is registerd.";
        String Ans = Class1.SendMail(StrTo, StrTo, "FIR", strbody);
        if (Ans == "OK")
        {
            //Class1.CreateMessageAlert(this, "Password send sucessfuly.", "123");

        }
        else
        {
            //ClsMain.CreateMessageAlert(this, "Unbale to send password this time.", "123");
            //return;

        }


        Response.Redirect("ViewComplaint.aspx");
    }
}

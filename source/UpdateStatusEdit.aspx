<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateStatusEdit.aspx.cs" Inherits="UpdateStatusEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta name="author" content="Wink Hosting (www.winkhosting.com)" />
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
	<link rel="stylesheet" href="css/style.css" type="text/css" />
	<title>eCrime</title>

</head>
<body>
<form id="form1" runat="server">
	<div id="page" align="center">
		<div id="toppage">
			<div id="date">
				<div class="smalltext" style="padding:13px;"><strong><span id="lblCurDate" runat="server"></span></strong></div>
			</div>
			<div id="topbar">
				<div style="padding:12px; float:right;" class="smallwhitetext"><a href="Default.aspx">Home</a> | <a href="Sitemap.aspx">Sitemap</a> | <a href="ContactUs.aspx">Contact Us</a></div>
			</div>
		</div>
		<div id="header">
			<div class="titletext" id="logo">
				<div id="mainlogo" class="logotext" style="margin:30px;" runat="server"></div> <%--<img alt="eCrime" src="images/logo.jpg" style="height: 110px; width: 190px;" />--%>
			</div>
			<div id="pagetitle"><div style="height:15px;"><marquee style="font-family:Tahoma; font-size:10px;" scrolldelay="100">Welcome to Online Crime Reporting System.</marquee></div>
				<div id="title" class="titletext" runat="server"></div>
				<div id="lblusername" runat="server"><span class="lbl">Username</span></div>
			</div>
		</div>
		<div style="clear:both;"></div>
		<div id="content">
			<div id="menu">
				<div style="width:189px; height:8px; float:right;"><img src="images/mnu_topshadow.gif" width="189" height="8" alt="mnutopshadow" /></div>
				<div id="linksmenu" runat="server">

				</div>
				<div style="width:189px; height:8px; float:right;"><img src="images/mnu_bottomshadow.gif" width="189" height="8" alt="mnubottomshadow" /></div>
			</div>
		    <div id="contenttext">
			    <div class="panel">
				    <div style="float:left;">
				        <span class="orangetitle">Complaint Details:</span><span id="lblFirId" runat="server" visible="false"></span>
				        <div style="float:right;">
				            <span id="lblFirLogId" runat="server" visible="false"></span><br /><br />
				        </div>
				        <div style="padding-left:50px;">
			                <table>
			                    <tr><td style="height:10px; width: 128px;"></td></tr>
			                    <tr>
			                        <td style="text-align:left; width: 128px;"><span class="lbl">Complaint No. :</span></td>
			                        <td style="text-align:left; width:300px;"><span class="lbl" id="lblComplaintId" runat="server">No.</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; width: 128px;"><span class="lbl">Complaint Type :</span></td>
			                        <td style="text-align:left"><span class="lbl" id="lblComplaintType" runat="server">Complaint</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; width: 128px;"><span class="lbl">Complaint By :</span></td>
			                        <td style="text-align:left"><span class="lbl" id="lblComplaintBy" runat="server">Citizen</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900; padding-bottom:5px; width: 128px;"><span class="lbl">Complaint Date :</span></td>
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900; padding-bottom:5px;"><span class="lbl" id="lblComplaintDate" runat="server">Date</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2"><span id = "Q1" class="lbl" runat="server">Q1 :</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2">
                                        <asp:Label ID="lblAns1" runat="server" CssClass="lbl" Text="" Width="450px"></asp:Label></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2"><span id = "Q2" class="lbl" runat="server">Q2 :</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2">
                                        <asp:Label ID="lblAns2" runat="server" CssClass="lbl" Text="" Width="450px"></asp:Label></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2"><span id = "Q3" class="lbl" runat="server">Q3 :</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2">
                                        <asp:Label ID="lblAns3" runat="server" CssClass="lbl" Text="" Width="450px"></asp:Label></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2"><span id = "Q4" class="lbl" runat="server">Q4 :</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2">
                                        <asp:Label ID="lblAns4" runat="server" CssClass="lbl" Text="" Width="450px"></asp:Label></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2"><span id = "Q5" class="lbl" runat="server">Q5 :</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2">
                                        <asp:Label ID="lblAns5" runat="server" CssClass="lbl" Text="" Width="450px"></asp:Label></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left" colspan="2"><span id = "Q6" class="lbl" runat="server">Q6 :</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900;" colspan="2">
                                        <asp:Label ID="lblAns6" runat="server" CssClass="lbl" Text="" Width="450px"></asp:Label>&nbsp;</td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; width: 128px;"><span class="lbl">Last Status :</span></td>
			                        <td style="text-align:left"><span class="lbl" id="lblLastStatus" runat="server">Status</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; width: 128px;"><span class="lbl">Updated By :</span></td>
			                        <td style="text-align:left"><span class="lbl" id="lblStatusUpdBy" runat="server">User</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900; width: 128px;"><span class="lbl">Updated Date :</span></td>
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900;"><span class="lbl" id="lblStatusUpdDate" runat="server">Date</span>&nbsp;</td>
			                    </tr>
			                    <tr><td style="height:5px; width: 128px;">&nbsp;</td></tr>
			                    <tr>
			                        <td style="text-align:left; width: 128px;"><span class="lbl">Status :</span></td>
			                        <td style="text-align:left">
			                            <asp:DropDownList ID="ddlFirStatus" runat="server" CssClass="ddllist" AutoPostBack="True" OnSelectedIndexChanged="ddlFirStatus_SelectedIndexChanged">
                                            <asp:ListItem>-- Select --</asp:ListItem>
                                            <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                            <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                        </asp:DropDownList></td>
			                    </tr>
			                    <%--Additional Table for Closed cases--%>
			                    <tr id="trCloseFir" runat="server" visible="false">
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900;" colspan="2"><span id="lblCriminalId" runat="server" visible="false"></span>
			                            <table>
			                                <tr>
			                                    <td style="text-align:left; width: 125px;"><span class="lbl">Criminal :</span></td>
			                                    <td style="text-align:left;"><asp:DropDownList ID="ddlCriminalList" runat="server" CssClass="ddllist" AutoPostBack="True" OnSelectedIndexChanged="ddlFirStatus_SelectedIndexChanged">
                                                    <asp:ListItem>-- Select --</asp:ListItem>
                                                </asp:DropDownList></td>
                                                <td rowspan="4" style="text-align: left; padding-left:25px;">
                                                    <div style="border:solid 1px DarkGray; padding:5px;"><asp:Image ID="imgPhoto" runat="server" Height="75px" Width="75px" ImageUrl="~/photos/nopic.jpg" /><span id="lblPhotoName" runat ="server" visible="false"></span></div>
                                                </td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 125px;"><span class="lbl">Skin Color :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:TextBox ID="txtSkinColor" runat="server" CssClass="txtBox"></asp:TextBox></td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 125px;"><span class="lbl">Hair Color :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:TextBox ID="txtHairColor" runat="server" CssClass="txtBox"></asp:TextBox></td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 125px;"><span class="lbl">Height :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:TextBox ID="txtHeight" runat="server" CssClass="txtBox"></asp:TextBox></td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 125px;"><span class="lbl">Weight :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:TextBox ID="txtWeight" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 125px;"><span class="lbl">Scars :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:TextBox ID="txtScars" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 125px;"><span class="lbl">Physical Deformity :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:TextBox ID="txtPhyDeformity" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 125px;"><span class="lbl">Additional Details :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:TextBox ID="txtAddDetails" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>
			                            </table>
			                        </td>
			                    </tr>
			                    
			                    <tr>
			                        <td style="width: 128px"></td>
			                        <td style="text-align:left; padding-top:10px;"><asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="Submit" OnClick="btnSubmit_Click" /></td>
    			                </tr>
			                </table>
			            </div>
			        </div>
			    </div>
		    </div>
		</div>
		<div id="footer" class="smallgraytext" runat="server"></div>
	</div>
</form>
</body>
</html>
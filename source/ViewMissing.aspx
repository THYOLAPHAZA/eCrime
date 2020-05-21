<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMissing.aspx.cs" Inherits="ViewMissing" %>

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
				        <span class="orangetitle">Missing Citizen Details:</span><span id="lblUserId" runat="server" visible="false"></span><span id="lblMode" runat="server" visible="false"></span><span id="lblFirLogId" runat="server" visible="false"></span><br /><br />
				        <div style="padding-left:50px;">
			                <table width="100%">
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">First Name :</span></td>
			                        <td style="text-align:left">
                                        <asp:Label ID="lblFName" runat="server" CssClass="lbl"></asp:Label></td>
                                    <td rowspan="4" style="width: 80px; text-align: left">
                                        <div style="border:solid 1px DarkGray; padding:5px; Height:75px; Width:75px"><asp:Image ID="imgPhoto" runat="server" Height="75px" Width="75px" ImageUrl="~/photos/nopic.jpg" /></div>
                                    </td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Middle Name :</span></td>
			                        <td style="text-align:left">
                                        <asp:Label ID="lblMName" runat="server" CssClass="lbl"></asp:Label></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Last Name :</span></td>
			                        <td style="text-align:left">
                                        <asp:Label ID="lblLName" runat="server" CssClass="lbl"></asp:Label></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Mobile No. :</span></td>
			                        <td style="text-align:left">
                                        <asp:Label ID="lblMobileNo" runat="server" CssClass="lbl"></asp:Label></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Resi. No. :</span></td>
			                        <td style="text-align:left">
                                        <asp:Label ID="lblResiNo" runat="server" CssClass="lbl"></asp:Label></td>
			                        <td style="text-align:left; width: 80px;"></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Address :</span></td>
			                        <td style="text-align:left" colspan="2">
                                        <asp:Label ID="lblAddress" runat="server" CssClass="lbl"></asp:Label></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Date of Birth :</span></td>
			                        <td style="text-align:left" colspan="2">
                                        <asp:Label ID="lblBirthDate" runat="server" CssClass="lbl"></asp:Label></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Complaint Location :</span></td>
			                        <td style="text-align:left" colspan="2">
                                        <asp:Label ID="lblComplaintLocation" runat="server" CssClass="lbl"></asp:Label></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl" style="vertical-align: top">Details :</span></td>
                                    <td colspan="2" rowspan="2" style="text-align: left; border-bottom:solid 1px #FF9900; padding-bottom:10px;">
                                        &nbsp;<asp:Label ID="txtDetails" runat="server" CssClass="lbl" Width="201px"></asp:Label></td>
    			                </tr>
                                <tr>
                                    <td style="text-align: left; border-bottom:solid 1px #FF9900; padding-bottom:10px; width: 125px;">&nbsp;</td>
                                </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Last Status :</span></td>
			                        <td style="text-align:left"><span class="lbl" id="lblLastStatus" runat="server">Status</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; width: 125px;"><span class="lbl">Updated By :</span></td>
			                        <td style="text-align:left"><span class="lbl" id="lblStatusUpdBy" runat="server">User</span></td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900; padding-bottom:10px; width: 125px;"><span class="lbl">Updated Date :</span></td>
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900; padding-bottom:10px;"><span class="lbl" id="lblStatusUpdDate" runat="server">Date</span>&nbsp;</td>
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900; padding-bottom:10px;">&nbsp;</td>
			                    </tr>
			                    <tr>
			                        <td style="text-align:left; padding-top:10px;" colspan="2"><span class="lbl"><b>Department Details :</b></span></td>
			                    </tr>
			                    <%--Additional Table for Closed cases--%>
			                    <tr id="trCloseFir" runat="server" visible="true">
			                        <td style="text-align:left; border-bottom:solid 1px #FF9900;" colspan="3"><span id="lblCriminalId" runat="server" visible="false"></span>
			                            <table>
			                                <tr>
			                                    <td style="text-align:left; width: 121px;"><span class="lbl">Skin Color :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:Label ID="lblSkinColor" runat="server" CssClass="lbl" Width="161px"></asp:Label></td>
                                                <td rowspan="4" style="text-align: left; padding-left:25px;"><div style="border:solid 1px DarkGray; padding:5px;"><asp:Image ID="imgFCPhoto" runat="server" Height="75px" Width="75px" ImageUrl="~/photos/nopic.jpg" /><span id="lblPhotoName" runat ="server" visible="false"></span></div></td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 121px;"><span class="lbl">Hair Color :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:Label ID="lblHairColor" runat="server" CssClass="lbl" Width="161px"></asp:Label></td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 121px;"><span class="lbl">Height :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:Label ID="lblHeight" runat="server" CssClass="lbl" Width="161px"></asp:Label></td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 121px;"><span class="lbl">Weight :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:Label ID="lblWeight" runat="server" CssClass="lbl" Width="161px"></asp:Label></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 121px;"><span class="lbl">Scars :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:Label ID="lblScars" runat="server" CssClass="lbl" Width="161px"></asp:Label></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 121px;"><span class="lbl">Physical Deformity :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:Label ID="lblPhyDeformity" runat="server" CssClass="lbl" Width="161px"></asp:Label></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>
			                                <tr>
			                                    <td style="text-align:left; width: 121px;"><span class="lbl">Found Location :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:Label ID="lblFoundLocation" runat="server" CssClass="lbl" Width="161px"></asp:Label></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>			                                <tr>
			                                    <td style="text-align:left; width: 121px;"><span class="lbl">Additional Details :</span></td>
			                                    <td style="text-align:left;">
                                                    <asp:Label ID="lblAddDetails" runat="server" CssClass="lbl" Width="161px"></asp:Label></td>
                                                <td style="text-align: left">
                                                </td>
			                                </tr>
			                            </table>
			                        </td>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogMissing.aspx.cs" Inherits="LogMissing" %>

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
				        <span class="orangetitle">Missing Citizen Details:</span><span id="lblUserId" runat="server" visible="false"></span><span id="lblMode" runat="server" visible="false"></span><span id="lblType" runat="server" visible="false"></span><br /><br />
				        <div style="padding-left:50px;">
			                <table width="100%">
			                    <tr>
			                        <td style="text-align:left"><span class="lbl">First Name :</span></td>
			                        <td style="text-align:left"><asp:TextBox ID="txtFName" runat="server" CssClass="txtBox" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
			                        <td style="text-align:left; width: 80px;" rowspan="3"><div style="border:solid 1px DarkGray; padding:5px;"><asp:Image ID="imgPhoto" runat="server" Height="75px" Width="75px" ImageUrl="~/photos/nopic.jpg" /></div></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left"><span class="lbl">Middle Name :</span></td>
			                        <td style="text-align:left"><asp:TextBox ID="txtMName" runat="server" CssClass="txtBox" Text=""></asp:TextBox></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left"><span class="lbl">Last Name :</span></td>
			                        <td style="text-align:left"><asp:TextBox ID="txtLName" runat="server" CssClass="txtBox" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLName" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left"><span class="lbl">Mobile No. :</span></td>
			                        <td style="text-align:left"><asp:TextBox ID="txtMobileNo" runat="server" CssClass="txtBox" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
			                        <td style="text-align:left">
                                        <asp:FileUpload ID="Fupd" runat="server" BorderColor="Gray" BorderStyle="Groove"
                                            BorderWidth="1px" EnableTheming="True" Font-Names="Verdana" Font-Size="10pt"
                                            Height="25px" Width="82px" /></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left"><span class="lbl">Resi. No. :</span></td>
			                        <td style="text-align:left"><asp:TextBox ID="txtResiNo" runat="server" CssClass="txtBox" Text=""></asp:TextBox></td>
			                        <td style="text-align:left"></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left"><span class="lbl">Address :</span></td>
			                        <td style="text-align:left" colspan="2"><asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left"><span class="lbl">Date of Birth :</span></td>
			                        <td style="text-align:left" colspan="2"><asp:TextBox ID="txtBirthDate" runat="server" CssClass="txtBox" Text="" Width="160px"></asp:TextBox>&nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Enter valid date" Font-Bold="False" Font-Names="Tahoma" Font-Size="13px" ForeColor="Red" Operator="DataTypeCheck" Type="Date" SetFocusOnError="True"></asp:CompareValidator></td>
    			                </tr>
			                    <tr>
			                        <td style="text-align:left; height: 24px;"><span class="lbl" style="vertical-align: top">Details :</span></td>
                                    <td colspan="2" rowspan="2" style="text-align: left; border-bottom:solid 1px #FF9900;">
                                        <asp:TextBox ID="txtDetails" runat="server" CssClass="txtBox" Text="" Height="70px" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
    			                </tr>
                                <tr>
                                    <td style="height: 50px; text-align: left; border-bottom:solid 1px #FF9900;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align:left; width: 125px;"><span class="lbl">Skin Color :</span></td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtSkinColor" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                    <td style="text-align: left"></td>
                                </tr>
                                <tr>
                                    <td style="text-align:left; width: 125px;"><span class="lbl">Hair Color :</span></td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtHairColor" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                    <td style="text-align: left"></td>
                                </tr>
                                <tr>
                                    <td style="text-align:left; width: 125px;"><span class="lbl">Height :</span></td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtHeight" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                    <td style="text-align: left"></td>
                                </tr>
                                <tr>
                                    <td style="text-align:left; width: 125px;"><span class="lbl">Weight :</span></td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtWeight" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                    <td style="text-align: left"></td>
                                </tr>
                                <tr>
                                    <td style="text-align:left; width: 125px;"><span class="lbl">Scars :</span></td>
                                    <td style="text-align:left;">
                                        <asp:TextBox ID="txtScars" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                    <td style="text-align: left"></td>
                                </tr>
                                <tr>
                                    <td style="text-align:left; width: 125px; border-bottom:solid 1px #FF9900;"><span class="lbl">Physical Deformity :</span></td>
                                    <td style="text-align:left; border-bottom:solid 1px #FF9900;">
                                        <asp:TextBox ID="txtPhyDeformity" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                    <td style="text-align: left; border-bottom:solid 1px #FF9900;">&nbsp;</td>
                                </tr>
			                    <tr>
			                        <td style="text-align:left;"></td>
			                        <td colspan="2" style="text-align:left; padding-top:10px;"><asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="Submit" OnClick="btnSubmit_Click" /></td>
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
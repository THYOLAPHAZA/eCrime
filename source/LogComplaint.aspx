<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogComplaint.aspx.cs" Inherits="LogComplaint" %>

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
				    <span class="orangetitle">Log Complaint:</span><br /><br />
			            <table style="background-color:#EEEEEE;">
			                <tr>
			                    <td class="gridhead" style="background-color:#EEEEEE;">Complaint Type :</td>
			                    <td class="gridhead" style="background-color:#EEEEEE;">
			                            <asp:DropDownList ID="ddlComplaintType" runat="server" CssClass="ddllist">
                                            <asp:ListItem Value="">-- Select --</asp:ListItem>
                                            <asp:ListItem Value="Missing">Missing</asp:ListItem>
                                            <asp:ListItem Value="Complaint">Complaint</asp:ListItem>
                                        </asp:DropDownList>
			                    </td>
			                </tr>
                            <tr><td colspan="2" style="padding:5px; height:10px;"></td></tr>
		                    <tr>
		                        <td style="text-align:left;"></td>
		                        <td colspan="2" style="text-align:left"><asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="Submit" OnClick="btnSubmit_Click" /></td>
			                </tr>
			                <tr><td></td><td style="padding-top:20px; text-align:left;"><span id="lblMessage" class="msg" runat="server"></span></td></tr>
			            </table>
			        </div>
			    </div>
		    </div>
		</div>
		<div id="footer" class="smallgraytext" runat="server"></div>
	</div>
</form>
</body>
</html>
<%@ Page Title="" Language="C#" MasterPageFile="~/Pharma.master" AutoEventWireup="true"
	CodeFile="HealthHome.aspx.cs" Inherits="HealthHome" %>

<asp:Content ID="Content3" ContentPlaceHolderID="titleContent" runat="Server">
	Health Home
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
	<img src="Assets/Images/person-with-pc.jpg" alt="Your Health Online" width="236" height="170"
		align="right" />
	<h1 class="YourPharmacyOnline">
		<span class="Your">Your</span>
		<br />
		<span class="PharmacyOnline">Health Online</span>
	</h1>
	<p class="para_leftmar01">
		<strong>Your gateway to a comprehensive range of health resources and services</strong>.</p>
	<h1 class="HealthHome">
		Health Links:</h1>
	<p>
		In addition, we have also a included useful links to <a href="HealthLinks.aspx">medical
			documents, local services, professional associations and related resources</a>.</p>
	<h1 class="HealthHome">
		Medicine Chest:
	</h1>
	<p>
		Our <a href="Health_Medichest.aspx">Medicine Chest</a> has our recommendations
		of useful medicines and dressings you should keep at home.</p>
	<p>
		<img src="Assets/Images/nhs-pharmacy-logo-small.gif" alt="Providing NHS Services" width="62"
			height="70" /><img src="Assets/Images/nhs-services-logo-small.gif" alt="NHS Services Available Here"
				width="140" height="70" /><a href="http://www.nhsdirect.nhs.uk/" target="_blank"><img
					src="Assets/Images/nhs-direct.gif" alt="NHS Direct Call 0845 4647" width="121" height="50"
					border="0" /></a></p>
</asp:Content>

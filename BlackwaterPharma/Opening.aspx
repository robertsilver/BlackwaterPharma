<%@ Page Title="" Language="C#" MasterPageFile="~/Pharma.master" AutoEventWireup="true"
	CodeFile="Opening.aspx.cs" Inherits="Opening" %>

<asp:Content ID="Content3" ContentPlaceHolderID="titleContent" runat="Server">
	Opening Hours
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
	<h1 class="YourPharmacyOnline">
		<span class="Your">Your</span>
		<br />
		<span class="PharmacyOnline">Pharmacy Online</span>
		<img src="Images/pharmacist-pic01.jpg" alt="Your Pharmacist" width="176" height="265"
			align="right" />
	</h1>
	<p style="font-size: 1.10em; font-family: Verdana, Tahoma, Sans-Serif">
		Welcome to <strong>Blackwater Pharmacy</strong>. Here you will find access to a wealth of Health Information,
		Products and Pharmacy Services.</p>
	<p class="OpeningHoursHeader">
		Opening Hours:</p>
	<div id="OpeningHoursBox">
		<p class="OpeningHoursBoxHeader">
			Opening Hours</p>
		<span class="OpeningHoursLine2">Open late and all weekends for your convenience</span>
		<table>
			<tr>
				<td class="OpeningHoursLine3PartA">
					Monday to Saturday
				</td>
				<td class="OpeningHoursLine3PartB">
					7am - 10pm
				</td>
			</tr>
			<tr>
				<td class="OpeningHoursLine3PartA">
					Sunday
				</td>
				<td class="OpeningHoursLine3PartB">
					10am - 8pm
				</td>
			</tr>
			<tr>
				<td class="OpeningHoursLine3PartA">
					Bank holidays
				</td>
				<td class="OpeningHoursLine3PartB">
					10am - 8pm
				</td>
			</tr>
		</table>
		<p>
		</p>
	</div>
	<div>
		<p class="Questionnaire">
			Community Pharmacy Patient Questionnaire:</p>
		<p>
			To view our Community Pharmacy Patient Questionnaire, please <a href="/Files/CPPQFeedbackLetter2012.doc" target="_blank">click here</a>
		</p>
		</div>
	<div>
		<p class="WhenWeAreClosed">
			When we are closed:</p>
		<p>
			When this pharmacy is closed, health advice and information, including details of
			other local health services, is available around the clock from <a href="http://www.nhsdirect.nhs.uk/"
				target="_blank">NHS direct</a>.
		</p>
		<p>
			You can use:</p>
		<p class="para_last">
			<img src="images/nhs-direct.gif" alt="NHS Direct Call 0845 4647" width="121" height="50"
				border="0" align="right" class="nhsdirect" />&nbsp;&bull; NHS Direct online
			at <a href="http://www.nhsdirect.nhs.uk/" target="_blank">www.nhsdirect.nhs.uk</a><br />
			&nbsp;&bull; <a href="http://www.nhsdirect.nhs.uk/articles/article.aspx?articleId=1164"
				target="_blank">NHS Direct Interactive on digital TV</a><br />
			&nbsp;&bull; The NHS Direct telephone service. <strong>Call 0845 4647</strong></p>
		<img src="images/nhs-pharmacy-logo-small.gif" alt="Providing NHS Services"
					width="62" height="70" class="logo01" /><img src="images/nhs-services-logo-small.gif"
						alt="NHS Services Available Here" width="140" height="70" class="logo01" />
	</div>
</asp:Content>

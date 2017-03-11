<%@ Page Title="" Language="C#" MasterPageFile="~/Pharma.master" AutoEventWireup="true"
	CodeFile="FindUs.aspx.cs" Inherits="FindUs" %>

<asp:Content ID="Content3" ContentPlaceHolderID="titleContent" runat="Server">
	Find Us
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
	<h1 class="PatientAndCustomerServices">
		Finding Us:
	</h1>
	<div class="featurebox">
		<h2>
			Our Address:</h2>
		<table width="100%" border="0" cellspacing="0" cellpadding="1">
			<tr>
				<td>
					<p>
						<strong>Blackwater Pharma</strong><br />
						Princes Road<br />
						Maldon<br />
						Essex<br />
						CM9 5GP<br />
					</p>
				</td>
				<td>
					<p>
						<strong>Branch surgery</strong><br />
						Goldring House<br />
						Rowan Drive<br />
						Heybridge<br />
						Essex<br />
						CM9 4BW
					</p>
				</td>
			</tr>
		</table>
	</div>
	<div class="featurebox">
		<h2>
			Contacting Us:</h2>
		<p>
			Our Telephone Numbers are:
		</p>
		<p>
			Blackwater Pharma:<br />
			Tel: <strong>01621 855118</strong><br />
		</p>
		<p>
			Blackwater Medical Pharma:<br />
			Tel: <strong>0844 499 6635</strong>
		</p>
	</div>
	<br />
	<div style="float: left; width: 100%">
		<div style="float: left">
			<iframe width="640" height="480" frameborder="0" scrolling="no" marginheight="0"
				marginwidth="0" src="http://maps.google.co.uk/maps/ms?hl=en&amp;ie=UTF8&amp;msa=0&amp;msid=105957720306161528472.000485b499290fb6a5766&amp;ll=51.728357,0.680895&amp;spn=0.012759,0.027466&amp;z=15&amp;output=embed">
			</iframe>
			<br />
			<small>View <a href="http://maps.google.co.uk/maps/ms?hl=en&amp;ie=UTF8&amp;msa=0&amp;msid=105957720306161528472.000485b499290fb6a5766&amp;ll=51.728357,0.680895&amp;spn=0.012759,0.027466&amp;z=15&amp;source=embed"
				style="color: #0000FF; text-align: left">Blackwater Pharma</a> in a larger
				map</small>
		</div>
		<div style="float: left; padding-left: 10px">
			<strong><u>Directions</u></strong><br />
			Turn down Princes Road, turning right into the Maldon District Council car park,
			and Blackwater Pharma will be next to the Council offices.
		</div>
	</div>
	<br />
	<br />
	<div style="float: left">
		<h1 class="MediChestContents">
			Disabled Customers:</h1>
		<p class="para_last">
			The Pharmacy is fully accessible to the less able, including access to our consultation
			room. In addition, we offer a delivery service to anyone unable to collect their
			medication from the pharmacy. Please speak to a member of staff if you require any
			further assistance whilst in the store.</p>
		<p>
			<img src="Assets/Images/nhs-pharmacy-logo-small.gif" alt="Providing NHS Services" width="62"
				height="70" class="logo01" /><img src="Assets/Images/nhs-services-logo-small.gif" alt="NHS Services Available Here"
					width="140" height="70" class="logo01" /><a href="http://www.nhsdirect.nhs.uk/" target="_blank"><img
						src="Assets/Images/nhs-direct.gif" alt="NHS Direct Call 0845 4647" width="121" height="50"
						border="0" class="logo01" /></a></p>
	</div>
</asp:Content>

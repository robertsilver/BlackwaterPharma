<%@ Page Title="" Language="C#" MasterPageFile="~/Pharma.master" AutoEventWireup="true"
    CodeFile="Email.aspx.cs" Inherits="Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="Assets/CSS/Email.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="email-prescriptions">
        <asp:Label ID="lblMessage" runat="server" Text="Welcome to Blackwater Pharmacy's repeat prescription.  Please fill out the form below with, requesting your repeat prescription, and we will do our best to fullfil it.  Thank you." /><br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" /><br />
        <asp:Label ID="lblUnsafeValues" runat="server" ForeColor="Red" Font-Bold="true" Visible="false"
            Text="In appropriate values are: semi-colons (;), an apostrophe (') or the word macro" />

        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblFName" runat="server" CssClass="Normal-Size-Font" Text="Patient's first name:" />
                        <asp:Label ID="lblMandatoryField" runat="server" CssClass="Mandatory-Field" Text="*" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtFName" runat="server" MaxLength="20" ValidationGroup="RequiredFields" />
                        <asp:RequiredFieldValidator ID="reqFName" runat="server" ValidationGroup="RequiredFields"
                            SetFocusOnError="true" ErrorMessage="This is a mandatory field" ControlToValidate="txtFName" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLName" runat="server" CssClass="Normal-Size-Font" Text="Patient's last name:" />
                        <asp:Label ID="Label1" runat="server" CssClass="Mandatory-Field" Text="*" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtLName" runat="server" MaxLength="30" ValidationGroup="RequiredFields" />
                        <asp:RequiredFieldValidator ID="reqLName" runat="server" ValidationGroup="RequiredFields"
                            SetFocusOnError="true" ErrorMessage="This is a mandatory field" ControlToValidate="txtLName" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress1" runat="server" CssClass="Normal-Size-Font" Text="Patient's Address 1:" />
                        <asp:Label ID="Label2" runat="server" CssClass="Mandatory-Field" Text="*" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server" MaxLength="30" ValidationGroup="RequiredFields" />
                        <asp:RequiredFieldValidator ID="reqAddress1" runat="server" ValidationGroup="RequiredFields"
                            SetFocusOnError="true" ErrorMessage="This is a mandatory field" ControlToValidate="txtAddress1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress2" runat="server" CssClass="Normal-Size-Font" Text="Address 2:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2" runat="server" MaxLength="30" ValidationGroup="RequiredFields" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCity" runat="server" CssClass="Normal-Size-Font" Text="City:" />
                        <asp:Label ID="Label4" runat="server" CssClass="Mandatory-Field" Text="*" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="30" ValidationGroup="RequiredFields" />
                        <asp:RequiredFieldValidator ID="reqCity" runat="server" ValidationGroup="RequiredFields"
                            SetFocusOnError="true" ErrorMessage="This is a mandatory field" ControlToValidate="txtCity" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCounty" runat="server" CssClass="Normal-Size-Font" Text="County:" />
                        <asp:Label ID="Label5" runat="server" CssClass="Mandatory-Field" Text="*" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtCounty" runat="server" MaxLength="15" ValidationGroup="RequiredFields" />
                        <asp:RequiredFieldValidator ID="reqCounty" runat="server" ValidationGroup="RequiredFields"
                            SetFocusOnError="true" ErrorMessage="This is a mandatory field" ControlToValidate="txtCounty" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPCode" runat="server" CssClass="Normal-Size-Font" Text="Postcode:" />
                        <asp:Label ID="Label6" runat="server" CssClass="Mandatory-Field" Text="*" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPCode" runat="server" MaxLength="8" ValidationGroup="RequiredFields" />
                        <asp:RequiredFieldValidator ID="reqPCode" runat="server" ValidationGroup="RequiredFields"
                            SetFocusOnError="true" ErrorMessage="This is a mandatory field" ControlToValidate="txtPCode" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPhoneNo" runat="server" CssClass="Normal-Size-Font" Text="Telephone number, e.g. 01621 123456:" />
                        <asp:Label ID="lblPhoneNo2" runat="server" Text="(in case we have a query regarding the patient's request) "
                            CssClass="Small-Size-Font" />
                        <asp:Label ID="Label7" runat="server" CssClass="Mandatory-Field" Text="*" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="12" ValidationGroup="RequiredFields" />
                        <asp:RequiredFieldValidator ID="reqFields" runat="server" ValidationGroup="RequiredFields"
                            SetFocusOnError="true" ErrorMessage="This is a mandatory field" ControlToValidate="txtPhoneNo" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPEmail" runat="server" CssClass="Normal-Size-Font" Text="Patient's email address, if you require a copy of your request (optional):" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPEmail" runat="server" MaxLength="30" ValidationGroup="RequiredFields" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrescription" runat="server" CssClass="Normal-Size-Font" Text="Please enter the prescription(s) the patient is requesting:" />
                        <asp:Label ID="Label8" runat="server" CssClass="Mandatory-Field" Text="*" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrescription" runat="server" TextMode="MultiLine" MaxLength="2000"
                            Height="100px" Width="300px" />
                        <asp:RequiredFieldValidator ID="reqPrescription" runat="server" ValidationGroup="RequiredFields"
                            SetFocusOnError="true" ErrorMessage="This is a mandatory field" ControlToValidate="txtPrescription" />
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnSumbit" runat="server" Text="Send your request" ValidationGroup="RequiredFields"
                OnClick="btnSubmit_OnClick" />
        </div>
    </div>
</asp:Content>

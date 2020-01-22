<%@ Page Title="" Language="C#" MasterPageFile="~/Pharma.master" AutoEventWireup="true"
    CodeFile="Email.aspx.cs" Inherits="Email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="Assets/CSS/Email.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="email-prescriptions">
        <div style="font-size: 120%; margin-bottom: 30px; border: 1px solid black;">
            Dr Geramayeh has started an aesthetics clinic in this premises
             <br />
            Click <a href='https://www.cosmeticsfacial.com' target='_blank'>here</a> to find out more.
        </div>

        <div style="text-align: center;">
            <div style="font-weight: bold; font-size: 25px;">
                Important notice
            </div>

            <div>
                The way you order your medication is changing
            </div>

            <div style="font-weight: bold; font-size: 25px;">
                From 1st March 2020
            </div>

            <div>
                We will no longer be able to order your medication for you
            </div>
            <div>
                You will have to
            </div>
            <div style="text-decoration: underline; font-weight: bold;">
                Order direct from the Doctor's surgery
            </div>

            <div>
                You can order either in person, by post, email 
                (prescriptions.f81099@nhs.net),
NHS App or SystemOnline portal (online or via the app)
            </div>

            Please make it clear that you want
            <label style="font-weight: bold; text-decoration: underline">Blackwater Pharmacy</label>
            to 
dispense your medication

            <div style="font-size: 15px;">
Please note that they will not accept telephone requests</div>

            <div style="font-weight: bold; font-size: 20px;">
This is a Blackwater Surgery initiative designed to reduce
medicine waste</div>

If you have any queries, please contact the <label style="font-weight: bold; text-decoration: underline">surgery on 876760</label>
        </div>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_RightBarNav.ascx.cs"
	Inherits="RightBarNav" %>
<ul>
	<asp:Repeater ID="repRightNavBar" runat="server" EnableViewState="false" OnItemDataBound="repRightNavBar_OnItemDataBound">
		<ItemTemplate>
			<li>
				<asp:HyperLink ID="hypLink" runat="server" NavigateUrl='<%# Eval("URL") %>'>
					<span class="HeaderText">
						<asp:HiddenField ID="hidImg" runat="server" Value='<%# Eval("ID").ToString() %>' />
						<%# Eval("HeaderText") %></span>
					<asp:Image ID="imgURL" runat="server" />
					<%# Eval("BodyText") %>
				</asp:HyperLink>
			</li>
		</ItemTemplate>
		<AlternatingItemTemplate>
			<li class="altcolor">
				<asp:HyperLink ID="hypAltLink" runat="server">
					<span class="HeaderText">
						<asp:HiddenField ID="hidImgAlternate" runat="server" Value='<%# Eval("ID").ToString() %>' />
						<%# Eval("HeaderText") %></span>
					<asp:Image ID="imgURLAlternate" runat="server" NavigateUrl='<%# Eval("URL") %>' />
					<%# Eval("BodyText") %>
				</asp:HyperLink>
			</li>
		</AlternatingItemTemplate>
	</asp:Repeater>
</ul>

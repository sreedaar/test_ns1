<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppOperationSetControl.ascx.cs" Inherits="RavenWebPayroll.UI.main.views.utilities.AppOperationSetControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div style="width: 100%; background-color: LightGray;">
<telerik:RadToolBar ID="OperationToolbar" runat="server" 
    onbuttonclick="OperationToolbar_ButtonClick" Skin="Sitefinity" BackColor="White">
    <Items>
        <telerik:RadToolBarButton Text="Back" CommandName="Backing" runat="server"></telerik:RadToolBarButton>
        <telerik:RadToolBarButton runat="server" IsSeparator="true"></telerik:RadToolBarButton> 
        <telerik:RadToolBarButton Text="Save" runat="server" CommandName="Saving"></telerik:RadToolBarButton>
    </Items>
</telerik:RadToolBar>
</div>
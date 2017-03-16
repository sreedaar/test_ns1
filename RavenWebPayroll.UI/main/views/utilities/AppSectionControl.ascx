<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppSectionControl.ascx.cs" Inherits="RavenWebPayroll.UI.main.views.utilities.AppSectionControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadPanelBar ID="MenuItemPanelBar" runat="server" 
    Width="100%" DataValueField="Key" DataTextField="Value" DataFieldParentID="Parent"
    Skin="Sunset" ExpandMode="SingleExpandedItem" 
    onitemclick="MenuItemPanelBar_ItemClick">
    <Items>
        <telerik:RadPanelItem Text="Configuration">
            <Items>
                <telerik:RadPanelItem Text="Company Information"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Company Locations"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Company Structure"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Job Titles"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Job Specifications"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Pay Grade"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Employment Status"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Job Categories"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="Languages"></telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem Text="User Management">
            <Items>
                <telerik:RadPanelItem Text="Users"></telerik:RadPanelItem>
                <telerik:RadPanelItem Text="User Groups"></telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem Text="Employee Management">
                <Items>
                    <telerik:RadPanelItem Text="Employees"></telerik:RadPanelItem>
                </Items>
        </telerik:RadPanelItem>
        
    </Items>
</telerik:RadPanelBar>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RavenWebPayroll.UI.main.Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="~/main/views/utilities/AppSectionControl.ascx" tagname="AppSectionControl" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register src="views/SingleDataFormControlCollectionManager.ascx" tagname="SingleDataFormControlCollectionManager" tagprefix="uc3" %>

 <%@ Register src="~/main/views/utilities/AppOperationSetControl.ascx" tagname="AppOperationSetControl" tagprefix="uc2" %>

<%@ Register src="views/configuration/BranchesForm.ascx" tagname="BranchesForm" tagprefix="uc4" %>

<%@ Register src="views/ListingDataFormControlCollectionManager.ascx" tagname="ListingDataFormControlCollectionManager" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Welcome</title>
    <%--<link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />--%>
    <link href="~/Styles/StyleSheet.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="Mainform" runat="server">
    <div class="page">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Height="100%" Width="100%" runat="server" Skin="Default" HorizontalAlign="Center">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" Height="100%" Width="100%">
       
    <telerik:RadSplitter ID="RadSplitter1" runat="server" Height="100%" Width="100%" Orientation="Horizontal">
        <telerik:RadPane ID="TopPane" runat="server" Height="35px" Scrolling="None">
            <div class="header">
                <div class="title">
                    <h2>
                        Welcome</h2>
                </div>
            </div>
        
        </telerik:RadPane>
        <telerik:RadSplitBar ID="RadSplitBar1" runat="server" CollapseMode="None" EnableResize="false">
        </telerik:RadSplitBar>
        <telerik:RadPane ID="Bottom" runat="server" Scrolling="None">
            <div class="main">
                <telerik:RadSplitter ID="MainSplitter" runat="server" Height="100%" 
                    Orientation="Vertical" Width="100%">
                    <telerik:RadPane ID="LeftPane" runat="server" Height="100%" Width="250px"><uc1:AppSectionControl 
                    ID="AppSectionControl" runat="server" 
                    OnApplicationSectionSelected="AppSectionControl_OnApplicationSectionSelected" /></telerik:RadPane>
                    <telerik:RadSplitBar 
                    ID="SplitMain" runat="server" CollapseMode="Forward"></telerik:RadSplitBar>
                    <telerik:RadPane ID="RightPane" runat="server" Scrolling="Y">
                        <telerik:RadToolTip ID="NotifierControl" runat="server" OffsetX="100" 
                    OffsetY="5000" RelativeTo="BrowserWindow" Skin="Sitefinity">
                        </telerik:RadToolTip>
                    <uc2:AppOperationSetControl ID="AppOperationSetControlInstance" 
                    runat="server" 
                    OnAppOperationSelected="AppOperationSetControlInstance_OnAppOperationSelected" />

                    <uc3:SingleDataFormControlCollectionManager 
                    ID="SingleDataFormControlCollectionManagerInstance" runat="server" 
                    OnNotifyExceptionOccurence="SingleDataFormControlCollectionManagerInstance_OnNotifyExceptionOccurence" />
                        <uc5:ListingDataFormControlCollectionManager 
                    ID="ListingDataFormControlCollectionManagerInstance" runat="server" />
</telerik:RadPane></telerik:RadSplitter>
            </div>
        </telerik:RadPane>
    </telerik:RadSplitter>
 </telerik:RadAjaxPanel>
        
    </div>
    </form>
</body>
</html>

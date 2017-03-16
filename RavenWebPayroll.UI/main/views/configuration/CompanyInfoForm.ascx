<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyInfoForm.ascx.cs" Inherits="RavenWebPayroll.UI.main.views.configuration.CompanyInfoForm" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table width="400px">
<tr>
    <td colspan="2" class="fieldlabel">Company&nbsp;Information</td>
</tr>
    <tr>
        <td>Name</td>
        <td>
            <telerik:RadTextBox ID="CompanyNameTextBox" Runat="server" 
                EmptyMessage="Please provide your company name." Width="200px" 
                Skin="Sunset">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td>Phone&nbsp;Number</td>
        <td>
            <telerik:RadTextBox ID="PhoneNumberTextBox" Runat="server" 
                EmptyMessage="Please provide your contact number." Width="200px" 
                Skin="Simple">
            </telerik:RadTextBox></td>
    </tr>
    <tr>
        <td>TIN</td>
        <td>
            <telerik:RadTextBox ID="TINTextBox" Runat="server" 
                EmptyMessage="Please provide your company TIN." Width="200px" 
                Skin="Sunset">
            </telerik:RadTextBox></td>
    </tr>
    <tr>
        <td valign="top">Address</td>
        <td>
            <telerik:RadTextBox ID="AddressTextBox" Runat="server" 
                EmptyMessage="Please provide your address." Width="200px" Height="100px" 
                Skin="Sunset">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td valign="top">Zip&nbsp;Code</td>
        <td>
            <telerik:RadTextBox ID="ZipCodeTextBox" Runat="server" 
                EmptyMessage="Please provide your zip code." Width="200px" Skin="Sunset">
            </telerik:RadTextBox></td>
    </tr>
</table>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BranchesForm.ascx.cs" Inherits="RavenWebPayroll.UI.main.views.configuration.BranchesForm" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="BranchesGrid" runat="server" Width="100%" 
    DataSourceID="BranchDataSource" GridLines="None" AllowSorting="true" 
    Skin="Sunset">
<MasterTableView AutoGenerateColumns="False" DataSourceID="BranchDataSource">
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridBoundColumn DataField="ID" DataType="System.Guid" HeaderText="ID" Visible="False" 
            SortExpression="ID" UniqueName="ID">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:ImageButton ID="EditButton" ImageUrl="~/main/images/Edit.gif" runat="server" CommandName="Editing" />
                <asp:ImageButton ID="DeleteButton" ImageUrl="~/main/images/Delete.gif" runat="server" CommandName="Deleting" />
            </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
        </telerik:GridTemplateColumn>
        <telerik:GridBoundColumn DataField="LocationName" HeaderText="LocationName" 
            SortExpression="LocationName" UniqueName="LocationName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Address" HeaderText="Address" 
            SortExpression="Address" UniqueName="Address">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="PhoneNumber" HeaderText="PhoneNumber" 
            SortExpression="PhoneNumber" UniqueName="PhoneNumber">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ZipCode" HeaderText="ZipCode" 
            SortExpression="ZipCode" UniqueName="ZipCode">
        </telerik:GridBoundColumn>
    </Columns>
</MasterTableView>
</telerik:RadGrid>
<telerik:RadWindow ID="BranchDetailWindow" runat="server" Skin="Sunset">
<ContentTemplate>
<table width="400px">
<tr>
    <td colspan="2" class="fieldlabel">Branch</td>
</tr>
<tr>
    <td>Name</td>
    <td>
        <telerik:RadTextBox ID="LocationNameTextbox" runat="server">
        </telerik:RadTextBox></td>
</tr>
</table>
</ContentTemplate>
</telerik:RadWindow>
<asp:ObjectDataSource ID="BranchDataSource" runat="server" 
    SelectMethod="GetBranches" TypeName="RavenWebPayroll.Common.Models.BranchModel"></asp:ObjectDataSource>

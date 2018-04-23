<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to create an ASPxGridView with custom pager with the "Selecting a page size" feature at Runtime</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxComboBox ID="cbPagerPosition" runat="server" ValueType="System.String" AutoPostBack="true" SelectedIndex="1">
                <Items>
                    <dx:ListEditItem Text="Top" Value="PosTop" />
                    <dx:ListEditItem Selected="True" Text="Bottom" Value="PosBottom" />
                    <dx:ListEditItem Text="Both" Value="PosBoth" />
                </Items>
            </dx:ASPxComboBox>
            <asp:SqlDataSource ID="sds" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>
        </div>     
    </form>
</body>

</html>

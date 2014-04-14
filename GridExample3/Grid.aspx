<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="GridExample3.Grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:TextBox ID="txtCategory" CssClass="form-control" runat="server" placeholder="Category"></asp:TextBox>
          <asp:Button ID="btnGo" CssClass="btn btn-default" runat="server" Text="Go" OnClick="btnGo_Click" />
        <asp:GridView ID="GridView1" runat="server"    AllowSorting="true" 
        OnSorting="onGridView_Sorting" >

        </asp:GridView>
    </div>
    </form>
</body>
</html>

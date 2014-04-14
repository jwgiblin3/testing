<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GridExample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instituitional Investor Grid Example</title>
       <link href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css" rel="stylesheet" />
       <script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
       <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>   
</head>
<body>
    <form id="form1" runat="server" class="form-inline">
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
         <h3 style="text-align: center;">Test</h3>
        <div class="form-group">
            <asp:TextBox ID="txtCategory" CssClass="form-control" runat="server" placeholder="Category"></asp:TextBox>
        </div>


        <asp:Button ID="btnGo" CssClass="btn btn-default" runat="server" Text="Go" OnClick="btnGo_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gridView_PageIndexChanging" CssClass="table table-hover table-striped"  PageSize="1" AllowPaging="true"  AllowSorting="true"  
      OnSorting="GridView1_Sorting">
            <Columns>
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Region"  HeaderText="Region" SortExpression="Region"  />
                <asp:BoundField DataField="Country"  HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="Rank"  HeaderText="Rank" SortExpression="Rank" />
                <asp:BoundField DataField="Firm"  HeaderText="Firm" SortExpression="Firm" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>

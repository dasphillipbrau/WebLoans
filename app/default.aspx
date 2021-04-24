<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebLoans.app._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css"/>
    <style type="text/css">
        .auto-style1 {
            width: 24%;
            height: 215px;
        }
        .auto-style2 {
            height: 27px;
            text-align: center;
        }
        .auto-style3 {
            width: 309px;
        }
        .auto-style4 {
            text-align: center;
        }
    </style>
</head>
<body>
    <div class="container well">
        <form id="form1" runat="server" class="form-horizontal">
            <div class="row">
                <div class="col-xs-12">
                    <h2>Loan Calculator</h2>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblAmount" runat="server" Text="Amount" CssClass="control-label col-sem-2"></asp:Label>
                <div class="col-sem-10">
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblRate" runat="server" Text="Interest Rate (%)" CssClass="control-label col-sem-2"></asp:Label>
                <div class="col-sem-10">
                    <asp:TextBox ID="txtInterest" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTerm" runat="server" Text="Term in years" CssClass="control-label col-sem-2"></asp:Label>
                <div class="col-sem-10">
                    <asp:TextBox ID="txtTerm" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblCurrency" runat="server" Text="Interest Rate" CssClass="control-label col-sem-2"></asp:Label>
                <div class="col-sem-10">
                    <asp:DropDownList ID="ddlCurrency" CssClass="btn btn-primary dropdown-toggle-form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="tipo_moneda"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PrestamosConnectionString %>" SelectCommand="SELECT [tipo_moneda], [descripcion] FROM [Moneda]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sem-10">
                    <asp:Label ID="lblMessage" runat="server" Text="Interest Rate" CssClass="control-label col-sem-2"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sem-10">
                    <asp:Button ID="btnCalculateLoan" runat="server" Text="Calculate" OnClick="btnCalculateLoan_Click" class="btn btn-primary"/>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sem-10">
                    <asp:GridView ID="grdLoanData" runat="server"></asp:GridView>
                </div>
            </div>
        </form>
    </div>
    
</body>
</html>

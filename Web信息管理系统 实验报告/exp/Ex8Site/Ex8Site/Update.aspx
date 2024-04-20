<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>商品编号：</td>
                    <td>
                        <asp:TextBox ID="txtProductId" runat="server" Width="72px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        商品分类：
                     
                      <td><asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="CategoryId">
                        </asp:DropDownList></td>
                    </td>
                </tr>
                <tr>
                    <td>
                        商品名称：
                    </td>
                    <td><asp:TextBox ID="txtName" runat="server" Width="72px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        商品价格：
                    </td>
                    <td><asp:TextBox ID="txtListPrice" runat="server" Width="72px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        商品库存：
                    </td>
                    <td><asp:TextBox ID="txtQty" runat="server" Width="72px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        供应商：
                     
                      <td><asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="SuppId">
                        </asp:DropDownList></td>
                    </td>
                </tr>
                <tr>
                    <td>
                        商品描述：
                    </td>
                    <td><asp:TextBox ID="txtDescn" runat="server" Width="72px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                
            </table>
        </div>
        <asp:Button ID="BtnUpdate" runat="server" Text="修改" Width="53px" 
            OnClick="btnUpdate_Click"/>
        <asp:Button ID="btnReturn" runat="server" Text="返回" Width="47px" 
            OnClick="btnReturn_Click"/>
    </form>
    
</body>
</html>

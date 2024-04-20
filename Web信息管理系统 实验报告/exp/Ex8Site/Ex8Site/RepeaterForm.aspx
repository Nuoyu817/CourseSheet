<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepeaterForm.aspx.cs" Inherits="RepeaterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>利用Reater控件实现数据管理</title>
    <style>
        table { 
            border: 1px solid #808080; 
            width: 600px;
            border-collapse: collapse; 

        }
        td { 
            border: 1px solid #808080; 
            width: 160px; 
            text-align: center;
            
            }
        td img { 
            width: 160px; 
            height: 160px
            }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="rptProduct" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td rowspan="5">
                                <asp:Image ID="imgProduct" runat="server"
                                    ImageUrl='<%# Eval("Image") %> '/>
                            </td>
                            <td>商品名称：</td>
                            <td><%# Eval("Name") %></td>
                        </tr>
                        <tr>
                            
                            <td>商品价格：</td>
                            <td><%# Eval("ListPrice") %></td>
                        </tr>
                        <tr>
                            <td>商品描述：</td>
                            <td><%# Eval("Descn") %></td>
                        </tr>
                        <tr>
                            <td>库存：</td>
                            <td><%# Eval("Qty") %></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HyperLink ID="hlAdd" NavigateUrl="~/Insert.aspx"
                                    runat="server">新建</asp:HyperLink>
                                <asp:HyperLink ID="hlUpdate" runat="server"
                                    NavigateUrl='<%# "~/Update.aspx?ProductId=" +
                                        Eval("ProductId")%>'>编辑</asp:HyperLink>
                                <%--<%# %> 中可以进行字符串的拼接--%>
                                <asp:LinkButton ID="btnDelete" runat="server"
                                    Text="删除" OnClick="BtnDelete_Click"
                                    CommandArgument='<%#Eval("ProductId") %>' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>

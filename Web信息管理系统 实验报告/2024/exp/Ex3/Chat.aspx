<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Ex3.Chat" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>聊天页面</title>  
  <script src="Scripts/jquery-3.7.1.min.js"></script>
  <%-- refresh()函数以500毫秒为间隔，连续地局部刷新div层divMsg。其中$.ajax()调用jQuery提供的ajax()方法，用于执行异步请求 --%>
  <script type="text/javascript">
      function refresh() {
          $.ajax({
              url: "Ajax.aspx",
              cache: false,
              success: function (text) {

                  document.getElementById("divMsg").innerHTML = text;
              },
              error: function (jqXHR, textStatus, errorThrown) {
                  alert("网络连接有问题，请重试！");
              }
          });
          setTimeout("refresh()", 500);
      }
  </script>
</head>
<body onload="refresh()">
  <form id="form1" runat="server">
    <div id="divMsg"></div>
    <div>
      <asp:Label ID="lb1Name" runat="server"></asp:Label>
      <br />
      <asp:TextBox ID="txtMessage" runat="server" Height="90px" TextMode="MultiLine" Width="279px"></asp:TextBox>
      <br />
      <asp:Button ID="btnSend" runat="server" OnClick="BtnSend_Click" Text="发送" />
    </div>
  </form>
</body>
</html>

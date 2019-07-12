<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsAdd.aspx.cs" Inherits="NewsAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="css/newscss.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <div id="title"><img src="images/titlelogo.jpg" width="10" height="27" alt=""/><img src="images/newssend.jpg" width="219" height="27" alt=""/></div>
          <div id="formitem">
            <div>
              <table width="500" border="1">
                <tbody>
                  <tr>
                    <td class="c1">标题</td>
                    <td class="c2"><asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="398px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="请输入标题"></asp:RequiredFieldValidator></td>
                  </tr>
                  <tr>
                    <td class="c1">内容</td>
                    <td class="c2"><asp:TextBox ID="TextBox2" runat="server" Height="85px" TextMode="MultiLine" Width="405px"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td class="c1">发布人 </td>
                    <td class="c2"><asp:TextBox ID="TextBox3" runat="server" Width="384px"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td class="c1">附件</td>
                    <td class="c2"><asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn" />
                    <asp:Label ID="Label2" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="c1">图片</td>
                    <td class="c2"><asp:FileUpload ID="FileUpload2" runat="server" CssClass="btn" />
                    <asp:Label ID="Label3" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                    <td class="c1">&nbsp;</td>
                    <td class="c2"><asp:Button ID="Button1" runat="server" Text="发布" OnClick="Button1_Click" CssClass="btn"  />                    
                    <asp:Label ID="Label1" runat="server"></asp:Label></td>
                  </tr>
                </tbody>
              </table> 
              <br />
              <br />
            </div>
          </div>
        </div>
    </form>
</body>
</html>

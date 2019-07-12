<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsdetail.aspx.cs" Inherits="newsdetail" %>

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
          <div id="title"><img src="images/titlelogo.jpg" width="10" height="27" alt=""/><img src="images/newsbrowser.jpg" width="219" height="27" alt=""/></div>
          <div id="news">
             <h1 class="newstitle"><asp:Label ID="lbltitle" runat="server"></asp:Label></h1>
           	<h2 class="newsinfo">
发布人
<asp:Label ID="lalauthor" runat="server" Text=" "></asp:Label>
<asp:Label ID="lblauthor" runat="server"></asp:Label>
&nbsp;发布时间
<asp:Label ID="lbldate" runat="server"></asp:Label>
</h2>
<div id="newsimg"> 
<asp:Image ID="Image1" runat="server"  CssClass="newsphoto" Width="300px" />
</div>
<p class="newsbody">
<asp:Label ID="lblbody" runat="server"></asp:Label>
</p>
<p class="newsfile">
<asp:HyperLink ID="HyperLink1" runat="server">下载附件</asp:HyperLink> 
</p>
          </div>
          <br />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 492px">
    <form id="form1" runat="server">
        <table>
        <tr>
          <td><asp:Label ID="Label1" runat="server" Text="Your E-mail Address:"></asp:Label></td>
          <td><asp:TextBox ID="txtmailadd" runat="server" Width="201px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Your E-mail Password:"></asp:Label></td>
            <td><asp:TextBox ID="txtmailpass" runat="server" Width="201px"></asp:TextBox></td>
        </tr>
        <tr>
           <td><asp:Label ID="Label3" runat="server" Text="To"></asp:Label></td> 
           <td><asp:TextBox ID="txtTo" runat="server" Width="220px"></asp:TextBox></td> 
         </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Subject:"></asp:Label></td>
            <td><asp:TextBox ID="txtsub" runat="server" Width="220px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label5" runat="server" Text="Attachment:"></asp:Label></td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" Width="301px" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label6" runat="server" Text="Message:"></asp:Label></td>
            <td><asp:TextBox ID="txtmsg" runat="server" Width="283px"></asp:TextBox></td>
        </tr>
        <tr>
        <td><asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Send Mail!!!" />
        </tr>
        <tr>
            <td><asp:Label ID="lblresult" runat="server" Text="[lblresult]"></asp:Label></td>
        </tr>
       </table> 
    </form>
</body>
</html>

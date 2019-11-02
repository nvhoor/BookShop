<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="DangNhap.aspx.cs" Inherits="BookShop.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Đăng nhập</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <link href="StyleSheet/reset.min.css" rel="stylesheet" data-noprefix/>
    <link href="StyleSheet/style.css" rel="stylesheet" data-noprefix/>
    <style type="text/css" media="screen">
    html,body{
      height: 100%;
    }  
    </style>
    <script src="JavaScript/prefixfree.min.js"></script>
  </head>
<body>
    <section class="container-fluid dangky text-center">
     <img src="images/background.jpg" alt="nen">
     <div id="dn-content" >
      <div class="text-left">
           <form id="form1" runat="server">
       <p class="text-center"><a href="Default.aspx" class="h1 text-center text-light">BookShop</a></p> 
  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Tài khoản:</label>
     <asp:TextBox ID="txtUsername" runat="server" type="text" class="form-control bg-dark text-light mb-1" />
      <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtUsername" ValidationExpression="^([\S\s]{4,20})$" ErrorMessage="Từ 4-20 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
  </div>
  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Mật khẩu:</label>
    <asp:TextBox ID="txtPass" runat="server" type="password" class="form-control bg-dark text-light mb-1" />
       <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtPass" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       
  </div>
              
   <div class="form-group form-check">
    <label class="form-check-label text-light mb-3 mt-2">
      <asp:CheckBox class="form-check-input" runat="server" ID="chkRemember"/>Ghi nhớ đăng nhập
    </label>
  </div>
               <p class="text-center text-warning"> <asp:CustomValidator runat="server" ID="valiCustom" OnServerValidate="valiCustom_ServerValidate" ErrorMessage="Đăng nhập thất bại!"></asp:CustomValidator></p>
  </div>
    
  <button type="submit" class="btn btn-primary bnt-dk-dk mr-2" id="btnDN" runat="server" onserverclick="btnDN_ServerClick">Đăng nhập</button>
  <a  class="btn btn-success bnt-dk-dk" href="DangKy.aspx" runat="server" causesvalidation="false" >Đăng ký</a>

     </div>
 </form>
    
   </section>
 
   
</body>
</html>

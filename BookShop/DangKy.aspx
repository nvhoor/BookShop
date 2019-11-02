<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="BookShop.DangKy" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Đăng ký</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
      <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    
    <link href="StyleSheet/reset.min.css" rel="stylesheet" data-noprefix/>
    <link href="StyleSheet/style.css" rel="stylesheet" data-noprefix/>
    <style type="text/css" media="screen">
    html,body{
      height: 100%;
    }  
    </style>
    <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/prefixfree.min.js"></script>
  </head>
  <body>
     
   <section class="container-fluid dangky text-center">
     <img src="images/background.jpg" alt="nen" />
     <div id="dk-content" >
      <div class="text-left">
   <form id="form1" runat="server" >
       <p class="text-center"><a href="Default.aspx" class="h1 text-center text-light">BookShop</a></p> 
  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Tài khoản:</label>
    <asp:TextBox ID="txtUsername" runat="server" type="text" class="form-control bg-dark text-light mb-1" />
   <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtUsername" ValidationExpression="^([\S\s]{4,20})$" ErrorMessage="Từ 4-20 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtUsername" ValidationExpression="^[a-zA-Z0-9]{0,255}$" ErrorMessage="Không chứa ký tự đặc biệt" Display="Dynamic"></asp:RegularExpressionValidator>
  </div>
  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Họ tên:</label>
    <asp:TextBox ID="txtHoTen" runat="server" type="text" class="form-control bg-dark text-light mb-1" />
       <asp:RequiredFieldValidator CssClass="valiDangKy  text-warning" runat="server" ControlToValidate="txtHoTen" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtHoTen" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtHoTen" ValidationExpression="^[a-z0-9A-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s]{0,255}$" ErrorMessage="Không chứa ký tự đặc biệt" Display="Dynamic"></asp:RegularExpressionValidator>
  </div>
  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Số điện thoại:</label>
    <asp:TextBox ID="txtSDT" runat="server" type="text" class="form-control bg-dark text-light mb-1" />
       <asp:RequiredFieldValidator CssClass="valiDangKy  text-warning" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="Nhập đúng số điện thoại" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator>
  </div>
  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Địa chỉ:</label>
    <asp:TextBox ID="txtDiaChi" runat="server" type="text" class="form-control bg-dark text-light mb-1" />
       <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtDiaChi" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtDiaChi" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
  </div>
  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Email:</label>
    <asp:TextBox ID="txtEmail" runat="server" type="text" class="form-control bg-dark text-light mb-1" />
       <asp:RequiredFieldValidator CssClass="valiDangKy text-warning " runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Nhập đúng định dạng email"></asp:RegularExpressionValidator>
  </div>
  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Ngày sinh:</label>
    <asp:TextBox  runat="server" id="datepicker"  class="form-control bg-dark text-light"  />
       <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="datepicker" Display="Dynamic"  ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="datepicker" Display="Dynamic" ErrorMessage="Nhập đúng ngày sinh" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></asp:RegularExpressionValidator>
    <script>
      $('#datepicker').datepicker({
          uiLibrary: 'bootstrap4',
          format: "dd/mm/yyyy",
          endDate: "now",
      });
      $('#datepicker').datepicker({
          format:'dd/MM/yyyy'
      });
    </script>
  </div>


  <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Mật khẩu:</label>
    <asp:TextBox ID="txtPass" runat="server" type="password" class="form-control bg-dark text-light mb-1" />
       <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtPass" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtPass" ValidationExpression="^([\S\s]{4,20})$" ErrorMessage="Từ 4-20 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
  </div>
   <div class="form-group mb-2 mt-2">
    <label class="text-light mb-1">Xác nhận mật khẩu:</label>
    <asp:TextBox ID="txtXNPass" runat="server" type="password" class="form-control bg-dark text-light mb-1" />
     <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtXNPass" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
    <asp:CompareValidator CssClass="valiDK text-warning" runat="server" ControlToCompare="txtPass" Display="Dynamic" ControlToValidate="txtXNPass" ErrorMessage="Mật khẩu không khớp"></asp:CompareValidator>
  </div> 
    <p class="text-center text-warning"> <asp:CustomValidator runat="server" ID="valiCustom" ErrorMessage="Tài khoản đã tồn tại!" OnServerValidate="valiCustom_ServerValidate"></asp:CustomValidator></p>
    <div class="text-center">
  <button type="submit" class="btn btn-primary bnt-dk-dk mr-2" runat="server" id="btnCreate" onserverclick="btnCreate_ServerClick">Tạo tài khoản</button>
  <button type="submit" class="btn btn-success bnt-dk-dk" id="btnDangNhap" causesvalidation="false" runat="server" onserverclick="btnDangNhap_ServerClick">Đăng nhập</button>
    </div>

</form>
     </div>
         </div>
   </section>

</body>
</html>
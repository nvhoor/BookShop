<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Default.Master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="BookShop.LienHe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="h1 text-center text-danger">Liên Hệ</div>
    <section class="container-fluid w-50 text-center mt-4">
      <table class="mx-auto table text-left">
        <tbody>
          <tr>
            <td>Họ tên</td>
            <td ><asp:TextBox runat="server" ID="txtHoTen" type="text" class="form-control" /></td>
              <td>
                  <asp:RequiredFieldValidator CssClass="valiDangKy  text-warning" runat="server" ControlToValidate="txtHoTen" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtHoTen" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
              </td>
          </tr>
          <tr>
            <td>Địa chỉ</td>
            <td ><asp:TextBox runat="server" ID="txtDiaChi" type="text" class="form-control" /></td>
           
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtDiaChi" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Số điện thoại</td>
            <td ><asp:TextBox runat="server" ID="txtSDT" type="text" class="form-control" /></td>
             
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="Nhập đúng số điện thoại" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Email</td>
            <td ><asp:TextBox runat="server" ID="txtEmail" type="text" class="form-control" /></td>
               
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Nhập đúng định dạng email"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Fax</td>
            <td ><asp:TextBox runat="server" ID="txtFax" type="text" class="form-control" /></td>
            
     <td> <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtFax" Display="Dynamic" ValidationExpression="^(\+?\d{1,}(\s?|\-?)\d*(\s?|\-?)\(?\d{2,}\)?(\s?|\-?)\d{3,}\s?\d{3,})$" ErrorMessage="Nhập đúng định dạng Fax"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Nội dung</td>
            <td ><asp:TextBox  runat="server" style="height:500px" CssClass="form-control text" id="text" name="text" placeholder="Nhập nội dung ở đây" TextMode="MultiLine" type="text"  /><h6 style="font-size:0.8em" class="count_message pull-right mt-1 text-secondary"></h6></td>
              <script type="text/javascript">
                  var text_max = 3000;
                  $('.count_message').html('Giới hạn còn '+text_max +' từ');
                  $('.text').keyup(function () {
                      var text_length = $('.text').val().length;
                      var text_remaining = text_max - text_length;

                      $('.count_message').html('Giới hạn còn ' + text_remaining +' từ');
                  });
              </script>
           <td>  <asp:RequiredFieldValidator CssClass="valiDangKy text-warning " runat="server" ControlToValidate="text" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator> <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="text" ValidationExpression="^([\S\s]{4,3000})$" ErrorMessage="Từ 4-3000 ký tự" Display="Dynamic"></asp:RegularExpressionValidator></td>
          </tr>
        </tbody>
      </table>
      <asp:Button id="btnXacNhan"  type="button" class="btn-lg btn-info" runat="server"  Text="Xác nhận" OnClick="btnXacNhan_Click"></asp:Button>
       
    </section>
    <div style="height:300px;"></div>
</asp:Content>

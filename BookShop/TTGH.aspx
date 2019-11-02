<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Default.Master" AutoEventWireup="true" CodeBehind="TTGH.aspx.cs" Inherits="BookShop.TTGH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thông tin giao hàng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="h1 text-center text-danger">Nhập thông tin giao hàng</div>
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
             <td> <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtDiaChi" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtDiaChi" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Số điện thoại</td>
            <td ><asp:TextBox runat="server" ID="txtSDT" type="text" class="form-control" /></td>
              <td><asp:RequiredFieldValidator CssClass="valiDangKy  text-warning" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="Nhập đúng số điện thoại" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Email</td>
            <td ><asp:TextBox runat="server" ID="txtEmail" type="text" class="form-control" /></td>
               <td> <asp:RequiredFieldValidator CssClass="valiDangKy text-warning " runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Nhập đúng định dạng email"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Fax</td>
            <td ><asp:TextBox runat="server" ID="txtFax" type="text" class="form-control" /></td>
            
     <td> <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtFax" Display="Dynamic" ValidationExpression="^(\+?\d{1,}(\s?|\-?)\d*(\s?|\-?)\(?\d{2,}\)?(\s?|\-?)\d{3,}\s?\d{3,})$" ErrorMessage="Nhập đúng định dạng Fax"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Công ty</td>
            <td ><asp:TextBox runat="server" ID="txtCTy" type="text" class="form-control" /></td>
           <td>   <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtCTy" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator></td>
          </tr>
        </tbody>
      </table>
      <asp:Button id="btnXacNhan"  type="button" class="btn btn-info" runat="server"  Text="Xác nhận" OnClick="btnXacNhan_Click"></asp:Button>
       
    </section>
    <div style="height:500px;"></div>
</asp:Content>

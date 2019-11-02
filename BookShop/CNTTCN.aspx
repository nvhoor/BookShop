<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Default.Master" AutoEventWireup="true" CodeBehind="CNTTCN.aspx.cs" Inherits="BookShop.CNTTCN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Cập nhật thông tin cá nhân</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="h1 text-center text-danger">Cập nhật thông tin cá nhân</div>
    <section class="container-fluid w-50 text-center mt-4">
      <table class="mx-auto table text-left">
        <tbody>
          <tr>
            <td>Họ tên</td>
            <td class="pb-2"><asp:TextBox ID="txtHoTen" runat="server" type="text" class="form-control " /></td>
              <td> <asp:RequiredFieldValidator CssClass="valiDangKy  text-warning" runat="server" ControlToValidate="txtHoTen" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtHoTen" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Địa chỉ</td>
            <td class="pb-2"><asp:TextBox ID="txtDiaChi" runat="server" type="text" class="form-control" /></td>
              <td> <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtDiaChi" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtDiaChi" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Số điện thoại</td>
            <td class="pb-2"><asp:TextBox ID="txtSDT" runat="server" type="text" class="form-control" /></td>
              <td><asp:RequiredFieldValidator CssClass="valiDangKy  text-warning" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="Nhập đúng số điện thoại" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Email</td>
            <td class="pb-2"><asp:TextBox ID="txtEmail" runat="server" type="text" class="form-control" /></td>
              <td> <asp:RequiredFieldValidator CssClass="valiDangKy text-warning " runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Nhập đúng định dạng email"></asp:RegularExpressionValidator></td>
          </tr>
             <tr>
            <td>Ngày sinh</td>
            <td class="pb-2"><asp:TextBox ID="txtNgaySinh" runat="server" type="text" class="form-control" /></td>
                 <td><asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtNgaySinh" Display="Dynamic"  ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtNgaySinh" Display="Dynamic" ErrorMessage="Nhập đúng ngày sinh" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Mật khẩu</td>
            <td class="pb-2"><asp:TextBox ID="txtPass" runat="server" type="password" class="form-control" /></td>
              <td> <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtPass" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ControlToValidate="txtPass" ValidationExpression="^([\S\s]{4,20})$" ErrorMessage="Từ 4-20 ký tự" Display="Dynamic"></asp:RegularExpressionValidator></td>
          </tr>
          <tr>
            <td>Xác nhận</td>
            <td class="pb-2"><asp:TextBox ID="txtXNPass" runat="server" type="password" class="form-control" /></td>
              <td><asp:RequiredFieldValidator CssClass="valiDangKy text-warning" runat="server" ControlToValidate="txtXNPass" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
    <asp:CompareValidator CssClass="valiDK text-warning" runat="server" ControlToCompare="txtPass" Display="Dynamic" ControlToValidate="txtXNPass" ErrorMessage="Mật khẩu không khớp"></asp:CompareValidator></td>
          </tr>
        </tbody>
      </table>
      <button id="btnXacNhan" runat="server" onserverclick="btnXacNhan_ServerClick" type="button" class="btn btn-info">Xác nhận</button>
    </section>
    <div style="height:500px;"></div>
    <asp:HiddenField  runat="server" ID="hduser" Value=""/>
    <asp:HiddenField  runat="server" ID="hdadmin" Value=""/>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true" CodeBehind="QLKH.aspx.cs" Inherits="BookShop.QLKH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Quản lý khách hàng</title>
     <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
             <nav class="navbar navbar-expand-sm bg-light navbar-light">
            <div class="form-inline m-auto" >
              <asp:TextBox runat="server" ID="txtTimKiem" class="form-control mr-sm-2"  placeholder="Nhập mã tên tài khoản..." />
              <button runat="server" id="btnTimKiem" onserverclick="btnTimKiem_ServerClick" class="btn btn-success" type="submit">Tìm kiếm</button>
            </div>
          </nav>
      <div class="container-fluid">
            <div class="w-50 mx-auto">
              <div class="form-group">
                <label >Tài khoản</label>
                <asp:TextBox runat="server" type="text" class="form-control" placeholder="" ID="txtTaiKhoan" />
              </div>
              <div class="form-group">
                <label >Họ tên</label>
                <asp:TextBox runat="server" type="text" class="form-control" placeholder="" ID="txtHoTen" />
              </div>
              
              
              <div class="form-group">
                <label >Địa chỉ</label>
                <asp:TextBox runat="server" type="text" class="form-control" placeholder="" ID="txtDiaChi" />
              </div>
              <div class="form-group">
                <label >Ngày sinh</label>
                <asp:TextBox runat="server" type="text" class="form-control" placeholder="" ID="txtNgaySinh" />
              </div>
              <div class="form-group">
                <label >Số điện thoại</label>
                <asp:TextBox runat="server" type="text" class="form-control" placeholder="" ID="txtSoDienThoai" />
              </div>
              <div class="form-group">
                <label >Email</label>
               <asp:TextBox runat="server" ID="txtEmail" type="text" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Mật khẩu</label>
                <asp:TextBox runat="server" type="password" class="form-control" placeholder="" ID="txtMatKhau" />
              </div>
               <div class="form-group">
                <label for="drTrangThai">Trạng thái</label>
               <asp:DropDownList CssClass="form-control" runat="server" ID="drTrangThai">
                   <asp:ListItem Selected="True">Kích hoạt</asp:ListItem>
                   <asp:ListItem>Vô hiệu</asp:ListItem>
               </asp:DropDownList>
              </div>
            </div>
            
          </div>
          <div class="text-center mt-3">
            <button runat="server" type="button" id="btnThem" onserverclick="btnThem_ServerClick" class="btn-lg btn-primary mt-3 mr-3">Thêm</button>
              <button type="button" runat="server" id="btnCapNhat" onserverclick="btnCapNhat_ServerClick" class="btn-lg btn-success mt-3">Cập nhật</button>
          </div>
          <p class="text-info h2">Danh sách khách hàng</p>
          <div class="table-responsive-lg  row overflow-auto tb-sp-sm">
              <asp:Repeater runat="server" ID="rpKhachHang" OnItemCommand="rpKhachHang_ItemCommand">
                  <HeaderTemplate>
                      <table class="table table-striped table-bordered table-hover text-center tb-giohang">
          <thead class="thead-dark sticky-top">
            <tr>
              <th scope="col">Tài khoản</th>
              <th scope="col">Họ tên</th>
              <th scope="col">Địa chỉ</th>
              <th scope="col">Ngày sinh</th>
              <th scope="col">Email</th>
               <th scope="col">Số điện thoại</th>   
              <th scope="col">Trạng thái</th>
            </tr>
          </thead>
          <tbody>
                  </HeaderTemplate>
                  <ItemTemplate>
                       <tr>
              <td><%#:Eval("USERNAME")%></td>
              <td><asp:LinkButton runat="server" CommandArgument='<%#:Eval("USERNAME")%>' Text='<%#:Eval("HOTEN")%>'></asp:LinkButton></td>
               <td><%#:Eval("DIACHI")%></td>
                <td><%#:Eval("NGAYSINH","{0:d}") %></td>
                 <td><%#: Eval("EMAIL")%></td>
                 <td><%#:Eval("DIENTHOAI") %></td>
                 <td><%#:Eval("TRANGTHAI") %></td>
            </tr>
                  </ItemTemplate>
                  <FooterTemplate>
</tbody>
        </table>
                  </FooterTemplate>
              </asp:Repeater>
            
           
          
          
          </div>
      
   
        
</asp:Content>

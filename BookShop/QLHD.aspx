<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true" CodeBehind="QLHD.aspx.cs" Inherits="BookShop.QLHD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Quản lý hoá đơn</title>
     <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
             <nav class="navbar navbar-expand-sm bg-light navbar-light">
            <div class="form-inline m-auto" >
              <asp:TextBox runat="server" ID="txtTimKiem" class="form-control mr-sm-2" type="text" placeholder="Nhập mã hoá đơn..." />
              <button runat="server" id="btnTimKiem" onserverclick="btnTimKiem_ServerClick" class="btn btn-success" type="submit">Tìm kiếm</button>
            </div>
          </nav>
      <div class="container-fluid row">
            <div class="col-lg-4 border-right">
         
              <div class="form-group">
                <label >Mã hoá đơn</label>
                <asp:TextBox runat="server" ID="txtMaHD" type="text" class="form-control" placeholder="" readonly/>
              </div>
              <div class="form-group">
                <label >Tài khoản</label>
                <asp:TextBox runat="server" ID="txtTaiKhoan" type="text" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Họ tên</label>
                <asp:TextBox runat="server" ID="txtHoTen" type="text" class="form-control" placeholder="" />
              </div>
              
              
              <div class="form-group">
                <label >Địa chỉ</label>
                <asp:TextBox runat="server" ID="txtDiaChi" type="text" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Số điện thoại</label>
                <asp:TextBox runat="server" ID="txtSDT" type="text" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Email</label>
               <asp:TextBox runat="server" ID="txtEmail" type="text" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Fax</label>
               <asp:TextBox runat="server" ID="txtFax" type="text" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Công ty</label>
               <asp:TextBox runat="server" ID="txtCongTy" type="text" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Tình trạng</label>
               <asp:TextBox runat="server" ID="txtTinhTrang" type="text" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Tổng tiền</label>
               <asp:Label runat="server" ID="lblTongTien" for="" CssClass="h2 text-danger form-control">523.000 VND</asp:Label>
               
              </div>
               <div class="form-group">
                <label for="drTrangThai">Trạng thái</label>
               <asp:DropDownList CssClass="form-control" runat="server" ID="drTrangThai">
                   <asp:ListItem Selected="True">Kích hoạt</asp:ListItem>
                   <asp:ListItem>Vô hiệu</asp:ListItem>
               </asp:DropDownList>
              </div>
            </div>
            <div class="col-lg ml-2">
              <div class="row">
               <div class="col">
                 <div class="form-group">
                <label >Mã sản phẩm</label>
                <asp:TextBox runat="server" ID="txtMaSP" type="text" class="form-control" placeholder="" />
              </div>
               </div>
               <div class="col">
                 <div class="form-group">
                <label >Số lượng</label>
                <asp:TextBox runat="server" ID="txtSoLuong" type="number" class="form-control" value="1" min="1" max="100" />
              </div>
               </div>
                <div class="col">
                 <button runat="server" id="btnThemVaoHD" onserverclick="btnThemVaoHD_ServerClick" type="button" class="btn btn-primary mt-3 mr-3">Thêm vào hoá đơn</button>
               </div>
              </div>
            
                  <div class="table-responsive-lg  row overflow-auto tb-sp-sm">
                      <asp:Repeater runat="server" ID="rpDSSanPham" OnItemCommand="rpDSSanPham_ItemCommand">
                          <HeaderTemplate>
                               <table class="table table-striped table-bordered table-hover text-center tb-giohang ">
          <thead class="thead-dark sticky-top">
            <tr>
              <th scope="col">Mã sản phẩm</th>
              <th scope="col">Tên sản phẩm</th>
              <th scope="col">Số lượng mua</th>
              <th scope="col">Đơn giá</th>
                <th scope="col">Thành tiền</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
                          </HeaderTemplate>
                          <ItemTemplate>
                               <tr>
              <td><%#:Eval("MASP") %></td>
              <td><%#:Eval("TENSP") %></td>
                <td><%#:Eval("SOLUONG") %></td>
                 <td><%#:Eval("DONGIA") %></td>
                 <td><%#:Eval("THANHTIEN") %></td>
                 <td><asp:LinkButton runat="server" ID="lnkXoa" OnLoad="lnkXoa_Load" CommandArgument='<%#:Eval("MAHD")+"|"+ Eval("MASP")%>' Text="Xoá"></asp:LinkButton></td>
            </tr>
                          </ItemTemplate>
                          <FooterTemplate>
                              
          </tbody>
        </table>
                          </FooterTemplate>
                      </asp:Repeater>
                
           

                    </div>
             
            </div>
          </div>
          <div class="text-center mt-3">
            <button runat="server" id="btnThem" onserverclick="btnThem_ServerClick" type="button" class="btn-lg btn-primary mt-3 mr-3">Thêm</button>
              <button runat="server" id="btnCapNhat" onserverclick="btnCapNhat_ServerClick" type="button" class="btn-lg btn-success mt-3">Cập nhật</button>
          </div>
          <p class="text-info h2">Danh sách danh mục sản phẩm</p>
        <div class="table-responsive-lg  row overflow-auto tb-sp-sm">
            <asp:Repeater runat="server" ID="rpDSHoaDon" OnItemCommand="rpDSHoaDon_ItemCommand">
                <HeaderTemplate>
                     <table class="table table-striped table-bordered table-hover text-center tb-giohang">
          <thead class="thead-dark sticky-top">
            <tr>
              <th scope="col">Mã hoá đơn</th>
              <th scope="col">Tài khoản</th>
              <th scope="col">Họ tên</th>
              <th scope="col">Địa chỉ</th>
            <th scope="col">Số điện thoại</th>
            <th scope="col">Email</th>
            
            <th scope="col">Tình trạng</th>
            <th scope="col">Tổng tiền</th>
            <th scope="col">Trạng thái</th>
            </tr>
          </thead>
          <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
              <td><asp:LinkButton runat="server" ID="lnkMaHD" CommandArgument='<%#:Eval("MAHD")%>' Text='<%#:Eval("MAHD") %>'></asp:LinkButton></td>
              <td><%#:Eval("USERNAME") %></td>
            <td><%#:Eval("HOTEN") %></td>
            <td><%#:Eval("DIACHI") %></td>
            <td><%#:Eval("DIENTHOAI") %></td>
            <td><%#:Eval("EMAIL") %></td>
            <td><%#:Eval("TINHTRANG") %></td>
            <td><%#:Eval("TONGTIEN") %></td>
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

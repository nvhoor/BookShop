<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true" CodeBehind="QLLH.aspx.cs" Inherits="BookShop.QLLH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .bc-icons-2 .breadcrumb-item + .breadcrumb-item::before {
content: none; }
.bc-icons-2 .breadcrumb-item.active {
color: #455a64; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="h1 text-center text-danger">LIÊN HỆ KHÁCH HÀNG</div>
      <div class="container-fluid">

            <div class="w-50 mx-auto">
              <div class="form-group">
                <label >Họ tên</label>
                <asp:TextBox runat="server"   type="text" class="form-control" placeholder="" ID="txtHoTen" readonly/>
              <div class="form-group">
                <label >Địa chỉ</label>
                <asp:TextBox runat="server"   type="text" class="form-control" placeholder="" ID="txtDiaChi" readonly/>
              </div>
              <div class="form-group">
                <label >Số điện thoại</label>
                <asp:TextBox runat="server" type="text" class="form-control" placeholder="" ID="txtSoDienThoai" readonly/>
              </div>
              <div class="form-group">
                <label >Email</label>
               <asp:TextBox runat="server"    ID="txtEmail" type="text" class="form-control" placeholder="" readonly/>
              </div>
                <div class="form-group">
                <label >Fax</label>
               <asp:TextBox runat="server"    ID="txtFax" type="text" class="form-control" placeholder="" readonly/>
              </div>
                 <div class="form-group">
                <label >Nội dung</label>
                 <asp:TextBox  runat="server" style="height:500px" CssClass="form-control text" id="text" name="text" TextMode="MultiLine" type="text"  readonly/>
              </div>  
                   <div class="form-group">
                <label >Ngày tạo</label>
                  <asp:TextBox runat="server"    ID="txtNgayTao" type="text" class="form-control" placeholder="" readonly/>
              </div> 
               <div class="form-group">
                <label for="drTrangThai">Trạng thái</label>
               <asp:DropDownList  Enabled="false"  CssClass="form-control" runat="server" ID="drTrangThai">
                   <asp:ListItem Selected="True">Kích hoạt</asp:ListItem>
                   <asp:ListItem>Vô hiệu</asp:ListItem>
               </asp:DropDownList>
              </div>
            </div>
            </div>
         </div>
         
    <p class="text-info h2">Danh sách liên hệ</p>
          <div class="table-responsive-lg  row overflow-auto tb-sp-sm">
              <asp:Repeater runat="server" ID="rpLienHe" OnItemCommand="rpLienHe_ItemCommand">
                  <HeaderTemplate>
                      <table class="table table-striped table-bordered table-hover text-center tb-giohang">
          <thead class="thead-dark sticky-top">
            <tr>
              <th scope="col">Mã liên hệ</th>
              <th scope="col">Họ tên</th>
              <th scope="col">Địa chỉ</th>
              <th scope="col">Email</th>
               <th scope="col">Số điện thoại</th> 
                <th scope="col">Fax</th> 
                 <th scope="col">Ngày tạo</th>
              <th scope="col">Trạng thái</th>
            </tr>
          </thead>
          <tbody>
                  </HeaderTemplate>
                  <ItemTemplate>
                       <tr>
              <td><asp:LinkButton runat="server" CommandArgument='<%#:Eval("MALH")%>' Text='<%#:Eval("MALH")%>'></asp:LinkButton></td>
              <td><%#:Eval("HOTEN")%></td>
               <td><%#:Eval("DIACHI")%></td>
              
                 <td><%#: Eval("EMAIL")%></td>
                 <td><%#:Eval("DIENTHOAI") %></td>
                <td><%#:Eval("FAX") %></td>
                <td><%#:Eval("NGAYTAO","{0:d}") %></td>
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

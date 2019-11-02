<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true" CodeBehind="QLDM.aspx.cs" Inherits="BookShop.QLDM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Quản lý danh mục</title>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
             <nav class="navbar navbar-expand-sm bg-light navbar-light">
            <div class="form-inline m-auto" >
              <asp:TextBox ID="txtTimKiem" runat="server" class="form-control mr-sm-2" placeholder="Nhập mã danh mục..." />
              <asp:Button  class="btn btn-success" runat="server" Text="Tìm kiếm" ID="btnTimKiem" OnClick="btnTimKiem_Click"/>
            </div>
          </nav>
          <div class="container-fluid row">
            <div class="col-lg-4 border-right">
         
              <div class="form-group">
                <label >Mã danh mục</label>
                <asp:TextBox ID="txtMaDM" runat="server" class="form-control" placeholder="" readonly/>
              </div>
              <div class="form-group">
                <label >Tên danh mục</label>
                <asp:TextBox ID="txtTenDM" runat="server" class="form-control" placeholder="" />
              </div>
              <div class="form-group">
                <label >Ghi chú</label>
                <asp:TextBox ID="txtGhiChu" runat="server" TextMode="MultiLine" class="form-control h-100"></asp:TextBox>
              </div> 
              
              
              <div class="form-group">
                <label for="slTragnThai">Trạng thái</label>
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
                <asp:TextBox runat="server" class="form-control" placeholder="" id="txtMaSP"/>
              </div>
               </div>
                <div class="col">
                 <asp:Button runat="server" class="btn btn-primary mt-3 mr-3" Text="Thêm vào danh mục" id="btnThemVaoDM" OnClick="btnThemVaoDM_Click"/>
               </div>
              </div>
              
                  <div class="table-responsive-lg row overflow-auto tb-sp-sm">
                      <asp:Repeater runat="server" ID="rpSPTheoDM">
                          <HeaderTemplate><table class="table table-striped table-bordered table-hover text-center tb-giohang mx-3">
          <thead class="thead-dark sticky-top">
            <tr>
              <th scope="col">Mã sản phẩm</th>
              <th scope="col">Tên sản phẩm</th>
              <th scope="col">Số lượng</th>
               <th scope="col">Tác giả</th>
              <th scope="col">Đơn giá</th>
              <th scope="col">Trạng thái</th>

            </tr>
          </thead>
          <tbody></HeaderTemplate>
                          <ItemTemplate> <tr>
              <td><%#:Eval("MASP")%></td>
              <td><%#:Eval("TENSP")%></td>
        
                <td><%#:Eval("SOLUONGBAN")%></td>
                 <td><%#:Eval("TACGIA")%></td>
                 <td><%#:String.Format("{0:n0}",Eval("DONGIA")) %></td>
                 <td><%#:Eval("TRANGTHAI")%></td>
            </tr>
</ItemTemplate>
                          <FooterTemplate></tbody>
        </table></FooterTemplate>
                      </asp:Repeater>
                 
           
          
                      </div>
          
            </div>
          </div>
          <div class="text-center mt-3">
            <button type="button" id="btnThem" class="btn-lg btn-primary mt-3 mr-3" runat="server" onserverclick="btnThem_ServerClick">Thêm</button>
              <button type="button" class="btn-lg btn-success mt-3" runat="server" onserverclick="btnCapNhat_ServerClick" id="btnCapNhat">Cập nhật</button>
          </div>
          <p class="text-info h2">Danh sách danh mục sản phẩm</p>
     <div class="table-responsive-lg row overflow-auto tb-sp-sm">
         <asp:Repeater runat="server" ID="rpDanhMuc" OnItemCommand="rpDanhMuc_ItemCommand">
             <HeaderTemplate> <table class="table table-striped table-bordered table-hover text-center tb-giohang mx-3">
          <thead class="thead-dark sticky-top">
            <tr>
              <th scope="col">Mã danh mục</th>
              <th scope="col">Tên danh mục</th>
              <th scope="col">Ghi chú</th>
              <th scope="col">Trạng thái</th>
            </tr>
          </thead>
          <tbody></HeaderTemplate>
             <ItemTemplate> <tr>
              <td><%#:Eval("MADM")%></td>
              <td><asp:LinkButton runat="server" CommandArgument='<%#:Eval("MADM")%>' Text='<%#:Eval("TENDM")%>'></asp:LinkButton></td>
                <td ><%#:Eval("GHICHU")%></td>
                 <td><%#:Eval("TRANGTHAI")%></td>
            </tr></ItemTemplate>
             <FooterTemplate></tbody>
        </table></FooterTemplate>
         </asp:Repeater>
         </div>
       
    
</asp:Content>

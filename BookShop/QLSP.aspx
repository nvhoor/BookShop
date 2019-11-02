<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="QLSP.aspx.cs" Inherits="BookShop.QLSP" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Quản lý sản phẩm</title>
      
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <nav class="navbar navbar-expand-sm bg-light navbar-light">
            <div class="form-inline m-auto" >
                <asp:RegularExpressionValidator ValidationGroup="grTim" runat="server" CssClass="text-warning valiDK" ControlToValidate="txtTimKiem" ValidationExpression="^([\S\s]{0,25})$" ErrorMessage="Giới hạn 25 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
             <asp:CustomValidator runat="server"  CssClass="text-warning valiDK" ErrorMessage="Không tìm thấy kết quả" ValidationGroup="grTim" ControlToValidate="txtTimKiem" OnServerValidate="tim_Validate"></asp:CustomValidator>
                 <asp:TextBox runat="server" ID="txtTimKiem" CssClass="form-control mr-sm-2" placeholder="Nhập mã sản phẩm..." />
              <asp:Button runat="server" ID="btnTimKiem" ValidationGroup="grTim" class="btn btn-success" type="submit" Text="Tìm kiếm" OnClick="btnTimKiem_Click" />
            </div>
          </nav>
      <div class="container-fluid row">
            <div class="col-lg-4">
              <div class="form-group">
  <label >Chọn danh mục:</label>
                  <asp:DropDownList CssClass="form-control" runat="server" ID="drDanhMuc">
                       
                  </asp:DropDownList>

</div>
              <div class="form-group">
                <label >Mã sản phẩm</label>
                <asp:TextBox runat="server" ID="txtMaSP" CssClass="form-control" readonly/>
              </div>
              <div class="form-group">
                <label >Tên sản phẩm</label>
                <asp:TextBox runat="server" ID="txtTenSP" CssClass="form-control"/>
                  <asp:RequiredFieldValidator CssClass="valiDangKy text-warning" ValidationGroup="grSanPham" runat="server" ControlToValidate="txtTenSP" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                  
                  <asp:RegularExpressionValidator runat="server" CssClass="text-warning valiDK" ValidationGroup="grSanPham" ControlToValidate="txtTenSP" ValidationExpression="^([\S\s]{1,255})$" ErrorMessage="Từ 1-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
              </div>
              
              
              <div class="form-group">
                <label >Số lượng</label>
                <asp:TextBox runat="server" ID="txtSoLuong" type="number"  class="form-control" name="quantity" min="0" max="1000" value="1" />
              </div>
              <div class="form-group">
                <label >Đơn giá</label>
                <asp:TextBox runat="server" ID="txtDonGia" type="number"  class="form-control" name="quantity" min="0" max="10000000000"  CssClass="form-control" />
              </div>
       
              <div class="form-group ">
                <label>Hình ảnh</label><asp:HiddenField runat="server" ID="hdImage" Value=""/>
                 <asp:Image runat="server" style="max-width:250px; margin-left:1em;" id="blah" CssClass="imgHinhAnh" alt="your image" />
              </div>
                
                <div class="custom-file form-group">
                <label ></label>
                 <asp:FileUpload CssClass="imgInp custom-file-input" type='file' accept="image/x-png,image/gif,image/jpeg" id="flImage" runat="server"/>
                <label class="custom-file-label" for="flImage">Chọn file ảnh</label>
              </div>
              <div class="form-group mt-2">
                <label >Số trang</label>
                <asp:TextBox runat="server" ID="txtSoTrang" type="number" class="form-control" name="quantity" min="1" max="10000" value="50" />
              </div>
                <div class="form-group">
                <label >Tác giả</label>
                <asp:TextBox runat="server" ID="txtTacGia"  CssClass="form-control"  />
                    <asp:RegularExpressionValidator runat="server" ValidationGroup="grSanPham" CssClass="text-warning valiDK" ControlToValidate="txtTacGia" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
              </div>
              <div class="form-group">
                <label >Nhà xuất bản</label>
                <asp:TextBox runat="server" ID="txtNXB"  CssClass="form-control"  />
                  <asp:RegularExpressionValidator runat="server" ValidationGroup="grSanPham" CssClass="text-warning valiDK" ControlToValidate="txtNXB" ValidationExpression="^([\S\s]{4,255})$" ErrorMessage="Từ 4-255 ký tự" Display="Dynamic"></asp:RegularExpressionValidator>
              </div>
              
              <div class="form-group">
                <label for="slTragnThai">Trạng thái</label>
               <asp:DropDownList CssClass="form-control" runat="server" ID="drTrangThai">
                   <asp:ListItem Selected="True">Kích hoạt</asp:ListItem>
                   <asp:ListItem>Vô hiệu</asp:ListItem>
               </asp:DropDownList>
              </div>
            </div>
            <div class="col-lg">
              <div class="form-group h-100">
                <label >Mô tả</label>
                  <FTB:FreeTextBox ID="txtMoTa" Height="850px" PasteMode="Text" ImageGalleryPath="~/images/" Width="100%" EnableHtmlMode="false" ToolbarLayout=" ParagraphMenu, FontFacesMenu, FontSizesMenu, FontForeColorsMenu, 
 FontForeColorPicker, FontBackColorsMenu, FontBackColorPicker| Bold, Italic, Underline,
 Strikethrough, Superscript, Subscript| InsertImageFromGallery, CreateLink, Unlink, 
 RemoveFormat, JustifyLeft, JustifyRight, JustifyCenter, JustifyFull, BulletedList, 
 NumberedList, Indent, Outdent| Cut, Copy, Paste, Delete, Undo, Redo, Print, Save, 
 ieSpellCheck, StyleMenu, SymbolsMenu|InsertRule, InsertDate, 
 InsertTime, WordClean, InsertImage, InsertTable, EditTable, InsertTableRowBefore, 
 InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, 
 DeleteTableColumn, InsertForm, InsertForm, InsertTextBox, InsertTextArea, 
 InsertRadioButton, InsertCheckBox, InsertDropDownList, InsertButton, InsertDiv, 
 InsertImageFromGallery, Preview, SelectAll, EditStyle" runat="server"></FTB:FreeTextBox>
              </div>  
            </div>
          </div>
          <div class="text-center mt-3">
            <asp:Button runat="server" ID="btnThem" ValidationGroup="grSanPham" CssClass="btn-lg btn-primary mt-3 mr-3" Text="Thêm" OnClick="btnThem_Click" />
              <asp:Button runat="server" ID="btnCapNhat" ValidationGroup="grSanPham" CssClass="btn-lg btn-success mt-3" Text="Cập nhật" OnClick="btnCapNhat_Click" />
          </div>
    
          <p class="text-info h2">Danh sách sản phẩm</p>
          <div class="table-responsive-lg row overflow-auto tb-sp-sm">
              <asp:Repeater runat="server" ID="rpDSSanPham" OnItemCommand="rpDSSanPham_ItemCommand">
                  <HeaderTemplate>
                       <table class="table table-striped table-bordered table-hover text-center tb-giohang">
          <thead class="thead-dark sticky-top">
            <tr>
              <th scope="col">Mã sản phẩm</th>
              <th scope="col">Tên sản phẩm</th>
              <th scope="col">Tên danh mục</th>
              <th scope="col">Số lượng</th>
               <th scope="col">Tác giả</th>
                <th scope="col">Nhà xuất bản</th>
                 <th scope="col">Số trang</th>
              <th scope="col">Đơn giá</th>
              <th scope="col">Trạng thái</th>
               
            </tr>
          </thead>
          <tbody>
                  </HeaderTemplate>
                  <ItemTemplate>
  <tr>
              <td><%#:Eval("MASP") %></td>
              <td><asp:LinkButton runat="server" CommandArgument='<%#:Eval("MASP")%>' Text='<%#:Eval("TENSP")%>' CommandName="capnhat"></asp:LinkButton></td>
               <td><%#:Eval("TENDM")%></td>
                <td><%#:Eval("SOLUONGBAN") %></td>
                 <td><%#:Eval("TACGIA") %></td>
                 <td><%#:Eval("NXB")%></td>
                 <td><%#:Eval("SOTRANG") %></td>
                 <td><%#:String.Format("{0:n0}",Eval("DONGIA"))%></td>
                 <td><a href="#"><%#:Eval("TRANGTHAI")%></a></td>
               
            </tr>
                  </ItemTemplate>
                  <FooterTemplate>
                        
          </tbody>
        </table>
                  </FooterTemplate>
              </asp:Repeater>
           
          
         
          </div>
       </ContentTemplate>
           <Triggers>
                    <asp:PostBackTrigger ControlID="btnThem"/>
                      <asp:PostBackTrigger ControlID="btnCapNhat"/>
                </Triggers>
            </asp:UpdatePanel>
</asp:Content>

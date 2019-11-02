<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Default.Master" AutoEventWireup="true" ResponseEncoding="utf-8" CodeBehind="GioHang.aspx.cs" Inherits="BookShop.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Giỏ hàng</title>
    <style type="text/css">
        .auto-style2 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="h1 text-center text-danger">Giỏ Hàng</div>
    <div class="container-fluid row w-75 mx-auto" >
      <div class="col-lg-7">
        <p class="text-info h2">Danh sách sản phẩm</p>
          <div class="table-responsive-lg row overflow-auto tb-sp-sm">
              
                      <table class="table table-striped table-bordered table-hover text-center tb-giohang">
          <thead class="thead-dark sticky-top">
            <tr>
              <th scope="col">Sản phẩm</th>
              <th scope="col">Giá</th>
              <th scope="col">Số lượng</th>
              <th scope="col">Thành tiền</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
                  <asp:Repeater runat="server" ID="rpGioHang" EnableViewState="true" OnItemCommand="rpGioHang_ItemCommand">
                     <ItemTemplate>
                          <tr>
              <td><%#:Eval("TENSP")%></td>
               <td><%#:string.Format("{0:n0}",Eval("DONGIA")) %> VND</td>
                <td><asp:TextBox CausesValidation="true" CssClass="form-control" AutoPostBack="true" ID="txtSL" EnableViewState="true" runat="server" type="number" name="quantity" min="1" max='<%#:Eval("SLTON")%>' value='<%#:Eval("SOLUONG") %>' /><asp:RangeValidator CssClass="text-danger valid-feedback" runat="server" ID="valiGiaTri" Display="Dynamic" ControlToValidate="txtSL" MinimumValue="1" MaximumValue='<%#:Eval("SLTON")%>' ErrorMessage='<%#:"1-"+Eval("SLTON")%>' Type="Integer"></asp:RangeValidator></td>
                 <td><%#:string.Format("{0:n0}",Eval("THANHTIEN")) %> VND</td>
                 <td><asp:LinkButton ID="lnkXoa" OnLoad="lnkXoa_Load" runat="server" Text="Xoá"></asp:LinkButton></td>
            </tr>
                     </ItemTemplate>     
                  </asp:Repeater>
                     
         
               
                       </tbody>
        </table>
                  
        
            
              </div>
          <asp:Label runat="server" ID="lblt"></asp:Label>
        <a  href="Default.aspx" class="btn btn-info">Thêm sản phẩm</a> <asp:Button class="btn btn-danger ml-2" runat="server" ID="btnXoaGH" Text="Xóa giỏ hàng" OnClick="btnXoaGH_Click"></asp:Button>
      </div>
      <div class="col-lg-5 mt-5">
       <p style="font-size: 2em;" class="text-primary">Tổng cộng: </p>
       <p class="h1 text-danger"><asp:Label runat="server" ID="lblTongTien"></asp:Label></p>
       <a runat="server" id="lnkTTTrucTiep" onserverclick="lnkTTTrucTiep_ServerClick" class="btn btn-success mt-2" runat="server" >Thanh toán trực tiếp</a>
       <a runat="server" id="lnkTTOnline" onserverclick="lnkTTOnline_ServerClick" class="btn btn-info mt-2">Thanh toán Online</a>
      </div>
    </div>
    <div style="height:500px;"></div>
</asp:Content>

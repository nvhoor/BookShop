<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Default.Master" AutoEventWireup="true" CodeBehind="CTSP.aspx.cs" Inherits="BookShop.CTSP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Chi tiết sản phẩm</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid ctsp">
      <div class="row">
          <asp:Repeater runat="server" ID="rpCTSP" OnItemCommand="rpCTSP_ItemCommand" OnItemDataBound="rpCTSP_ItemDataBound">
              <ItemTemplate>
                   <div class="col-lg-6 border-right text-right">
          <img src='images/<%#:Eval("HINH") %>' class="img-ct m-3">
        </div>
        <div class="col-lg-6  text-leftt mt-3">
          <p id="tensp"><%#:Eval("TENSP") %></p>
          <table id="thongtinsp">
            <tbody>
              <tr>
                <td class="font-weight-bold">Tác giả:</td><td id="tacgia"><%#:Eval("TACGIA") %></td>
              </tr>
              <tr>
                <td>Mã sản phẩm:</td><td class="c-2"><%#:Eval("MASP") %></td>
              </tr>
              <tr>
                <td>Số trang:</td><td class="c-2"><%#:Eval("SOTRANG") %></td>
              </tr> 
              <tr>
                <td>Nhà xuất bản:</td><td class="c-2"><%#:Eval("NXB") %></td>
              </tr>
              <tr>
                <td>Thể loại:</td><td class="c-2"><%#:Eval("TENDM") %></td>
              </tr>
              <tr>
                <td class="font-weight-bold">Số lượng còn:</td><td id="sl" class="c-2"><%#:Eval("SOLUONGBAN") %></td>
              </tr>
              <tr>
                <td class="font-weight-bold">Giá bán:</td><td id="gia" class="c-2"><%#:string.Format("{0:n0}",Eval("DONGIA"))+" VND" %></td>
              </tr>
              <tr>
                <td colspan="2" id="btn-them"><asp:LinkButton CommandArgument='<%#:Eval("MASP")%>' runat="server"   class="btn btn-outline-success" Text="Thêm vào giỏ hàng" ID="lnkThem"></asp:LinkButton><asp:Button class="btn btn-danger stretched-link" Visible="false" runat="server" ID="btnHetHang" Text="Hết hàng" disabled/></td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
              </ItemTemplate>
          </asp:Repeater>
           <div class="text-justify mt-4 mb-3">
        <p class="font-weight-bold text-info" style="font-size: 1.5em;margin-bottom: 10px;">Giới thiệu sách</p>
          <p><asp:Literal runat="server" ID="litMoTa"></asp:Literal></p>
      </div>
       </div>
         </div>
</asp:Content>

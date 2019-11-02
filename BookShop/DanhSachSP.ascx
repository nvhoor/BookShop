<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachSP.ascx.cs" Inherits="BookShop.DanhSachSP" %>
 <asp:Repeater runat="server" ID="rpDSSP" OnItemCommand="rpDSSP_ItemCommand"  OnItemDataBound="rpDSSP_ItemDataBound">
                    <HeaderTemplate>
                          <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-lg-3 mt-2 mb-2">
                  <div class="card">
                    <img class="card-img-top" src='images/<%#:Eval("HINH") %>' alt="Card image">
                    <div class="card-body">
                      <p class="card-text bg-light" style="transform: rotate(0);">
                        <p> <asp:LinkButton runat="server" CommandArgument='<%#:Eval("MASP") %>' CommandName="view" class="stretched-link"><h4 class="card-title font-weight-bold"><%#:Eval("TENSP") %></h4></asp:LinkButton></p> 
                        <p class="card-title text-info"><%#:Eval("TACGIA") %></p>
                        <p class="card-text text-danger mb-1"><%#:string.Format("{0:n0}",Eval("DONGIA")) %> VND</p>
                      </p>
                      <p><asp:LinkButton runat="server" ID="lnkThem" CommandArgument='<%#:Eval("MASP")%>' CommandName="add" class="btn btn-primary stretched-link" style="position: relative;">Thêm vào giỏ</asp:LinkButton><asp:Button class="btn btn-danger stretched-link" Visible="false" runat="server" ID="btnHetHang" Text="Hết hàng" disabled/></p>
                      
                    </div>
                  </div>
                </div>
                    </ItemTemplate>
                    <FooterTemplate>
                         </div>
                    </FooterTemplate>
  </asp:Repeater>
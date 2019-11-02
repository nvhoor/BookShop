<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin.Master" AutoEventWireup="true" CodeBehind="BC-TK.aspx.cs" Inherits="BookShop.BC_TK" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Báo cáo thống kê</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="h1 text-center text-danger">Báo cáo - Thống kê</div>
          <table class="table text-right">
            <tbody>
              <tr><td class="pt-4">Chọn tháng</td><td>
                  <asp:DropDownList AutoPostBack="true" runat="server" class="form-control" ID="drThang" OnSelectedIndexChanged="drThang_SelectedIndexChanged">
                  </asp:DropDownList>
              
    
  </td><td class="pt-4">Chọn năm</td>
                  <td> 
      <asp:DropDownList AutoPostBack="true" runat="server" ID="drNam" class="form-control" OnSelectedIndexChanged="drNam_SelectedIndexChanged"></asp:DropDownList></td></tr>
      
    <tr><td colspan="2" class="font-weight-bold" >Tổng sản phẩm:</td><td colspan="2" class="h3 text-danger text-left"><asp:Label runat="server" ID="lblTongSP"></asp:Label></td></tr>
    <tr><td colspan="2" class="font-weight-bold">Tổng doanh thu:</td><td colspan="2" class="h3 text-danger text-left"><asp:Label runat="server" ID="lblTongDoanhThu"></asp:Label></td></tr>
            </tbody>
          </table>
    <div class="container-fluid text-center">
        <asp:Chart ID="chartDoanhThu" runat="server" Width="600px" Height="500px">
            <Series>
                <asp:Series Name="Số lượng mua của sản phẩm" ChartType="Column" ></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" ></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:Chart ID="ucChart" runat="server" Width="500px" Height="500px">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" ></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
          <p class="text-info h3">Danh sách sản phẩm bán được</p>
    <div class="table-responsive-lg row overflow-auto tb-sp-sm">
        <asp:Repeater runat="server" ID="rpDSSP">
            <HeaderTemplate>
                 <table class="table table-bordered table-striped table-hover">
            <thead class="thead-dark sticky-top">
              <tr>
                <th scope="col">Mã sản phẩm</th>
                <th scope="col">Tên sản phẩm</th>
                <th scope="col">Tên danh mục</th>
                <th scope="col">Số lượng</th>
                <th scope="col">Đơn giá</th>
                <th scope="col">Tổng tiền</th>
              </tr>
            </thead>
            <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                
              <tr>
                <td><%#:Eval("MASP") %></td>
                <td><%#:Eval("TENSP") %></td>
                <td><%#:Eval("TENDM") %></td>
                <td><%#:Eval("TONGSL") %></td>
                <td><%#:string.Format("{0:n0}",Eval("DONGIA")) %> VND</td>
                <td><%#:string.Format("{0:n0}",Eval("TONGTIEN")) %> VND</td>
              </tr>
            </ItemTemplate>
            <FooterTemplate>
                 </tbody>
          </table>
            </FooterTemplate>
        </asp:Repeater>
         
    
           
        </div>
          <div style="height:500px;"></div>
</asp:Content>

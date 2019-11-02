<%@ Page Title="" Language="C#" MasterPageFile="~/Master_User.Master"  AutoEventWireup="true" CodeBehind="SanPhamTheoTuKhoa.aspx.cs" Inherits="BookShop.SamPhamTheoTuKhoa" %>

<%@ Register Src="~/DanhSachSP.ascx" TagPrefix="uc1" TagName="DanhSachSP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
       <div class="container-fluid">
                 <div class="h4 mt-3 text-danger border-bottom "><asp:Label runat="server" ID="lblTuKhoa"></asp:Label></div>
           <uc1:DanhSachSP runat="server" id="DanhSachSP" />
          </div>
            <%--    </ContentTemplate>
            </asp:UpdatePanel>--%>
</asp:Content>

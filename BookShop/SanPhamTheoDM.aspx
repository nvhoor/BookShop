<%@ Page Title="" Language="C#" MasterPageFile="~/Master_User.Master" AutoEventWireup="true" CodeBehind="SanPhamTheoDM.aspx.cs" Inherits="BookShop.SanPhamTheoDM" %>

<%@ Register Src="~/DanhSachSP.ascx" TagPrefix="uc1" TagName="DanhSachSP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--  
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
            <div class="container-fluid">
                 <div class="h4 mt-3 text-danger border-bottom "><asp:Label runat="server" ID="lblTenDM"></asp:Label></div>
                <uc1:DanhSachSP runat="server" id="DanhSachSP" />
          </div>
              <%--  </ContentTemplate>
         </asp:UpdatePanel>--%>
       
</asp:Content>

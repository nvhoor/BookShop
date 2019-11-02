<%@ Page Title="" Language="C#" MasterPageFile="~/Master_User.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookShop.Default" %>

<%@ Register Src="~/DanhSachSP.ascx" TagPrefix="uc1" TagName="DanhSachSP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
            <div class="container-fluid">
              <div class="h4 mt-3 text-danger border-bottom ">Mới nhất</div>
                <uc1:DanhSachSP runat="server" id="DanhSachSP1" />
          </div>
          <div class="container-fluid">
            <div class="h4 mt-3 text-danger border-bottom ">Mua nhiều nhất</div>
              <uc1:DanhSachSP runat="server" id="DanhSachSP" />
          </div>
       
</asp:Content>

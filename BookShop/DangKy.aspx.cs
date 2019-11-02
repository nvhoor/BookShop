using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class DangKy : System.Web.UI.Page
    {
        App_Code.XuLyKhachHang xlkh = new App_Code.XuLyKhachHang();
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }

        protected void btnCreate_ServerClick(object sender, EventArgs e)
        {
            if (xlkh.TimTaiKhoan(txtUsername.Text.Trim()).Rows.Count > 0)
            {
            
            }
            else
            {
            xlkh.ThemKhachHang(txtUsername.Text.Trim(),txtHoTen.Text.Trim(),txtDiaChi.Text.Trim(),txtEmail.Text.Trim(),DateTime.Parse(datepicker.Text.Trim()),txtSDT.Text.Trim(), App_Code.TienIch.MaHoaMD5(txtPass.Text.Trim()), DateTime.Now,true);
                txtDiaChi.Text = txtEmail.Text = txtHoTen.Text = txtPass.Text = txtSDT.Text = txtUsername.Text = txtXNPass.Text = datepicker.Text = "";
            }
           
        }

        protected void btnDangNhap_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("DangNhap.aspx");
        }

        protected void valiCustom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (xlkh.TimTaiKhoan(txtUsername.Text.Trim()).Rows.Count > 0)
            {
                valiCustom.ErrorMessage = "Tài khoản đã tồn tại";
                args.IsValid = false;
            }
            else
            {
                valiCustom.ErrorMessage = "Đăng ký thành công";
                args.IsValid = false;
            }
        }
    }
}
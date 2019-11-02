using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class QLKH : System.Web.UI.Page
    {
        XuLyKhachHang xlkh = new XuLyKhachHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpKhachHang.DataSource = xlkh.LayDSKhachHang();
                rpKhachHang.DataBind();
            }
        }

        protected void btnTimKiem_ServerClick(object sender, EventArgs e)
        {
            NapDuLieuChoControls(txtTimKiem.Text.Trim());
        }

        protected void btnCapNhat_ServerClick(object sender, EventArgs e)
        {
            try
            {
                bool active = drTrangThai.SelectedIndex == 0 ? true : false;
                xlkh.CapNhatKhachHang(txtTaiKhoan.Text.Trim(), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtEmail.Text.Trim(),
                       DateTime.Parse(txtNgaySinh.Text.Trim()), txtSoDienThoai.Text.Trim(), TienIch.MaHoaMD5(txtMatKhau.Text.Trim()), active);

                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
        }

        protected void btnThem_ServerClick(object sender, EventArgs e)
        {
            try
            {
                bool active = drTrangThai.SelectedIndex == 0 ? true : false;
                xlkh.ThemKhachHang(txtTaiKhoan.Text.Trim(), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtEmail.Text.Trim(),
                    DateTime.Parse(txtNgaySinh.Text.Trim()), txtSoDienThoai.Text.Trim(), TienIch.MaHoaMD5(txtMatKhau.Text.Trim()), DateTime.Now, active);
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
        }
        private void NapDuLieuChoControls(string MAKH)
        {
            System.Data.DataTable dt = xlkh.TimKHTheoMAKH(MAKH);
            if (dt.Rows.Count > 0)
            {
                txtDiaChi.Text = dt.Rows[0]["DIACHI"].ToString();
                txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                txtHoTen.Text= dt.Rows[0]["HOTEN"].ToString();
                txtMatKhau.Text = "xxxx";
                txtNgaySinh.Text = ((DateTime)dt.Rows[0]["NGAYSINH"]).ToString("dd/MM/yyyy");
                txtSoDienThoai.Text= dt.Rows[0]["DIENTHOAI"].ToString();
                txtTaiKhoan.Text= dt.Rows[0]["USERNAME"].ToString();
                drTrangThai.SelectedIndex = ((bool)dt.Rows[0]["TRANGTHAI"]) == true ? 0 : 1;
            }
            else
            {
                txtDiaChi.Text = 
                txtEmail.Text = 
                txtHoTen.Text = 
                txtMatKhau.Text = 
                txtNgaySinh.Text = 
                txtSoDienThoai.Text = 
                txtTaiKhoan.Text ="";
            }
        }

        protected void rpKhachHang_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            NapDuLieuChoControls(e.CommandArgument.ToString());
        }
    }
}
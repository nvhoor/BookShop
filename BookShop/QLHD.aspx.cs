using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class QLHD : System.Web.UI.Page
    {
        XuLyHoaDon xlhd = new XuLyHoaDon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpDSHoaDon.DataSource = xlhd.LayDSHoaDon();
                rpDSHoaDon.DataBind();
            }
        }

        protected void btnTimKiem_ServerClick(object sender, EventArgs e)
        {
            NapDuLieuChoControls(txtTimKiem.Text.Trim());
        }

        protected void btnThemVaoHD_ServerClick(object sender, EventArgs e)
        {
            try
            {
                xlhd.ThemSPVaoHoaDon(txtMaHD.Text.Trim(), txtMaSP.Text.Trim(), int.Parse(txtSoLuong.Text.Trim()));
                NapDuLieuChoControls(txtMaHD.Text.Trim());
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
                string MAHD = "HD" + DateTime.UtcNow.ToString("yyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                bool active = drTrangThai.SelectedIndex == 0 ? true : false;
                xlhd.ThemHD(MAHD, txtTaiKhoan.Text.Trim(), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtEmail.Text.Trim(), txtSDT.Text.Trim(), txtFax.Text.Trim(), txtCongTy.Text.Trim(), txtTinhTrang.Text.Trim(), DateTime.Now, active);
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
        }

        protected void btnCapNhat_ServerClick(object sender, EventArgs e)
        {try
            {
                bool active = drTrangThai.SelectedIndex == 0 ? true : false;
                xlhd.CapNhatHD(txtMaHD.Text.Trim(), txtTaiKhoan.Text.Trim(), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtEmail.Text.Trim(), txtSDT.Text.Trim(), txtFax.Text.Trim(), txtCongTy.Text.Trim(), txtTinhTrang.Text.Trim(), active);
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
        }
        private void NapDuLieuChoControls(string MAHD)
        {
       
            System.Data.DataTable dt = xlhd.TimHoaDonTheoMaHD(MAHD);
            if (dt.Rows.Count > 0)
            {
                txtTinhTrang.Text = dt.Rows[0]["TINHTRANG"].ToString();
                txtTaiKhoan.Text= dt.Rows[0]["USERNAME"].ToString();
                txtSDT.Text= dt.Rows[0]["DIENTHOAI"].ToString();
                txtMaHD.Text = dt.Rows[0]["MAHD"].ToString();
                txtHoTen.Text = dt.Rows[0]["HOTEN"].ToString();
                txtFax.Text = dt.Rows[0]["FAX"].ToString();
                txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DIACHI"].ToString();
                txtCongTy.Text = dt.Rows[0]["CTY"].ToString();
                lblTongTien.Text = dt.Rows[0]["TONGTIEN"].ToString();
                drTrangThai.SelectedIndex = ((bool)dt.Rows[0]["TRANGTHAI"]) == true ? 0 : 1;
                rpDSSanPham.DataSource = new XuLySanPham().LayDSSPTheoMAHD(MAHD);
                rpDSSanPham.DataBind();
            }
            else
            {
                txtTinhTrang.Text =
                txtTaiKhoan.Text = 
                txtSDT.Text =
                txtMaHD.Text = 
                txtHoTen.Text = 
                txtFax.Text = 
                txtEmail.Text =
                txtDiaChi.Text = 
                txtCongTy.Text = "";
                rpDSSanPham.DataSource = null;
                rpDSSanPham.DataBind();
            }
        }

        protected void rpDSHoaDon_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            NapDuLieuChoControls(e.CommandArgument.ToString());
        }

        protected void rpDSSanPham_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split('|');

            xlhd.XoaSPTrongHoaDon(args[0],args[1]);
            NapDuLieuChoControls(args[0]);
        }

        protected void lnkXoa_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onClick"] = "return confirm('Bạn thật sự muốn xóa sản phẩm này khỏi hóa đơn?')";
        }
    }
}
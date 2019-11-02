using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class QLLH : System.Web.UI.Page
    {
        XuLyLienHe xllh = new XuLyLienHe();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpLienHe.DataSource = xllh.LayDSLienHe();
                rpLienHe.DataBind();
            }
        }

        protected void rpLienHe_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            DataTable dt = xllh.TimLienHeTheoMALH(id);
            txtDiaChi.Text = dt.Rows[0]["DIACHI"].ToString();
            txtEmail.Text= dt.Rows[0]["EMAIL"].ToString();
            txtFax.Text= dt.Rows[0]["FAX"].ToString();
            txtHoTen.Text= dt.Rows[0]["HOTEN"].ToString();
            txtSoDienThoai.Text= dt.Rows[0]["DIENTHOAI"].ToString();
            text.Text= dt.Rows[0]["NOIDUNG"].ToString();
            txtNgayTao.Text = string.Format("{0:d}", dt.Rows[0]["NGAYTAO"]);
            drTrangThai.SelectedIndex = ((bool)dt.Rows[0]["TRANGTHAI"]) == true ? 0 : 1;
        }
    }
}
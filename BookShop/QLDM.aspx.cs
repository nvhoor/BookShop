using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BookShop
{
   
    public partial class QLDM : System.Web.UI.Page
    {
        XuLyDanhMuc xldm = new XuLyDanhMuc();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpDanhMuc.DataSource = xldm.LayDSDanhMuc();
                rpDanhMuc.DataBind();
            }
        }

        protected void btnThem_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string MADM = "DM" + DateTime.UtcNow.ToString("yyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                bool active = drTrangThai.SelectedIndex == 0 ? true : false;
                xldm.ThemDM(MADM, txtTenDM.Text.Trim(), txtGhiChu.Text.Trim(), active);
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
           
           
                NapDuLieuChoControls(txtTimKiem.Text.Trim());
         
        }

        protected void rpDanhMuc_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            System.Data.DataTable dt = xldm.TimDanhMucTheoMaDM(e.CommandArgument.ToString());

            NapDuLieuChoControls(e.CommandArgument.ToString());
        }


        protected void btnCapNhat_ServerClick(object sender, EventArgs e)
        {
            try
            {
                bool active = drTrangThai.SelectedIndex == 0 ? true : false;
                xldm.CapNhatDM(txtMaDM.Text.Trim(), txtTenDM.Text.Trim(), txtGhiChu.Text.Trim(), active);
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
           
        }

        protected void btnThemVaoDM_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaDM.Text != null && txtMaDM.Text.Trim() != "")
                {
                    if (xldm.TimDanhMucTheoMaDM(txtMaDM.Text.Trim()).Rows.Count > 0)
                    {
                        XuLySanPham xlsp = new XuLySanPham();
                        if (xlsp.TimSanPhamTheoMaSP(txtMaSP.Text.Trim()).Rows.Count > 0)
                        {
                            xlsp.CapNhatDanhMucCuaSP(txtMaSP.Text.Trim(), txtMaDM.Text.Trim());

                            NapDuLieuChoControls(txtMaDM.Text.Trim());
                        }
                    }
                }
            }catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
           
        }
        private void NapDuLieuChoControls(string MADM)
        {
            System.Data.DataTable dt = xldm.TimDanhMucTheoMaDM(MADM);
            if (dt.Rows.Count > 0)
    {
        txtTenDM.Text = dt.Rows[0]["TENDM"].ToString();
        txtMaDM.Text = dt.Rows[0]["MADM"].ToString();
        txtGhiChu.Text = dt.Rows[0]["GHICHU"].ToString();
        drTrangThai.SelectedIndex = ((bool)dt.Rows[0]["TRANGTHAI"]) == true ? 0 : 1;
        rpSPTheoDM.DataSource = new XuLySanPham().LayDSSPTheoDM(MADM);
        rpSPTheoDM.DataBind();
            }
            else
            {
                txtTenDM.Text =
                txtMaDM.Text =
                txtGhiChu.Text = "";
                rpSPTheoDM.DataSource = null;
                rpSPTheoDM.DataBind();
            }
        }
          
}
    }

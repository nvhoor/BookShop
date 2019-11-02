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
    public partial class SamPhamTheoTuKhoa : System.Web.UI.Page
    {
        XuLySanPham xlsp = new XuLySanPham();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["tukhoa"].ToString()))
                {
                    DataTable dt = null;
                    dt = xlsp.LayDSSPKichHoatTheoTuKhoa(Session["tukhoa"].ToString());
                    if (dt.Rows.Count > 0)
                        ((Repeater)DanhSachSP.FindControl("rpDSSP")).DataSource = dt;
                    ((Repeater)DanhSachSP.FindControl("rpDSSP")).DataBind();
                    lblTuKhoa.Text = "\"" + Session["tukhoa"].ToString() + "\"";
                }
               
            }
        }
    }
}
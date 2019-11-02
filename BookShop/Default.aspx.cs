using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class Default : System.Web.UI.Page
    {
        XuLySanPham xlsp = new XuLySanPham();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ((Repeater)DanhSachSP1.FindControl("rpDSSP")).DataSource = xlsp.LayDSSPMoiNhat();
                ((Repeater)DanhSachSP1.FindControl("rpDSSP")).DataBind();
                ((Repeater)DanhSachSP.FindControl("rpDSSP")).DataSource = xlsp.LayDSSPMuaNhieuNhat();
                ((Repeater)DanhSachSP.FindControl("rpDSSP")).DataBind();
            }
        }
    }
}
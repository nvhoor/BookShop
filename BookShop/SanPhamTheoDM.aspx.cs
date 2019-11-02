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
    public partial class SanPhamTheoDM : System.Web.UI.Page
    {
        XuLySanPham xlsp = new XuLySanPham();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    DataTable dt = xlsp.LayDSSPKichHoatTheoDM(Session["madm"].ToString());
               
                    
                    lblTenDM.Text = Session["tendm"].ToString();
               
                ((Repeater)DanhSachSP.FindControl("rpDSSP")).DataSource = dt;
                ((Repeater)DanhSachSP.FindControl("rpDSSP")).DataBind();
               

            }
        }
    }
}
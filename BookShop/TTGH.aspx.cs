using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class TTGH : System.Web.UI.Page
    {
        XuLyHoaDon xlhd = new XuLyHoaDon();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["login-user"] == null) Response.Redirect("DangNhap.aspx");
                (Master.FindControl("lnkHome") as HyperLink).NavigateUrl = "Default.aspx";
                
     

        }

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
           
                try
                {
                    string  MAHD = "HD" + DateTime.UtcNow.ToString("yyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                    xlhd.ThemHD(MAHD, Session["login-user"].ToString(), txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtEmail.Text.Trim(), txtSDT.Text.Trim(), txtFax.Text.Trim(), txtCTy.Text.Trim(), "Đặt hàng", DateTime.Now, true);
                    DataTable dt = Session["giohang"] as DataTable;
                     foreach (DataRow item in dt.Rows)
                    {
                        xlhd.ThemSPVaoHoaDon(MAHD,item["MASP"].ToString(),int.Parse(item["SOLUONG"].ToString()));
                    }
                Session.Remove("giohang");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Đặt hàng thành công');", true);
                }
                catch
                {
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Đặt hàng thất bại!');", true);
                }

            



        }
    }
}
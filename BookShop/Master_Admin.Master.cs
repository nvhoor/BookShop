using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class Master_Admin : System.Web.UI.MasterPage
    {
        XuLyKhachHang xlhk = new XuLyKhachHang();
        protected void Page_Load(object sender, EventArgs e)
        {
          
                if (Session["login-admin"] != null)
                {

                    lnkTenAdmin.InnerText = xlhk.TimTaiKhoan(Session["login-admin"].ToString()).Rows[0]["HOTEN"].ToString();
                }
                else
                {
                    Response.Redirect("DangNhap.aspx");
                }
           
           
        }


        protected void dangxuat_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("login-admin");
            Response.Redirect(Request.Url.ToString());
        }

        protected void lnkTenAdmin_ServerClick(object sender, EventArgs e)
        {
            Context.Items["username-admin"] = Session["login-admin"].ToString();
            Server.Transfer("CNTTCN.aspx");
        }
    }
}
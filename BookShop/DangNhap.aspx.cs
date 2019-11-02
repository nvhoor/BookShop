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
    public partial class DangNhap : System.Web.UI.Page
    {
        XuLyKhachHang xlkh = new XuLyKhachHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userid"] != null)

                    txtUsername.Text = Request.Cookies["userid"].Value;

                if (Request.Cookies["pwd"] != null)

                   txtPass.Text= Request.Cookies["pwd"].Value;
                if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
                    chkRemember.Checked = true;
            }
        }

        protected void valiCustom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DataTable dt = xlkh.KiemTraDangNhap(txtUsername.Text.Trim(), TienIch.MaHoaMD5(txtPass.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
                
                args.IsValid = true;

            }
            else
            {
                args.IsValid = false;
            }
        }

     

        protected void btnDN_ServerClick(object sender, EventArgs e)
        {
            DataTable dt = xlkh.KiemTraDangNhap(txtUsername.Text.Trim(), TienIch.MaHoaMD5(txtPass.Text.Trim()));
            if (dt.Rows.Count > 0)
            {
               
                if (chkRemember.Checked == true)
                {
                    Response.Cookies["userid"].Value = txtUsername.Text;
                    Response.Cookies["pwd"].Value = txtPass.Text;
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                }

                else

                {

                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);

                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);

                }
                if (xlkh.IsAdmin(txtUsername.Text.Trim()))
                {
                    Session["login-admin"] = txtUsername.Text.Trim();
                    Response.Redirect("BC-TK.aspx");
                }else
                {
                    Session["login-user"] = txtUsername.Text.Trim();
                    Response.Redirect("Default.aspx");
                }
               
            }
        }
    }
}
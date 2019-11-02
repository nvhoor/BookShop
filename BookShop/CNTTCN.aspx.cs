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
    public partial class CNTTCN : System.Web.UI.Page
    {
        XuLyKhachHang xlkh = new XuLyKhachHang();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Context.Items["username-user"] != null)
                {
                    (Master.FindControl("lnkHome") as HyperLink).NavigateUrl = "Default.aspx";
                    hduser.Value = Context.Items["username-user"].ToString();
                    LoadDuLieu(hduser.Value);
                }
                
                else
                if (Context.Items["username-admin"] != null)
                {
                    (Master.FindControl("lnkHome") as HyperLink).NavigateUrl = "BC-TK.aspx";
                    hdadmin.Value = Context.Items["username-admin"].ToString();
                    LoadDuLieu(hdadmin.Value);
                }
                    
                else
                {
                    Response.Redirect("DangNhap.aspx");
                }
            }
            if(Session["login-admin"]==null&&Session["login-user"]==null) Response.Redirect("DangNhap.aspx");
        }

        protected void btnXacNhan_ServerClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hduser.Value))
            {
                if (Session["login-user"] != null)
                {
                    try
                    {
                        xlkh.CapNhatKhachHang(hduser.Value, txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtEmail.Text.Trim(), DateTime.Parse(txtNgaySinh.Text.Trim()), txtSDT.Text.Trim(), TienIch.MaHoaMD5(txtPass.Text.Trim()), true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cập nhật tài khoản thành công!');", true);
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cập nhật tài khoản thất bại!');", true);
                    }
                  
                }
                else
                {
                    Response.Redirect("DangNhap.aspx");
                }
            } else
                if (!string.IsNullOrEmpty(hdadmin.Value))
            {
                if (Session["login-admin"] != null)
                {
                    try
                    { 
                    xlkh.CapNhatAdmin(hdadmin.Value, txtHoTen.Text.Trim(), txtDiaChi.Text.Trim(), txtEmail.Text.Trim(), DateTime.Parse(txtNgaySinh.Text.Trim()), txtSDT.Text.Trim(), TienIch.MaHoaMD5(txtPass.Text.Trim()), true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cập nhật tài khoản thành công!');", true);
                     }
                    catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cập nhật tài khoản thất bại!');", true);
                }
            }
                else
                {
                    Response.Redirect("DangNhap.aspx");
                }
            }
        }
        private void LoadDuLieu(string username)
        {
            DataTable dt = null;
           dt = xlkh.TimTaiKhoan(username);
            txtDiaChi.Text = dt.Rows[0]["DIACHI"].ToString();
            txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
            txtHoTen.Text=dt.Rows[0]["HOTEN"].ToString();
            txtNgaySinh.Text = DateTime.Parse(dt.Rows[0]["NGAYSINH"].ToString()).ToString("dd/MM/yyyy");
            txtPass.Text = "*******";
            txtSDT.Text= dt.Rows[0]["DIENTHOAI"].ToString();
        }
    }
}
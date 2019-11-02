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
    public partial class Master_User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rpDanhMucSP.DataSource = new XuLyDanhMuc().LayDSDanhMucKichHoat();
                rpDanhMucSP.DataBind();
               
              
            }
            if (Session["login-user"] != null)
            {
                dangky.Visible = dangnhap.Visible = false;
                dangxuat.Visible = lnkTenAdmin.Visible = true;

                lnkTenAdmin.InnerText = new XuLyKhachHang().TimTaiKhoan(Session["login-user"].ToString()).Rows[0]["HOTEN"].ToString();
            }
            else
            {
                dangxuat.Visible = lnkTenAdmin.Visible = false;
            }
            if (Session["giohang"] != null)
            {
                DataTable dt = Session["giohang"] as DataTable;
                
                int tongsp = 0;
                foreach (DataRow item in dt.Rows)
                {
                    tongsp += int.Parse(item["SOLUONG"].ToString());
                }
                lblSoSP.Text = dt.Rows.Count.ToString()+"|"+tongsp;
            }
            else lblSoSP.Text = "0";
        }

        protected void rpDanhMucSP_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Session["madm"] = e.CommandArgument.ToString();
            Session["tendm"] = e.CommandName;
            Response.Redirect("SanPhamTheoDM.aspx");
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            Session["tukhoa"] = txtTuKhoa.Text.Trim();
            Response.Redirect("SanPhamTheoTuKhoa.aspx");
        }

        protected void dangxuat_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("login-user");
            Response.Redirect(Request.Url.ToString());
        }

        protected void lnkTenAdmin_ServerClick(object sender, EventArgs e)
        {
            Context.Items["username-user"] = Session["login-user"].ToString();
            Server.Transfer("CNTTCN.aspx");
        }
    }
}
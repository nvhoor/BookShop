using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
               ( Master.FindControl("lnkHome") as HyperLink).NavigateUrl="Default.aspx";

                LoadDuLieu();
                   
            }else
            {
              
                    DataTable gh = Session["giohang"] as DataTable;
                if (gh.Rows.Count > 0)
                {
                    foreach (RepeaterItem item in rpGioHang.Items)
                    {
                        TextBox box = (TextBox)item.FindControl("txtSL");
                        if (!string.IsNullOrEmpty(box.Text.Trim()))
                        {
                            gh.Rows[item.ItemIndex]["SOLUONG"] = int.Parse(box.Text.Trim());
                            gh.Rows[item.ItemIndex]["THANHTIEN"] = decimal.Parse(gh.Rows[item.ItemIndex]["DONGIA"].ToString()) * int.Parse(box.Text.Trim());
                        }

                    }
                   
                }
                LoadDuLieu();
            }
            
          
        }

        private void LoadDuLieu()
        {
            decimal tongTien = 0;
            DataTable dt = Session["giohang"] as DataTable;
            rpGioHang.DataSource = dt;
            rpGioHang.DataBind();

            if (Session["giohang"]!=null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    tongTien += decimal.Parse(item["THANHTIEN"].ToString());
                }
                lblTongTien.Text = string.Format("{0:n0}", tongTien) + " VND";

            }
            else lblTongTien.Text = "0 VND";
        }

        protected void btnXoaGH_Click(object sender, EventArgs e)
        {
            if (Session["giohang"] != null)
            {
                ((DataTable)Session["giohang"]).Rows.Clear();
            }
            Response.Redirect(Request.Url.ToString());
           
        }

        protected void lnkTTTrucTiep_ServerClick(object sender, EventArgs e)
        {
            if (Session["login-user"] != null)
            {
                if (Session["giohang"] != null)
                {
                    DataTable dt = Session["giohang"] as DataTable;
                    if(dt.Rows.Count>0) Response.Redirect("TTGH.aspx");
                   
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Không có sản phẩm trong giỏ hàng!');", true);

            }
            else
            {
                Response.Redirect("DangNhap.aspx");
            }
        }

        protected void lnkTTOnline_ServerClick(object sender, EventArgs e)
        {
            if (Session["login-user"] != null)
            {
                if (Session["giohang"] != null)
                {
                    DataTable dt = Session["giohang"] as DataTable;
                    if (dt.Rows.Count > 0) Response.Redirect("TTGH.aspx");

                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Không có sản phẩm trong giỏ hàng!');", true);
                
            }
            else
            {
                
                Response.Redirect("DangNhap.aspx");
            }
        }

        protected void rpGioHang_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable gh = Session["giohang"] as DataTable;
            gh.Rows.RemoveAt(e.Item.ItemIndex);
            Response.Redirect(Request.Url.ToString());
        }

 

        protected void lnkXoa_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onClick"] = "return confirm('Bạn có thật sự muốn xóa sản phẩm này khỏi giỏ hàng?')";
        }
    }
}
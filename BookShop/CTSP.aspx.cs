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
    public partial class CTSP : System.Web.UI.Page
    {
        XuLySanPham xlsp = new XuLySanPham();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                (Master.FindControl("lnkHome") as HyperLink).NavigateUrl = "Default.aspx";
                DataTable dt = xlsp.TimSanPhamKichHoatTheoMaSP(Request["id"].ToString());
                rpCTSP.DataSource = dt;
                rpCTSP.DataBind();
                litMoTa.Text = dt.Rows[0]["MOTA"].ToString();
            }
        }

        protected void rpCTSP_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            DataTable sampham = new XuLySanPham().TimSanPhamKichHoatTheoMaSP(id);
            if (Session["giohang"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MASP", typeof(string));
                dt.Columns.Add("TENSP", typeof(string));
                dt.Columns.Add("DONGIA", typeof(decimal));
                dt.Columns.Add("SOLUONG", typeof(int));
                dt.Columns.Add("THANHTIEN", typeof(decimal));
                dt.Columns.Add("SLTON", typeof(int));
              
                DataRow tr = dt.NewRow();
                tr["MASP"] = sampham.Rows[0]["MASP"].ToString();
                tr["TENSP"] = sampham.Rows[0]["TENSP"].ToString();
                tr["DONGIA"] = decimal.Parse(sampham.Rows[0]["DONGIA"].ToString());
                tr["SOLUONG"] = 1;
                tr["THANHTIEN"] = decimal.Parse(sampham.Rows[0]["DONGIA"].ToString());
               
                tr["SLTON"] = int.Parse(sampham.Rows[0]["SOLUONGBAN"].ToString());
                dt.Rows.Add(tr);
                Session["giohang"] = dt;

            }
            else
            {
                DataTable dt = Session["giohang"] as DataTable;
                foreach (DataRow item in dt.Rows)
                {
                    if (item["MASP"].ToString().Equals(sampham.Rows[0]["MASP"].ToString()))
                    {
                        item["SOLUONG"] = int.Parse(item["SOLUONG"].ToString()) + 1;
                        item["THANHTIEN"] = int.Parse(item["SOLUONG"].ToString()) * decimal.Parse(item["DONGIA"].ToString());
                        Response.Redirect(Request.Url.ToString());
                        return;
                    }
                }
                DataRow tr = dt.NewRow();
                tr["MASP"] = sampham.Rows[0]["MASP"].ToString();
                tr["TENSP"] = sampham.Rows[0]["TENSP"].ToString();
                tr["DONGIA"] = decimal.Parse(sampham.Rows[0]["DONGIA"].ToString());
                tr["SOLUONG"] = 1;
                tr["THANHTIEN"] = decimal.Parse(sampham.Rows[0]["DONGIA"].ToString());
             
                tr["SLTON"] = int.Parse(sampham.Rows[0]["SOLUONGBAN"].ToString());
                dt.Rows.Add(tr);

            }

            Response.Redirect(Request.Url.ToString());
        }

        protected void rpCTSP_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView row = e.Item.DataItem as DataRowView;
                string type = row.Row["SOLUONGBAN"].ToString();
                LinkButton btn1 = e.Item.FindControl("lnkThem") as LinkButton;
                Button btn2 = e.Item.FindControl("btnHetHang") as Button;
                if (type.Equals("0"))
                {
                    btn2.Visible = true;
                    btn1.Visible = false;
                }
                else
                {
                    btn2.Visible = false;
                    btn1.Visible = true;
                }
            }
        }
    }
}
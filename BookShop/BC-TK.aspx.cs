using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class BC_TK : System.Web.UI.Page
    {
        XuLyHoaDon xlhd = new XuLyHoaDon();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                for (int i = 0; i < 5; i++)
                    drNam.Items.Add((DateTime.Now.Year - i).ToString());
                if (drNam.SelectedValue == DateTime.Now.Year.ToString())
                {
                    for (int i = DateTime.Now.Month; i > 0; i--)
                    {
                        drThang.Items.Add(i.ToString());
                    }

                }
                else
                {
                    for (int i = 12; i > 0; i--)
                    {
                        drThang.Items.Add(i.ToString());
                    }
                }



                LoadDuLieu();

            }
        }

        protected void drThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        protected void drNam_SelectedIndexChanged(object sender, EventArgs e)
        {

            drThang.Items.Clear();
            if (drNam.SelectedValue == DateTime.Now.Year.ToString())
            {
                for (int i = DateTime.Now.Month; i > 0; i--)
                {
                    drThang.Items.Add(i.ToString());
                }

            }
            else
            {
                for (int i = 12; i > 0; i--)
                {
                    drThang.Items.Add(i.ToString());
                }
            }

            LoadDuLieu();
        }
        private void LoadDuLieu()
        {
            DataTable dt = xlhd.TongSPBanDuocTrongThang(drThang.SelectedValue, drNam.SelectedValue);
            if (dt.Rows.Count > 0)
                lblTongSP.Text = dt.Rows[0]["TONGSL"].ToString() + " SP";
            else lblTongSP.Text = "";
            DataTable tongdt = xlhd.TongDoanhThu(drThang.SelectedValue, drNam.SelectedValue);
            if (dt.Rows.Count > 0) lblTongDoanhThu.Text = string.Format("{0:n0}", tongdt.Rows[0]["TONGDT"]) + " VND";
            else lblTongDoanhThu.Text = "";
            DataTable dssp = xlhd.LayDSSPBanDuoc(drThang.SelectedValue, drNam.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                rpDSSP.DataSource = dssp;
                rpDSSP.DataBind();
            }

            else
            {
                rpDSSP.DataSource = null;
                rpDSSP.DataBind();
            }
            CreateChart();
            CreateChartB();
        }
        private void CreateChart()
        {
            DataTable objBind = xlhd.LayDSSanPhamCoSLMuaCaoNhat(drThang.SelectedValue, drNam.SelectedValue);


            if (objBind != null)
            {
                if (objBind.Rows.Count > 0)
                {
                    string[] x = new string[objBind.Rows.Count];
                    decimal[] y = new decimal[objBind.Rows.Count];

                    for (int i = 0; i <= objBind.Rows.Count - 1; i++)
                    {
                        x[i] = objBind.Rows[i]["TENSP"].ToString();
                        y[i] = Convert.ToDecimal(objBind.Rows[i]["TONGTIEN"]);
                    }
                    chartDoanhThu.Titles.Add(new Title("Top 5 sản phẩm có số lượng mua nhiều nhất trong tháng"));
                    ConfigurTitle(chartDoanhThu.Titles[0]);
                    chartDoanhThu.Series[0].Points.DataBindXY(x, y);
                    chartDoanhThu.Series[0].BorderWidth = 1;
                    chartDoanhThu.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);


                    // Add a legend to the chart and dock it to the bottom-center
                    chartDoanhThu.Legends.Add("Legend1");
                    chartDoanhThu.Legends[0].Enabled = true;
                    chartDoanhThu.Legends[0].Docking = Docking.Bottom;
                    chartDoanhThu.Legends[0].Alignment = System.Drawing.StringAlignment.Center;


                }
            }
        }
        private void ConfigurTitle(Title title)
        {
            title.BorderColor = Color.Silver;
            title.BorderDashStyle = ChartDashStyle.Solid;
            title.ShadowColor = Color.Gray;
            title.ShadowOffset = 6;
            title.Font = new Font("Sans Serif", 10, FontStyle.Bold);
        }
        private void CreateChartB()
        {
            DataTable objBind = xlhd.LayDSTongSanPhamTheoTungDanhMuc(drThang.SelectedValue, drNam.SelectedValue);


            if (objBind != null)
            {
                if (objBind.Rows.Count > 0)
                {
                    string[] x = new string[objBind.Rows.Count];
                    int[] y = new int[objBind.Rows.Count];
                    for (int i = 0; i <= objBind.Rows.Count - 1; i++)
                    {
                        x[i] = objBind.Rows[i]["TENDM"].ToString();
                        y[i] = Convert.ToInt32(objBind.Rows[i]["TONGSL"]);
                    }
                    ucChart.Titles.Add(new Title("Số lượng sản phẩm bán được của mỗi danh mục trong tháng"));
                    ConfigurTitle(chartDoanhThu.Titles[0]);
                    ucChart.Series[0].Points.DataBindXY(x, y);
                    ucChart.Series[0].BorderWidth = 1;
                    ucChart.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
                    ucChart.Series[0]["PieLabelStyle"] = "Outside";

                    // Add a legend to the chart and dock it to the bottom-center
                    ucChart.Legends.Add("Legend1");
                    ucChart.Legends[0].Enabled = true;
                    ucChart.Legends[0].Docking = Docking.Bottom;
                    ucChart.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

                    // Set the legend to display pie chart values as percentages
                    ucChart.Series[0].LegendText = "#PERCENT{P2}";
                }
            }
        }
    }

}
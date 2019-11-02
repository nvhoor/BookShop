using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class QLSP : System.Web.UI.Page
    {
        XuLySanPham xlsp = new XuLySanPham();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drDanhMuc.DataSource = new XuLyDanhMuc().LayDSDanhMucKichHoat();
                drDanhMuc.DataValueField = "MADM";
                drDanhMuc.DataTextField = "TENDM";
                drDanhMuc.DataBind();
                rpDSSanPham.DataSource = xlsp.LayDSSanPham();
                rpDSSanPham.DataBind();
            }
            string script = @"
       function readURL(input) {

                 if (input.files && input.files[0]) {
                     var reader = new FileReader();

                     reader.onload = function (e) {
                         $('.imgHinhAnh').attr('src', e.target.result);
                     }

                     reader.readAsDataURL(input.files[0]);
                 }
             }
            $('.imgInp').change(function () { readURL(this);
        });";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "upload", script, true);
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
           try
            {
                string MASP = "SP" + DateTime.UtcNow.ToString("yyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                string file = UploadFile();
                bool active = drTrangThai.SelectedIndex == 0 ? true : false;
                xlsp.ThemSanPham(MASP, drDanhMuc.SelectedValue, txtTenSP.Text.Trim(), file, Decimal.Parse(txtDonGia.Text.Trim()), txtTacGia.Text.Trim(), int.Parse(txtSoTrang.Text.Trim()), txtNXB.Text.Trim(), txtMoTa.Text.Trim(), int.Parse(txtSoLuong.Text.Trim()), DateTime.Now, active);
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
               

         


        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
           try
            {
                string file = UploadFile();
                if (!file.Equals(hdImage.Value))
                    if (File.Exists(Server.MapPath("~/images/") + hdImage.Value))
                    {

                        File.Delete(Server.MapPath("~/images/") + hdImage.Value);

                    }
                bool active = drTrangThai.SelectedIndex == 0 ? true : false;
                xlsp.CapNhatSanPham(txtMaSP.Text.Trim(), drDanhMuc.Text.Trim(), txtTenSP.Text.Trim(), file, Decimal.Parse(txtDonGia.Text.Trim()), txtTacGia.Text.Trim(), int.Parse(txtSoTrang.Text.Trim()), txtNXB.Text.Trim(), txtMoTa.Text.Trim(), int.Parse(txtSoLuong.Text.Trim()), active);
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thao tác không thành công!');", true);
            }
               



        }
        private string UploadFile()
        {
            string typefile = "";
            string file = hdImage.Value;
            if (flImage.FileName.Length > 0)
            {
                if (flImage.PostedFile.ContentLength < 5000000)
                {
                    if (flImage.PostedFile.ContentType.Equals("image/jpeg") || flImage.PostedFile.ContentType.Equals("image/pjpeg") || flImage.PostedFile.ContentType.Equals("image/x-png") || flImage.PostedFile.ContentType.Equals("image/gif") || flImage.PostedFile.ContentType.Equals("image/png"))
                    {
                        typefile = Path.GetExtension(flImage.FileName).ToLower();
                        file = Path.GetFileName(flImage.PostedFile.FileName);
                        file = flImage.FileName.Replace(file, "nvhoor" + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + typefile);
                        flImage.PostedFile.SaveAs(Server.MapPath("~/images/") + file);
                    }
                }
            }
            return file;
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = xlsp.TimSanPhamTheoMaSP(txtTimKiem.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                txtMaSP.Text = dt.Rows[0]["MASP"].ToString();
                txtTenSP.Text = dt.Rows[0]["TENSP"].ToString();
                drDanhMuc.SelectedValue = dt.Rows[0]["MADM"].ToString();
                hdImage.Value = dt.Rows[0]["HINH"].ToString();
                txtDonGia.Text = dt.Rows[0]["DONGIA"].ToString();
                txtTacGia.Text = dt.Rows[0]["TACGIA"].ToString();
                blah.ImageUrl = "~/images/" + dt.Rows[0]["HINH"].ToString();
                txtSoTrang.Text = dt.Rows[0]["SOTRANG"].ToString();
                txtNXB.Text = dt.Rows[0]["NXB"].ToString();
                txtMoTa.Text = dt.Rows[0]["MOTA"].ToString();
                txtSoLuong.Text = dt.Rows[0]["SOLUONGBAN"].ToString();
                drTrangThai.SelectedIndex = ((bool)dt.Rows[0]["TRANGTHAI"]) == true ? 0 : 1;
            }
           
        }

        protected void rpDSSanPham_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
                        System.Data.DataTable dt = xlsp.TimSanPhamTheoMaSP(e.CommandArgument.ToString());
                       
                            txtMaSP.Text = dt.Rows[0]["MASP"].ToString();
                            txtTenSP.Text = dt.Rows[0]["TENSP"].ToString();
                            drDanhMuc.SelectedValue = dt.Rows[0]["MADM"].ToString();
                            hdImage.Value = dt.Rows[0]["HINH"].ToString();
                            txtDonGia.Text = dt.Rows[0]["DONGIA"].ToString();
                            txtTacGia.Text = dt.Rows[0]["TACGIA"].ToString();
                            blah.ImageUrl = "~/images/" + dt.Rows[0]["HINH"].ToString();
                            txtSoTrang.Text = dt.Rows[0]["SOTRANG"].ToString();
                            txtNXB.Text = dt.Rows[0]["NXB"].ToString();
                            txtMoTa.Text = dt.Rows[0]["MOTA"].ToString();
                            txtSoLuong.Text = dt.Rows[0]["SOLUONGBAN"].ToString();
                            drTrangThai.SelectedIndex = ((bool)dt.Rows[0]["TRANGTHAI"]) == true ? 0 : 1;
                       
                
        }

        protected void tim_Validate(object source, ServerValidateEventArgs args)
        {
            System.Data.DataTable dt = xlsp.TimSanPhamTheoMaSP(txtTimKiem.Text.Trim());
            if (dt.Rows.Count == 0) args.IsValid = false;
        }
    }
}
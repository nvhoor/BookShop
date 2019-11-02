using BookShop.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop
{
    public partial class LienHe : System.Web.UI.Page
    {
        XuLyLienHe xllh = new XuLyLienHe();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
           ( Master.FindControl("lnkHome") as HyperLink).NavigateUrl = "Default.aspx";
        }

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
            string MALH = "LH" + DateTime.UtcNow.ToString("yyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            try
            {
                xllh.ThemLienHe(MALH, txtHoTen.Text.Trim(), txtEmail.Text.Trim(), txtSDT.Text.Trim(), txtFax.Text.Trim(), txtDiaChi.Text.Trim(), text.Text.Trim(), DateTime.Now, true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Gửi thành công!');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Gửi thất bại!');", true);
            }
           
        }

    
    }
}
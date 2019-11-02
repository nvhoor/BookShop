using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookShop.App_Code
{
    public class XuLyLienHe
    {
        public void ThemLienHe(string MALH,string HOTEN,string EMAIL,string DIENTHOAI,string FAX,string DIACHI,string NOIDUNG,DateTime NGAYTAO,bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("insert into LIENHE values(@MALH, @HOTEN,  @EMAIL,@DIENTHOAI,@FAX,@DIACHI,@NOIDUNG,@NGAYTAO, @TRANGTHAI)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MALH", MALH);
            cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@DIENTHOAI", DIENTHOAI);

            cmd.Parameters.AddWithValue("@NGAYTAO", NGAYTAO);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public DataTable LayDSLienHe()
        {
            SqlCommand cmd = new SqlCommand("select * from LIENHE order by NGAYTAO desc");
            cmd.CommandType = CommandType.Text;
          return  SQLDB.SQLDB.getData(cmd);
        }
        public DataTable TimLienHeTheoMALH(string MALH)
        {
            SqlCommand cmd = new SqlCommand("select * from LIENHE where MALH=@MALH");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MALH",MALH);
          return  SQLDB.SQLDB.getData(cmd);
        }
    }
}
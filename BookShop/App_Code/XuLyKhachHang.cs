using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookShop.App_Code
{
    public class XuLyKhachHang
    {
        public DataTable LayDSKhachHang()
        {
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where administrator = 'false' order by NGAYTAO desc");
            cmd.CommandType = CommandType.Text;
            return SQLDB.SQLDB.getData(cmd);
        }
        public void ThemKhachHang(string USERNAME, string HOTEN,string DIACHI,string EMAIL,DateTime NGAYSINH, string DIENTHOAI,string PASS,DateTime NGAYTAO,bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("insert into KHACHHANG values (@USERNAME,@HOTEN,@DIACHI,@EMAIL,@NGAYSINH,@DIENTHOAI,@PASS,'false',@NGAYTAO,@TRANGTHAI)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@USERNAME",USERNAME);
            cmd.Parameters.AddWithValue("@HOTEN",HOTEN);
            cmd.Parameters.AddWithValue("@DIACHI",DIACHI);
            cmd.Parameters.AddWithValue("@EMAIL",EMAIL);
            cmd.Parameters.AddWithValue("@NGAYSINH",NGAYSINH);
            cmd.Parameters.AddWithValue("@DIENTHOAI",DIENTHOAI);
            cmd.Parameters.AddWithValue("@PASS",PASS);
            cmd.Parameters.AddWithValue("@NGAYTAO",NGAYTAO);
            cmd.Parameters.AddWithValue("@TRANGTHAI",TRANGTHAI);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public DataTable TimKHTheoMAKH(string MAKH)
        {
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where USERNAME=@MAKH and administrator = 'false' ");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAKH", MAKH);
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable TimTaiKhoan(string MAKH)
        {
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where USERNAME=@MAKH" );
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAKH", MAKH);
           
            return SQLDB.SQLDB.getData(cmd);
        }
        public int CapNhatKhachHang(string USERNAME, string HOTEN, string DIACHI, string EMAIL, DateTime NGAYSINH, string DIENTHOAI, string PASS, bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("update KHACHHANG set HOTEN=@HOTEN,DIACHI=@DIACHI,EMAIL=@EMAIL,NGAYSINH=@NGAYSINH,DIENTHOAI=@DIENTHOAI,PASS=@PASS,TRANGTHAI=@TRANGTHAI WHERE USERNAME=@USERNAME and ADMINISTRATOR='false'");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@USERNAME", USERNAME);
            cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@NGAYSINH", NGAYSINH); 
            cmd.Parameters.AddWithValue("@DIENTHOAI", DIENTHOAI);
            cmd.Parameters.AddWithValue("@PASS", PASS);
          
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
           return SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public DataTable KiemTraDangNhap(string USERNAME, string PASS)
        {
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where USERNAME=@MAKH and PASS=@PASS and TRANGTHAI='true'");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAKH", USERNAME);
            cmd.Parameters.AddWithValue("@PASS", PASS);
            return SQLDB.SQLDB.getData(cmd);
        }
        public bool IsAdmin(string USERNAME)
        {
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where USERNAME=@MAKH and TRANGTHAI='true' and ADMINISTRATOR='true'");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAKH", USERNAME);
          return  (SQLDB.SQLDB.getData(cmd).Rows.Count>0)?true:false;
        }
        public int CapNhatAdmin(string USERNAME, string HOTEN, string DIACHI, string EMAIL, DateTime NGAYSINH, string DIENTHOAI, string PASS, bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("update KHACHHANG set HOTEN=@HOTEN,DIACHI=@DIACHI,EMAIL=@EMAIL,NGAYSINH=@NGAYSINH,DIENTHOAI=@DIENTHOAI,PASS=@PASS,TRANGTHAI=@TRANGTHAI WHERE USERNAME=@USERNAME and ADMINISTRATOR='true'");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@USERNAME", USERNAME);
            cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@NGAYSINH", NGAYSINH);
            cmd.Parameters.AddWithValue("@DIENTHOAI", DIENTHOAI);
            cmd.Parameters.AddWithValue("@PASS", PASS);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            return SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
    }
}
using SQLDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookShop.App_Code
{
    public class XuLySanPham
    {
        public DataTable LayDSSanPham()
        {
            SqlCommand cmd = new SqlCommand("select MASP,TENDM,TENSP,HINH,DONGIA,TACGIA,SOTRANG,NXB,MOTA,SOLUONGBAN,NGAYTAO,a.TRANGTHAI from SANPHAM a, DANHMUCSP b where a.MADM=b.MADM and a.MASP!='SP00' order by a.NGAYTAO desc");
            cmd.CommandType = CommandType.Text;
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable LayDSSPTheoDM(string MADM)
        {
            SqlCommand cmd = new SqlCommand("select * from SANPHAM where MADM=@MADM and MASP!='SP00'");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MADM",MADM);
            return SQLDB.SQLDB.getData(cmd);
        }
        public void ThemSanPham(string MASP,string MADM,string TENSP, string HINH, decimal DONGIA, string TACGIA, int SOTRANG, string NXB, string MOTA, int SOLUONGBAN, DateTime NGAYTAO, bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("insert into SANPHAM values (@MASP,@MADM,@TENSP,@HINH,@DONGIA,@TACGIA,@SOTRANG,@NXB,@MOTA,@SOLUONGBAN,@NGAYTAO,@TRANGTHAI)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MASP", MASP);
            cmd.Parameters.AddWithValue("@MADM",MADM);
            cmd.Parameters.AddWithValue("@TENSP",TENSP);
            cmd.Parameters.AddWithValue("@HINH",HINH);
            cmd.Parameters.AddWithValue("@DONGIA", DONGIA);
            cmd.Parameters.AddWithValue("@TACGIA",TACGIA);
            cmd.Parameters.AddWithValue("@SOTRANG",SOTRANG);
            cmd.Parameters.AddWithValue("@NXB",NXB);
            cmd.Parameters.AddWithValue("@MOTA",MOTA);
            cmd.Parameters.AddWithValue("@SOLUONGBAN",SOLUONGBAN);
            cmd.Parameters.AddWithValue("@NGAYTAO", NGAYTAO);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.CommandType = CommandType.Text;
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public void CapNhatSanPham(string MASP, string MADM, string TENSP, string HINH, decimal DONGIA, string TACGIA, int SOTRANG, string NXB, string MOTA, int SOLUONGBAN, bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("update SANPHAM set MADM=@MADM,TENSP=@TENSP,HINH=@HINH,DONGIA=@DONGIA,TACGIA=@TACGIA,SOTRANG=@SOTRANG,NXB=@NXB,MOTA=@MOTA,SOLUONGBAN=@SOLUONGBAN,TRANGTHAI=@TRANGTHAI where  MASP=@MASP");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MASP", MASP);
            cmd.Parameters.AddWithValue("@MADM", MADM);
            cmd.Parameters.AddWithValue("@TENSP", TENSP);
            cmd.Parameters.AddWithValue("@HINH", HINH);
            cmd.Parameters.AddWithValue("@DONGIA", DONGIA);
            cmd.Parameters.AddWithValue("@TACGIA", TACGIA);
            cmd.Parameters.AddWithValue("@SOTRANG", SOTRANG);
            cmd.Parameters.AddWithValue("@NXB", NXB);
            cmd.Parameters.AddWithValue("@MOTA", MOTA);
            cmd.Parameters.AddWithValue("@SOLUONGBAN", SOLUONGBAN);
        
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.CommandType = CommandType.Text;
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public DataTable TimSanPhamTheoMaSP(string MaSP)
        {
            SqlCommand cmd = new SqlCommand("select * from SANPHAM where MASP=@MASP");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MASP",MaSP);
            return SQLDB.SQLDB.getData(cmd);
        }
        public void XoaSanPham (string MASP)
        {
            SqlCommand cmd = new SqlCommand("delete from SANPHAM where MASP=@MASP");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MASP",MASP);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public void CapNhatDanhMucCuaSP(string MASP,string MADM)
        {
            SqlCommand cmd = new SqlCommand("update SANPHAM set MADM=@MADM where MASP=@MASP");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MASP", MASP);
            cmd.Parameters.AddWithValue("@MADM", MADM);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
         public DataTable LayDSSPTheoMAHD(string MAHD)
        {
            SqlCommand cmd = new SqlCommand("select c.MAHD,c.MASP,TENSP,c.SOLUONG,DONGIA,DONGIA*c.SOLUONG as THANHTIEN from SANPHAM a,HOADON b,CTHOADON c where a.MASP=c.MASP and b.MAHD=c.MAHD and b.MAHD=@MAHD and a.MASP!='SP00' group by c.MAHD,c.MASP,TENSP,c.SOLUONG,DONGIA");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAHD", MAHD);
            return SQLDB.SQLDB.getData(cmd);
        }
        //USER
        public DataTable LayDSSPMoiNhat()
        {
            SqlCommand cmd = new SqlCommand("select top 4 * from SANPHAM a where TRANGTHAI='true' order by NGAYTAO desc");
            cmd.CommandType = CommandType.Text;
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable LayDSSPMuaNhieuNhat()
        {
            SqlCommand cmd = new SqlCommand("select distinct top 4 b.MASP,TENSP,HINH,DONGIA,TACGIA,a.SOLUONGBAN  from SANPHAM a,CTHOADON b, HOADON c"
 + "  where a.MASP = b.MASP and c.MAHD = b.MAHD"
 + "  group by b.MASP, a.TRANGTHAI, c.NGAYTAO, TENSP, HINH, DONGIA,TACGIA,a.SOLUONGBAN"
 + "  having a.TRANGTHAI = 'true' and(GETDATE() - c.NGAYTAO) <= dateadd(day, -30, getdate())"
 + "  and COUNT(b.MASP) in (select top 4 count(b.MASP)from SANPHAM a, CTHOADON b, HOADON c"
 + "  where a.MASP = b.MASP and c.MAHD = b.MAHD"
 + "  group by b.MASP, a.TRANGTHAI, c.NGAYTAO"
  + " having a.TRANGTHAI = 'true' and(GETDATE() - c.NGAYTAO) <= dateadd(day, -30, getdate())"
 + " order by count(b.MASP) desc)");
            cmd.CommandType = CommandType.Text;
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable LayDSSPKichHoatTheoDM(string MADM)
        {
            SqlCommand cmd = new SqlCommand("select a.MASP,TENSP,HINH,DONGIA,TACGIA,TENDM,a.SOLUONGBAN from SANPHAM a, DANHMUCSP b where a.MADM=b.MADM and a.TRANGTHAI='True' and b.MADM=@MADM");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MADM", MADM);
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable LayDSSPKichHoatTheoTuKhoa(string TuKhoa)
        {
            string sql = "select * from SANPHAM where TENSP like N'%{0}%' or TACGIA like N'%{0}%' or TENSP COLLATE Latin1_General_CI_AI like '%{0}%' or TACGIA COLLATE Latin1_General_CI_AI like '%{0}%' and TRANGTHAI='true'";

            SqlCommand cmd = new SqlCommand(string.Format(sql,TuKhoa));
            cmd.CommandType = CommandType.Text;
          
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable TimSanPhamKichHoatTheoMaSP(string MaSP)
        {
            SqlCommand cmd = new SqlCommand("select MASP,TENDM,TENSP,HINH,DONGIA,TACGIA,SOTRANG,NXB,MOTA,SOLUONGBAN from SANPHAM a, DANHMUCSP b where a.MADM=b.MADM and a.TRANGTHAI='true' and a.MASP=@MASP");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MASP", MaSP);
            return SQLDB.SQLDB.getData(cmd);
        }
    }
}
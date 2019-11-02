using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookShop.App_Code
{
    public class XuLyHoaDon
    {
        public DataTable TimHoaDonTheoMaHD(string MAHD)
        {
            SqlCommand cmd = new SqlCommand("select a.MAHD,USERNAME,HOTEN,DIACHI,EMAIL,DIENTHOAI,FAX,CTY,TINHTRANG,a.TRANGTHAI, ISNULL(SUM(b.DONGIA*c.SOLUONG),0) AS TONGTIEN from HOADON a left join CTHOADON c on a.MAHD=c.MAHD left join  SANPHAM b on b.MASP=c.MASP  where  a.MAHD=@MAHD group by a.MAHD,USERNAME,HOTEN,DIACHI,EMAIL,DIENTHOAI,TINHTRANG,a.TRANGTHAI,FAX,CTY");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAHD", MAHD);
            return SQLDB.SQLDB.getData(cmd);
        }
        public XuLyHoaDon()
        {

        }
        public void ThemHD(string MAHD, string USERNAME, string HOTEN,string DIACHI,string EMAIL,string SDT,string FAX,string CONGTY,string TINHTRANG,DateTime NGAYTAO, bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("insert into HOADON values (@MAHD,@USERNAME,@HOTEN,@DIACHI,@EMAIL,@SDT,@FAX,@CTY,@TINHTRANG,@NGAYTAO,@TRANGTHAI)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAHD", MAHD);
            cmd.Parameters.AddWithValue("@USERNAME",USERNAME);
            cmd.Parameters.AddWithValue("@HOTEN",HOTEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@SDT", SDT);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@CTY", CONGTY);
            cmd.Parameters.AddWithValue("@TINHTRANG", TINHTRANG);
            cmd.Parameters.AddWithValue("@NGAYTAO", NGAYTAO);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public DataTable LayDSHoaDon()
        {
            SqlCommand cmd = new SqlCommand("select a.MAHD,USERNAME,HOTEN,DIACHI,EMAIL,DIENTHOAI,TINHTRANG,a.TRANGTHAI, ISNULL(SUM(b.DONGIA*c.SOLUONG),0) AS TONGTIEN from HOADON a left join CTHOADON c on a.MAHD = c.MAHD left join SANPHAM b on c.MASP = b.MASP group by a.MAHD, USERNAME, HOTEN, DIACHI, EMAIL, DIENTHOAI, TINHTRANG, a.TRANGTHAI, a.NGAYTAO order by a.NGAYTAO desc");
            cmd.CommandType = CommandType.Text;
            return SQLDB.SQLDB.getData(cmd);
        }
        public void CapNhatHD(string MAHD, string USERNAME, string HOTEN, string DIACHI, string EMAIL, string SDT, string FAX, string CONGTY, string TINHTRANG, bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("update HOADON set USERNAME=@USERNAME,HOTEN=@HOTEN,DIACHI=@DIACHI,EMAIL=@EMAIL,DIENTHOAI=@SDT,FAX=@FAX,CTY=@CONGTY,TINHTRANG=@TINHTRANG,TRANGTHAI=@TRANGTHAI where MAHD=@MAHD");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAHD", MAHD);
            cmd.Parameters.AddWithValue("@USERNAME", USERNAME);
            cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@SDT", SDT);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@CONGTY", CONGTY);
            cmd.Parameters.AddWithValue("@TINHTRANG", TINHTRANG);
    
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public void ThemSPVaoHoaDon(string MAHD,string MASP, int SOLUONG)
        {
            SqlCommand cmd = new SqlCommand("insert into CTHOADON values(@MAHD,@MASP,@SOLUONG)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAHD", MAHD);
            cmd.Parameters.AddWithValue("@MASP",MASP);
            cmd.Parameters.AddWithValue("@SOLUONG", SOLUONG);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);

        }
        public void XoaSPTrongHoaDon(string MAHD, string MASP)
        {
            SqlCommand cmd = new SqlCommand("delete from CTHOADON where MAHD=@MAHD and MASP=@MASP");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MAHD", MAHD);
            cmd.Parameters.AddWithValue("@MASP", MASP);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public DataTable TongSPBanDuocTrongThang(string Thang,string Nam)
        {
            SqlCommand cmd = new SqlCommand("select sum(SOLUONG) as TONGSL from CTHOADON a,HOADON b where a.MAHD=b.MAHD and YEAR(NGAYTAO)=@Nam and MONTH(NGAYTAO)=@Thang ");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Thang",Thang);
            cmd.Parameters.AddWithValue("@Nam", Nam);
          return  SQLDB.SQLDB.getData(cmd);
        }
        public DataTable TongDoanhThu(string Thang, string Nam)
        {
            SqlCommand cmd = new SqlCommand("select sum(SOLUONG*DONGIA) as TONGDT from CTHOADON a,HOADON b, SANPHAM c where a.MAHD = b.MAHD and a.MASP = c.MASP and YEAR(b.NGAYTAO) = @Nam and MONTH(b.NGAYTAO) =@Thang ");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Thang", int.Parse(Thang));
            cmd.Parameters.AddWithValue("@Nam",int.Parse( Nam));
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable LayDSSPBanDuoc(string Thang, string Nam)
        {
            SqlCommand cmd = new SqlCommand("select c.MASP,TENSP,TENDM,SUM(a.SOLUONG) as TONGSL,DONGIA,SUM(a.SOLUONG)*DONGIA as TONGTIEN from CTHOADON a,HOADON b, SANPHAM c , DANHMUCSP d where a.MAHD = b.MAHD and a.MASP = c.MASP and c.MADM = d.MADM and c.MASP != 'SP00'and YEAR(b.NGAYTAO) = @Nam and MONTH(b.NGAYTAO) = @Thang group by c.MASP, TENSP, TENDM, DONGIA");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Thang", int.Parse(Thang));
            cmd.Parameters.AddWithValue("@Nam", int.Parse(Nam));
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable LayDSTongSanPhamTheoTungDanhMuc(string Thang, string Nam)
        {
            SqlCommand cmd = new SqlCommand("select TENDM, SUM(d.SOLUONG) as TONGSL from SANPHAM a, DANHMUCSP b, HOADON c, CTHOADON d where a.MADM=b.MADM and a.MASP=d.MASP and c.MAHD=d.MAHD and year(c.NGAYTAO)=@NAM and MONTH(c.NGAYTAO)=@THANG  group by TENDM ");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@NAM", Nam);
            cmd.Parameters.AddWithValue("@THANG", Thang);
            return SQLDB.SQLDB.getData(cmd);
        }
        public DataTable LayDSSanPhamCoSLMuaCaoNhat(string Thang,string Nam)
        {
            SqlCommand cmd = new SqlCommand("select top 5 TENSP,SUM(a.SOLUONG) as TONGTIEN from CTHOADON a,HOADON b, SANPHAM c , DANHMUCSP d where a.MAHD = b.MAHD and a.MASP = c.MASP and c.MADM = d.MADM and c.MASP != 'SP00'and YEAR(b.NGAYTAO) =@NAM and MONTH(b.NGAYTAO) = @THANG group by TENSP, TENDM, DONGIA order by SUM(a.SOLUONG)*DONGIA desc");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@NAM", Nam);
            cmd.Parameters.AddWithValue("@THANG", Thang);
            return SQLDB.SQLDB.getData(cmd);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookShop.App_Code
{
    public class XuLyDanhMuc
    {
        public DataTable TimDanhMucTheoMaDM(string MADM)
        {
            SqlCommand cmd = new SqlCommand("select * from DANHMUCSP where MADM=@MADM");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MADM", MADM);
            return SQLDB.SQLDB.getData(cmd);
        }
        public XuLyDanhMuc()
        {

        }
        public void ThemDM(string MADM,string TENDM,string GHICHU, bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("insert into DANHMUCSP values (@MADM,@TENDM,@GHICHU,@TRANGTHAI)");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MADM",MADM);
            cmd.Parameters.AddWithValue("@TENDM",TENDM);
            cmd.Parameters.AddWithValue("@GHICHU",GHICHU);
            cmd.Parameters.AddWithValue("@TRANGTHAI",TRANGTHAI);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        public DataTable LayDSDanhMuc()
        {
            SqlCommand cmd = new SqlCommand("select * from DANHMUCSP");
            cmd.CommandType = CommandType.Text;
            return SQLDB.SQLDB.getData(cmd);
        }

        public void CapNhatDM(string MADM, string TENDM, string GHICHU, bool TRANGTHAI)
        {
            SqlCommand cmd = new SqlCommand("update DANHMUCSP set TENDM=@TENDM,GHICHU=@GHICHU,TRANGTHAI=@TRANGTHAI where MADM=@MADM");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@MADM", MADM);
            cmd.Parameters.AddWithValue("@TENDM", TENDM);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            SQLDB.SQLDB.ExcuteNonQuery(cmd);
        }
        //USER
        public DataTable LayDSDanhMucKichHoat()
        {
            SqlCommand cmd = new SqlCommand("select * from DANHMUCSP where TRANGTHAI='true'");
            cmd.CommandType = CommandType.Text;
            return SQLDB.SQLDB.getData(cmd);
        }
    }
}
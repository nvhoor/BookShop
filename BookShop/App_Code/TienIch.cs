using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BookShop.App_Code
{
    public static class TienIch
    {
        public static string MaHoaMD5(string ChuoiMaHoa)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(ChuoiMaHoa);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
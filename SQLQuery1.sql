﻿select a.MAHD,USERNAME,HOTEN,DIACHI,EMAIL,DIENTHOAI,FAX,CTY,TINHTRANG,a.TRANGTHAI, SUM(b.DONGIA*c.SOLUONG) AS TONGTIEN from HOADON a,SANPHAM b,CTHOADON c  where a.MAHD=c.MAHD and b.MASP=c.MASP and a.MAHD='HD01' group by a.MAHD,USERNAME,HOTEN,DIACHI,EMAIL,DIENTHOAI,TINHTRANG,a.TRANGTHAI,FAX,CTY
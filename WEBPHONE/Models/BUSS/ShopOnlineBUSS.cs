using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBPHONE.Models.BUSS
{
    public class ShopOnlineBUSS
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            var db= new ShopConnectionDB();
            return db.Query<SanPham>("Select * from SanPham where TinhTrang =0");
        }
        public static SanPham ChiTiet(String a)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<SanPham>("Select * from SanPham where MaSP =@0",a);
        }
    }
}
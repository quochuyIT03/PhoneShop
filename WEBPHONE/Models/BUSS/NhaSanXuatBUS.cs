using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBPHONE.Models.BUSS
{
    public class NhaSanXuatBUS
    {
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<NhaSanXuat>("Select * from NhaSanXuat");
        }
        public static IEnumerable<SanPham> ChiTiet(String id)
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("Select * from SanPham where NhaSX = '"+id+"'");
        }

        public static void ThemNSX(NhaSanXuat nsx)
        {
            var db = new ShopConnectionDB();
            db.Insert(nsx);
        }
    }
}

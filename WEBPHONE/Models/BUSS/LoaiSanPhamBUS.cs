using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBPHONE.Models.BUSS
{
    public class LoaiSanPhamBUS
    {
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<LoaiSanPham>("Select * from LoaiSanPham");
        }

        public static IEnumerable<SanPham> ChiTiet(String id)
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("Select * from SanPham where MaLoaiSP = '"+id+"'");
        }
    }
}
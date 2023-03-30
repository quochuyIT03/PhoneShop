using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WEBPHONE.Models.BUSS
{
    public class ShopOnlineBUSS
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("Select * from SanPham where TinhTrang =0");
        }
        public static SanPham ChiTiet(String a)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<SanPham>("Select * from SanPham where MaSP =@0", a);
        }
        //------------------
        public static IEnumerable<SanPham> Top4New()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select Top 4 * from SanPham where Luotview < '100' AND TinhTrang = '0         '");
        }
        public static IEnumerable<SanPham> TopHot()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select Top 4 * from SanPham Where LuotView > '1000' AND TinhTrang = '0         ' ORDER BY LuotView desc");
        }

        public static void CapNhatLuotView(string masp)
        {
            var db = new ShopConnectionDB();
            var a = ChiTiet(masp);
            a.LuotXem = a.LuotXem + 1;
            db.Update(a, masp);
        }
        //----------------------------------------------admin----------
        public static IEnumerable<SanPham> DanhSachSP()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham");
            //foreach (var item in ds)
            //{
            //    item.HinhChinh = LoadAvartaImg(item.MaSanPham);
            //}
            //return ds;
        }
        public static void InsertSP(SanPham sp)
        {
            var db = new ShopConnectionDB();
            db.Insert(sp);
        }
        public static void UpdateSP(String id, SanPham sp)
        {
            var db = new ShopConnectionDB();
            db.Update(sp, id);
        }

        //----------------------------------update images---------------
        public static void UpdateImages(string id, string images)
        {
            var db = new ShopConnectionDB();
            var sp = ShopOnlineBUSS.ChiTiet(id);
            sp.HinhChinh = images;
            db.Update(sp, id);
        }
        //------------------------Loai ảnh đại diện cho hình ảnh-------------
        public static string LoadAvartaImg(string id)
        {
            var sp = ChiTiet(id);

            var product = ShopOnlineBUSS.ChiTiet(id);
            var images = product.HinhChinh;
            XElement xImages = XElement.Parse(images);
            List<string> listImageReturn = new List<string>();

            foreach (XElement element in xImages.Elements())
            {
                listImageReturn.Add(element.Value);
            }
            if (listImageReturn.Count() == 0)
            {
                return "/Asset/data/images/default.png";
            }
            return listImageReturn.ElementAt(0).ToString();
        }

    }
}
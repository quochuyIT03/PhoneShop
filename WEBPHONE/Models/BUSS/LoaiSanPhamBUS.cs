using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBPHONE.Models.BUSS
{
    public class LoaiSanPhamBUS
    {
        //------------Khach hang 
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
        //------------admin
        public static IEnumerable<LoaiSanPham> DanhSachAdmin()
        {
            var db = new ShopConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham");
        }
        public static void InsertLSP(LoaiSanPham lsp)
        {
            var db = new ShopConnectionDB();
            db.Insert(lsp);
        }
        public static LoaiSanPham ChiTietAdmin(String id)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<LoaiSanPham>("select * from LoaiSanPham where MaLoaiSP = '" + id + "'");
        }
        public static void EditLSP(String id, LoaiSanPham lsp)
        {
            var db = new ShopConnectionDB();
            db.Update(lsp, id);
        }
        public static void DeleteLSP(String id, LoaiSanPham lsp)
        {
            var db = new ShopConnectionDB();
            db.Update(lsp, id);
        }

       
    }
}
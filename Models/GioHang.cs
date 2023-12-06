using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySach.Models
{
    public class GioHang
    {
        QLBSDataContext db = new QLBSDataContext();
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string AnhBia { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get { return SoLuong * DonGia; }
        }
        public GioHang(int MaSach)
        {
            this.MaSach = MaSach;
            Sach sach = db.Saches.Single(s => s.MaSach == MaSach);
            TenSach = sach.TenSach;
            AnhBia = sach.AnhBia;
            DonGia = double.Parse(sach.GiaBan.ToString());
            SoLuong = 1;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySach.Models
{
    public class taiKhoan
    {
        QLBSDataContext db = new QLBSDataContext();
        public int MaKH { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public taiKhoan(int maKH)
        {

            this.MaKH = maKH;
            KhachHang kh = db.KhachHangs.Single(s => s.MaKH == maKH);
            hoTen = kh.HoTen;
            diaChi = kh.DiaChi;
            soDienThoai = kh.DienThoai;
        }
    }
}
using QuanLySach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySach.Controllers
{
    public class NguoiDungController : Controller
    {
        QLBSDataContext db = new QLBSDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh, FormCollection f)
        {
            var hoTen = f["HoTenKH"];
            var tenDN = f["TenDN"];
            var matKhau = f["MatKhau"];
            var reMatKhau = f["ReMatKhau"];
            var dienThoai = f["DienThoai"];
            var ngaySinh = String.Format("{0:MM/DD/YYYY}", f["NgaySinh"]);
            var email = f["email"];
            var diaChi = f["DiaChi"];
            if (String.IsNullOrEmpty(hoTen))
            {
                ViewBag["Loi1"] = "Họ Tên Không Được Bỏ Trống";
            }
            if (String.IsNullOrEmpty(tenDN))
            {
                ViewBag["Loi2"] = "Tên Đăng Nhập Không Được Bỏ Trống";
            }
            if (String.IsNullOrEmpty(matKhau))
            {
                ViewBag["Loi3"] = "Vui Lòng Nhập Mật Khẩu";
            }
            if (String.IsNullOrEmpty(reMatKhau))
            {
                ViewBag["Loi4"] = "Vui Lòng Nhập Mật Khẩu";
            }
            if (String.IsNullOrEmpty(dienThoai))
            {
                ViewBag["Loi5"] = "Vui Lòng Nhập Số Điện Thoại";
            }
            kh.HoTen = hoTen;
            kh.TaiKhoan = tenDN;
            kh.MatKhau = matKhau;
            kh.NgaySinh = DateTime.Parse(ngaySinh);
            kh.DiaChi = diaChi;
            kh.Email = email;
            db.KhachHangs.InsertOnSubmit(kh);
            db.SubmitChanges();
            return RedirectToAction("DangNhap", "NguoiDung");
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhapDN(string taiKhoan, string MatKhau)
        {
            if (ModelState.IsValid)
            {
                var data = db.KhachHangs.Where(s => s.TaiKhoan.Equals(taiKhoan) && s.MatKhau.Equals(MatKhau)).ToList();
                var admin = db.KhachHangs.Where(s => s.TaiKhoan.Equals("myclass") && s.MatKhau.Equals("123")).ToList();
                if (data.Count > 0)
                {
                    Session["HoTenKH"] = data.FirstOrDefault().HoTen;
                    Session["email"] = data.FirstOrDefault().Email;
                    Session["id"] = data.FirstOrDefault().MaKH;
                    return RedirectToAction("Index", "Home");
                }
                //else if (admin.Count > 0)
                //{
                //    //return RedirectToAction("index", "star-admin2-free-admin-template-main");
                //}
                else
                {
                    ViewBag.error = "Dăng Nhập Thất Bại";
                    return RedirectToAction("DangNhap", "NguoiDung");
                }
                
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }
}
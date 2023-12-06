using QuanLySach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySach.Controllers
{
    public class SachController : Controller
    {
        QLBSDataContext db = new QLBSDataContext();

        // GET: Sach
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SachPartial()
        {
            var listSach = db.Saches.OrderBy(s => s.TenSach).ToList();
            return View("SachPartial", listSach);
        }
        public ActionResult XemChiTiet(int ms)
        {
            Sach sp = db.Saches.Single(s => s.MaSach == ms);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

    }
}
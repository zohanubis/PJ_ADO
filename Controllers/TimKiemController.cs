using QuanLySach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySach.Controllers
{
    public class TimKiemController : Controller
    {
        QLBSDataContext db = new QLBSDataContext();
        // GET: TimKiem
        public ActionResult TimKiem(string searchString)
        {
            var links = from l in db.Saches select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.TenSach.Contains(searchString));
            }

            return View(links);
        }
    }
}
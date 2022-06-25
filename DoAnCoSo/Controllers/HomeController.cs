using DoAnCoSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext data;
        public HomeController()
        {
            data = new ApplicationDbContext();
        }
        public ActionResult Shop()
        {
            var shop = data.Shop.ToList();
            return View(shop.ToList());
        }
        public ActionResult Details(int id)
        {
            var shop = data.Shop.Where(m => m.Id == id).First();
            return View(shop);
        }
    
        public ActionResult Index()
        {

            var shop = data.Shop.ToList();
            return View(shop.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Windows()
        {
            var windows = data.Shop.Where(a => a.PhanLoai == "LaptopWD").ToList();

            return View(windows);
        }
        public ActionResult IMacs()
        {
            var IMacs = data.Shop.Where(a => a.PhanLoai == "IMacs").ToList();

            return View(IMacs);
        }
        public ActionResult Macbooks()
        {
            var Macbooks = data.Shop.Where(a => a.PhanLoai == "MB").ToList();

            return View(Macbooks);
        }
        public ActionResult MacOS()
        {
            var MacOS = data.Shop.Where(a => a.PhanLoai == "MB").ToList();

            return View(MacOS);
        }
        public ActionResult MHGamings()
        {
            var MHGamings = data.Shop.Where(a => a.PhanLoai == "MHGM").ToList();

            return View(MHGamings);
        }
        public ActionResult MHVanPhongs()
        {
            var MHVanPhongs = data.Shop.Where(a => a.PhanLoai == "MHVP").ToList();

            return View(MHVanPhongs);
        }
        public ActionResult PCGamings()
        {
            var PCGamings = data.Shop.Where(a => a.PhanLoai == "PCGM").ToList();

            return View(PCGamings);
        }
        public ActionResult PCVanPhongs()
        {
            var PCVanPhongs = data.Shop.Where(a => a.PhanLoai == "PCVP").ToList();

            return View(PCVanPhongs);
        }
    }
}
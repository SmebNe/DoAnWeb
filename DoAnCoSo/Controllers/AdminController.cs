using DoAnCoSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoSo.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext data;
        public AdminController()
        {
            data = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shop()
        {
            var shop = data.Shop.ToList();

            return View(shop.ToList());
        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Shop s)
        {

            var ten = collection["Ten"];
            var trangthai = collection["TrangThai"];
            var phanloai = collection["PhanLoai"];
            var mota = collection["MoTa"];
            var thongso = collection["ThongSo"];
            var namsx = collection["NamSanXuat"];
            var gia = collection["Gia"];
            var hinh = collection["Hinh"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.Ten = ten.ToString();
                s.TrangThai = trangthai.ToString();
                s.PhanLoai = phanloai;
                s.MoTa = mota;
                s.ThongSo = thongso;
                s.NamSanXuat = namsx;
                s.Gia = gia;
                s.Hinh = hinh;
                data.Shop.Add(s);
                data.SaveChanges();
                return RedirectToAction("Shop");
            }
            return this.Create();
        }
        public ActionResult EditShop(int id)
        {
            //var shop = data.Shop.ToList();

            //return View(shop);
            var shop = data.Shop.Where(m => m.Id == id).First();
            return View(shop);
        }



        public ActionResult Edit(int id)
        {
            var e = data.Shop.First(m => m.Id == id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var s = data.Shop.First(m => m.Id == id);
            var ten = collection["Ten"];
            var trangthai = collection["TrangThai"];
            var phanloai = collection["PhanLoai"];
            var mota = collection["MoTa"];
            var thongso = collection["ThongSo"];
            var namsx = collection["NamSanXuat"];
            var gia = double.Parse( collection["Gia"]);
            var hinh = collection["Hinh"];
            s.Id = id;
            if (string.IsNullOrEmpty(ten) || gia <= 0)
            {
                //string a = "Số lượng tồn phải lớn hơn 0!";
                ViewData["ErrorMessage"] = "Don't empty!";
                // ScriptManager.RegisterStartupScript(id, id.GetType(), "MyScript", "alert('" + a + "');", true);

                Response.Write("<script>alert('Số lượng tồn phải lớn hơn 0!')</script>");
            }
            else
            {
                s.Ten = ten.ToString();
                s.TrangThai = trangthai.ToString();
                s.PhanLoai = phanloai;
                s.MoTa = mota;
                s.ThongSo = thongso;
                s.NamSanXuat = namsx;
                s.Gia = gia.ToString();
                s.Hinh = hinh;
                data.Shop.Add(s);
                data.SaveChanges();
                return RedirectToAction("Shop");
            }
            return this.Edit(id);
        }


        public ActionResult Delete(int id)
        {
            var e = data.Shop.Find(id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var e = data.Shop.Where(m => m.Id == id).First();
            data.Shop.Remove(e);
            data.SaveChanges();
            return RedirectToAction("Shop");
        }

       
    }
}

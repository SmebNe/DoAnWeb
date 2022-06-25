using DoAnCoSo.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoSo.Controllers
{
    public class GiohangController : Controller
    {
        //QLbanhang db = new QLbanhang();
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: GioHang

        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGiohang = new List<GioHang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMa, string strURL)
        {
            Shop sp = db.Shop.SingleOrDefault(n => n.Id == iMa);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGiohang = LayGioHang();
            //Kiểm tra sp này đã tồn tại trong session[giohang] chưa
         
            GioHang sanpham = lstGiohang.Find(n => n.iMa == iMa);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMa);
                //Add sản phẩm mới thêm vào list
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int iMa, FormCollection f)
        {
            //Kiểm tra masp
            Shop sp = db.Shop.SingleOrDefault(n => n.Id == iMa);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGiohang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.iMa == iMa);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("Giohang");
        }
        public ActionResult XoaGioHang(int iMa)
        {
            //Kiểm tra masp
            Shop sp = db.Shop.SingleOrDefault(n => n.Id == iMa);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGiohang = LayGioHang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.iMa == iMa);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.iMa == iMa);

            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Giohang");
        }
        [Authorize]
        public ActionResult Giohang()
        {
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGiohang = LayGioHang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.iSoluong);
            }
            return iTongSoLuong;
        }
        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Count;
            }
            return tsl;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                dTongTien = lstGiohang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        public ActionResult GiohangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }


       

        [HttpPost]
        public ActionResult DatHang()
        {
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGiohang = LayGioHang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);
        }
        //Thêm đơn hàng
        public ActionResult DatHang(FormCollection collection)
        {

            Donhang dh = new Donhang();
            Nguoidung kh = (Nguoidung)Session["use"];
            Sanpham s = new Sanpham();
            List<GioHang> gh = LayGioHang();

            //dh.MaNguoidung = kh.MaNguoiDung;
            dh.Ngaydat = DateTime.Now;
            Console.WriteLine(dh);


            db.Donhangs.Add(dh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                Chitietdonhang ctdh = new Chitietdonhang();
                decimal thanhtien = item.iSoluong * (decimal)item.dDongia;
                ctdh.Madon = dh.Madon;
                ctdh.Ma = item.iMa;
                ctdh.Soluong = item.iSoluong;
                ctdh.Dongia = (decimal)item.dDongia;
                ctdh.Giatien = (decimal)thanhtien;

                db.SaveChanges();
                db.Chitietdonhangs.Add(ctdh);
            }
            db.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("Index", "Donhangs");
        }

        public ActionResult XacNhan()
        {

            return View();

        }
    }

}

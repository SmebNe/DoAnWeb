using DoAnCoSo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoSo.Models
{
    public class GioHang
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [Key]
        public int iMa { get; set; }
        [Display(Name = "Tên Sản phẩm")]
        public string sTen { get; set; }
        [Display(Name = "Hình ảnh")]

        public string sHinhanh { get; set; }
        [Display(Name = "Giá tiền")]

        public double dDongia { get; set; }
        [Display(Name = "Số lượng")]

        public int iSoluong { get; set; }
        public double ThanhTien
        {
            get { return iSoluong * dDongia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int Masach)
        {
            iMa = Masach;
            Shop sp = db.Shop.Single(n => n.Id == iMa);
            sTen = sp.Ten;
            sHinhanh = sp.Hinh;
            dDongia = double.Parse(sp.Gia.ToString());
            iSoluong = 1;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCoSo.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string TrangThai { get; set; }
        public string PhanLoai { get; set; }
        public string MoTa { get; set; }
        public string ThongSo { get; set; }
        public string NamSanXuat { get; set; }
        public string Gia { get; set; }
        public string Hinh { get; set; }
        public string Rong { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    public class HangHoaView
    {
        [Key]
        [Display(Name = "Mã hàng hóa")]
        public int MaHh { get; set; }        
        [Display(Name = "Tên hàng hóa")]
        public string TenHh { get; set; }
        [MaxLength(150)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
    }
}

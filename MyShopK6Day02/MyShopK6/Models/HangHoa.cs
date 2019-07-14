using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        [Display(Name = "Mã hàng hóa")]
        public int MaHh { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage ="*")]
        [Display(Name = "Tên hàng hóa")]
        public string TenHh { get; set; }
        [MaxLength(150)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Mô tả")]
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        [Display(Name = "Loại")]
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        [Display(Name = "Loại")]
        public Loai Loai { get; set; }

        [MaxLength(50)]
        [Display(Name ="Thương hiệu")]
        public string MaTh { get; set; }
        [ForeignKey("MaTh")]
        [Display(Name = "Thương hiệu")]
        public ThuongHieu ThuongHieu { get; set; }
    }
}

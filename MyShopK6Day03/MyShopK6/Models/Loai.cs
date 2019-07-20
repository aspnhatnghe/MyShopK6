using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        [Display(Name ="Mã loại")]
        public int MaLoai { get; set; }
        [MaxLength(50)]        
        [Display(Name ="Tên loại")]
        public string TenLoai { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [MaxLength(150)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Loại")]
        //Null hoặc 0 : level 1
        public int? MaLoaiCha { get; set; }
        [Display(Name = "Loại")]
        [ForeignKey("MaLoaiCha")]
        public Loai LoaiCha { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    [Table("ThuongHieu")]
    public class ThuongHieu
    {
        [Key]
        [MaxLength(50)]
        public string MaTh { get; set; }
        [Required(ErrorMessage ="*")]
        [MaxLength(50)]
        public string TenThuongHieu { get; set; }
        [MaxLength(150)]
        public string DiaChi { get; set; }
        [MaxLength(50)]
        public string DienThoai { get; set; }
        [MaxLength(150)]
        public string Logo { get; set; }
    }
}

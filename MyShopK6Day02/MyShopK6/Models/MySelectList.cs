using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    /// <summary>
    /// Lớp SelectList tùy chọn
    /// </summary>
    /// <typeparam name="T">Kiểu tùy ý</typeparam>
    public class MySelectList<T>
    {
        //Danh sách dữ liệu chọn
        public List<T> Data { get; set; }
        //thông tin mã đang chọn
        public int? Selected { get; set; }
    }
}

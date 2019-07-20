using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopK6.Models;
using MyShopK6.Helper;

namespace MyShopK6.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("HoTen", "Trần Văn Tèo");
            HttpContext.Session.SetInt32("HSD", DateTime.Now.Year);

            ThuongHieu thuongHieu = new ThuongHieu
            {
                MaTh = "DELL", TenThuongHieu = "DELL LAPTOP",
                DienThoai = "0909 009 879"
            };

            HttpContext.Session.SetObject("ThuongHieu", thuongHieu);

            return View("Index");
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Remove("HoTen");
            HttpContext.Session.Remove("HSD");
            HttpContext.Session.Remove("ThuongHieu");

            return View("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShopK6.Models;

namespace MyShopK6.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly IMapper mapper;
        private readonly MyDbContext ctx;
        public HangHoaController(MyDbContext db, IMapper map)
        {
            ctx = db; mapper = map; 
        }
        public IActionResult Index(int? id)
        {
            var dsHangHoa = ctx.HangHoas.AsQueryable();
            if(id.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(p => p.MaLoai == id);
            }

            //map HangHoa ---> HangHoaView
            var hangHoas = mapper.Map<List<HangHoaView>>(dsHangHoa.ToList());

            if (id.HasValue)
            {
                Loai loai = ctx.Loais.SingleOrDefault(p => p.MaLoai == id.Value);
                ViewBag.Loai = loai;
            }

            return View(hangHoas);
        }
    }
}
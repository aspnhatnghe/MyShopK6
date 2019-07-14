using Microsoft.AspNetCore.Mvc;
using MyShopK6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.ViewComponents
{
    public class MenuLoai : ViewComponent
    {
        private readonly MyDbContext ctx;
        public MenuLoai(MyDbContext db)
        {
            ctx = db;
        }

        public IViewComponentResult Invoke()
        {
            return View(ctx.Loais);
        }
    }
}

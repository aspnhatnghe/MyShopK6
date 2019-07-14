using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    public class MyTool
    {
        public static string UploadHinh(IFormFile fHinh, string folder)
        {
            string fileNameReturn = string.Empty;
            if (fHinh != null)
            {
                fileNameReturn = $"_{DateTime.Now.Ticks}{fHinh.FileName}";
                var fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, fileNameReturn);
                using (var file = new FileStream(fileName, FileMode.Create))
                {
                    fHinh.CopyTo(file);
                }
            }
            return fileNameReturn;
        }
    }

    public static class StaticClass
    {
        public static string ToVND(this double dongia)
        {
            return $"{dongia.ToString("#,##0")} đ";
        }
    }
}

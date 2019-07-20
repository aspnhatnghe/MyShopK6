using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyShopK6.Models;

namespace MyShopK6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangHoaController : Controller
    {
        private readonly MyDbContext _context;

        public HangHoaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Admin/HangHoa
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.HangHoas.Include(h => h.Loai).Include(h=>h.ThuongHieu);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Admin/HangHoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .Include(h => h.Loai)
                .FirstOrDefaultAsync(m => m.MaHh == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: Admin/HangHoa/Create
        public IActionResult Create()
        {
            //ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            ViewBag.Loai = new MySelectList<Loai>
            {
                Data = _context.Loais.ToList()
            };
            ViewBag.ThuongHieu = new SelectList(_context.ThuongHieus, "MaTh", "TenThuongHieu");
            return View();
        }

        // POST: Admin/HangHoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HangHoa hangHoa, IFormFile fHinh)
        {
            if (ModelState.IsValid)
            {
                hangHoa.Hinh = MyTool.UploadHinh(fHinh, "HangHoa");
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
            ViewBag.Loai = new MySelectList<Loai>
            {
                Data = _context.Loais.ToList(),
                Selected = hangHoa.MaLoai
            };
            ViewBag.ThuongHieu = new SelectList(_context.ThuongHieus, "MaTh", "TenThuongHieu", hangHoa.MaTh);
            return View(hangHoa);
        }

        // GET: Admin/HangHoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            //ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai", hangHoa.MaLoai);
            ViewBag.Loai = new MySelectList<Loai>
            {
                Data = _context.Loais.ToList(),
                Selected = hangHoa.MaLoai
            };
            ViewBag.ThuongHieu = new SelectList(_context.ThuongHieus, "MaTh", "TenThuongHieu", hangHoa.MaTh);
            return View(hangHoa);
        }

        // POST: Admin/HangHoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HangHoa hangHoa, IFormFile fHinh)
        {
            if (id != hangHoa.MaHh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(fHinh != null)
                    {
                        hangHoa.Hinh = MyTool.UploadHinh(fHinh, "HangHoa");
                    }
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.MaHh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai", hangHoa.MaLoai);
            ViewBag.Loai = new MySelectList<Loai>
            {
                Data = _context.Loais.ToList(),
                Selected = hangHoa.MaLoai
            };
            ViewBag.ThuongHieu = new SelectList(_context.ThuongHieus, "MaTh", "TenThuongHieu", hangHoa.MaTh);
            return View(hangHoa);
        }

        // GET: Admin/HangHoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .Include(h => h.Loai)
                .FirstOrDefaultAsync(m => m.MaHh == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // POST: Admin/HangHoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);
            _context.HangHoas.Remove(hangHoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangHoaExists(int id)
        {
            return _context.HangHoas.Any(e => e.MaHh == id);
        }
    }
}

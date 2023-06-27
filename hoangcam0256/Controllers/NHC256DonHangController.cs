using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hoangcam0256.Models;

namespace hoangcam0256.Controllers
{
    public class NHC256DonHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NHC256DonHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NHC256DonHang
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NHC256DonHang.Include(n => n.NHC256SanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NHC256DonHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NHC256DonHang == null)
            {
                return NotFound();
            }

            var nHC256DonHang = await _context.NHC256DonHang
                .Include(n => n.NHC256SanPham)
                .FirstOrDefaultAsync(m => m.NHC256MaDonHang == id);
            if (nHC256DonHang == null)
            {
                return NotFound();
            }

            return View(nHC256DonHang);
        }

        // GET: NHC256DonHang/Create
        public IActionResult Create()
        {
            ViewData["NHC256TenSanPham"] = new SelectList(_context.NHC256SanPham, "NHC256MaSanPham", "NHC256MaSanPham");
            return View();
        }

        // POST: NHC256DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NHC256MaDonHang,NHC256TenSanPham,NHC256TenKhachHang")] NHC256DonHang nHC256DonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nHC256DonHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NHC256TenSanPham"] = new SelectList(_context.NHC256SanPham, "NHC256MaSanPham", "NHC256MaSanPham", nHC256DonHang.NHC256TenSanPham);
            return View(nHC256DonHang);
        }

        // GET: NHC256DonHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NHC256DonHang == null)
            {
                return NotFound();
            }

            var nHC256DonHang = await _context.NHC256DonHang.FindAsync(id);
            if (nHC256DonHang == null)
            {
                return NotFound();
            }
            ViewData["NHC256TenSanPham"] = new SelectList(_context.NHC256SanPham, "NHC256MaSanPham", "NHC256MaSanPham", nHC256DonHang.NHC256TenSanPham);
            return View(nHC256DonHang);
        }

        // POST: NHC256DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NHC256MaDonHang,NHC256TenSanPham,NHC256TenKhachHang")] NHC256DonHang nHC256DonHang)
        {
            if (id != nHC256DonHang.NHC256MaDonHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nHC256DonHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NHC256DonHangExists(nHC256DonHang.NHC256MaDonHang))
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
            ViewData["NHC256TenSanPham"] = new SelectList(_context.NHC256SanPham, "NHC256MaSanPham", "NHC256MaSanPham", nHC256DonHang.NHC256TenSanPham);
            return View(nHC256DonHang);
        }

        // GET: NHC256DonHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NHC256DonHang == null)
            {
                return NotFound();
            }

            var nHC256DonHang = await _context.NHC256DonHang
                .Include(n => n.NHC256SanPham)
                .FirstOrDefaultAsync(m => m.NHC256MaDonHang == id);
            if (nHC256DonHang == null)
            {
                return NotFound();
            }

            return View(nHC256DonHang);
        }

        // POST: NHC256DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NHC256DonHang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NHC256DonHang'  is null.");
            }
            var nHC256DonHang = await _context.NHC256DonHang.FindAsync(id);
            if (nHC256DonHang != null)
            {
                _context.NHC256DonHang.Remove(nHC256DonHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NHC256DonHangExists(string id)
        {
          return (_context.NHC256DonHang?.Any(e => e.NHC256MaDonHang == id)).GetValueOrDefault();
        }
    }
}

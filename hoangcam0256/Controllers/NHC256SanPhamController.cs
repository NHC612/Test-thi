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
    public class NHC256SanPhamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NHC256SanPhamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NHC256SanPham
        public async Task<IActionResult> Index()
        {
              return _context.NHC256SanPham != null ? 
                          View(await _context.NHC256SanPham.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NHC256SanPham'  is null.");
        }

        // GET: NHC256SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NHC256SanPham == null)
            {
                return NotFound();
            }

            var nHC256SanPham = await _context.NHC256SanPham
                .FirstOrDefaultAsync(m => m.NHC256MaSanPham == id);
            if (nHC256SanPham == null)
            {
                return NotFound();
            }

            return View(nHC256SanPham);
        }

        // GET: NHC256SanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NHC256SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NHC256MaSanPham,NHC256TenSanPham,NHC256Address")] NHC256SanPham nHC256SanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nHC256SanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nHC256SanPham);
        }

        // GET: NHC256SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NHC256SanPham == null)
            {
                return NotFound();
            }

            var nHC256SanPham = await _context.NHC256SanPham.FindAsync(id);
            if (nHC256SanPham == null)
            {
                return NotFound();
            }
            return View(nHC256SanPham);
        }

        // POST: NHC256SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NHC256MaSanPham,NHC256TenSanPham,NHC256Address")] NHC256SanPham nHC256SanPham)
        {
            if (id != nHC256SanPham.NHC256MaSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nHC256SanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NHC256SanPhamExists(nHC256SanPham.NHC256MaSanPham))
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
            return View(nHC256SanPham);
        }

        // GET: NHC256SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NHC256SanPham == null)
            {
                return NotFound();
            }

            var nHC256SanPham = await _context.NHC256SanPham
                .FirstOrDefaultAsync(m => m.NHC256MaSanPham == id);
            if (nHC256SanPham == null)
            {
                return NotFound();
            }

            return View(nHC256SanPham);
        }

        // POST: NHC256SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NHC256SanPham == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NHC256SanPham'  is null.");
            }
            var nHC256SanPham = await _context.NHC256SanPham.FindAsync(id);
            if (nHC256SanPham != null)
            {
                _context.NHC256SanPham.Remove(nHC256SanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NHC256SanPhamExists(int id)
        {
          return (_context.NHC256SanPham?.Any(e => e.NHC256MaSanPham == id)).GetValueOrDefault();
        }
    }
}

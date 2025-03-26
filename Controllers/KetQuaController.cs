using CSDLNC_QuanLySVNamTot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;

namespace CSDLNC_QuanLySVNamTot.Controllers
{
    public class KetQuaController : Controller
    {
        private readonly AppDBContext _context;

        public KetQuaController(AppDBContext context)
        {
            _context = context;
        }

        // GET: KetQua/Index
        public async Task<IActionResult> Index()
        {
            var ketQuas = _context.KetQuas
                .Include(k => k.SinhVien)
                .Include(k => k.NguoiXetDuyet);
            return View(await ketQuas.ToListAsync());
        }

        // GET: KetQua/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ketQua = await _context.KetQuas
                .Include(k => k.SinhVien)
                .Include(k => k.NguoiXetDuyet)
                .FirstOrDefaultAsync(k => k.MaKetQua == id);

            if (ketQua == null)
            {
                return NotFound();
            }

            return View(ketQua);
        }

        // GET: KetQua/Create
        public IActionResult Create()
        {
            ViewBag.SinhVien = new SelectList(_context.SinhViens, "MaSinhVien", "HoTen");
            ViewBag.NguoiXetDuyet = new SelectList(_context.NguoiXetDuyets, "MaNguoiXetDuyet", "HoTen");
            return View();
        }

        // POST: KetQua/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ketQua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.SinhVien = new SelectList(_context.SinhViens, "MaSinhVien", "HoTen", ketQua.MaSinhVien);
            ViewBag.NguoiXetDuyet = new SelectList(_context.NguoiXetDuyets, "MaNguoiXetDuyet", "HoTen", ketQua.MaNguoiXetDuyet);
            return View(ketQua);
        }

        // GET: KetQua/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ketQua = await _context.KetQuas.FindAsync(id);
            if (ketQua == null)
            {
                return NotFound();
            }

            ViewBag.SinhVien = new SelectList(_context.SinhViens, "MaSinhVien", "HoTen", ketQua.MaSinhVien);
            ViewBag.NguoiXetDuyet = new SelectList(_context.NguoiXetDuyets, "MaNguoiXetDuyet", "HoTen", ketQua.MaNguoiXetDuyet);
            return View(ketQua);
        }

        // POST: KetQua/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KetQua ketQua)
        {
            if (id != ketQua.MaKetQua)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ketQua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.KetQuas.Any(k => k.MaKetQua == id))
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

            ViewBag.SinhVien = new SelectList(_context.SinhViens, "MaSinhVien", "HoTen", ketQua.MaSinhVien);
            ViewBag.NguoiXetDuyet = new SelectList(_context.NguoiXetDuyets, "MaNguoiXetDuyet", "HoTen", ketQua.MaNguoiXetDuyet);
            return View(ketQua);
        }

        // GET: KetQua/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ketQua = await _context.KetQuas
                .Include(k => k.SinhVien)
                .Include(k => k.NguoiXetDuyet)
                .FirstOrDefaultAsync(k => k.MaKetQua == id);

            if (ketQua == null)
            {
                return NotFound();
            }

            return View(ketQua);
        }

        // POST: KetQua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ketQua = await _context.KetQuas.FindAsync(id);
            if (ketQua != null)
            {
                _context.KetQuas.Remove(ketQua);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}


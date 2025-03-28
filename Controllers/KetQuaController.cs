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
        
        public IActionResult Create(string? maSinhVien)
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(string? maSinhVien, KetQua ketQua)
        {
            var username = HttpContext.Session.GetString("username");

            ketQua.MaNguoiXetDuyet = username;
            
            _context.Add(ketQua);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var ketQua = await _context.KetQuas.FindAsync(id);
            return View(ketQua);
        }
        
        [HttpPost]
        public IActionResult Edit(int id, KetQua ketQua)
        {
            var username = HttpContext.Session.GetString("Username");
            ketQua.MaNguoiXetDuyet = username;
            _context.KetQuas.Update(ketQua);

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
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
        
        [HttpPost, ActionName("Delete")]
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


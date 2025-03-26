using CSDLNC_QuanLySVNamTot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CSDLNC_QuanLySVNamTot.Controllers;

public class SinhVienController : Controller
{
   private readonly AppDBContext _context;

   public SinhVienController(AppDBContext context)
   {
      _context = context;
   }

   public async Task<IActionResult> Index()
   {
      var sinhViens = await _context.SinhViens.Include(s => s.Lop).ToListAsync();
      return View(sinhViens);
   }

   public IActionResult Create()
   {
      // Lấy danh sách lớp học cho dropdown
      ViewBag.Lop = new SelectList(_context.Lops, "MaLop", "TenLop");

      // Lấy username từ session
      var username = HttpContext.Session.GetString("Username");
      var role = HttpContext.Session.GetString("Role");

      // Kiểm tra nếu username không tồn tại hoặc null
      if (string.IsNullOrEmpty(username))
      {
         return RedirectToAction("Login", "Auth"); // Chuyển hướng nếu chưa đăng nhập
      }

      // Kiểm tra xem sinh viên đã có dữ liệu chưa
      var sinhVien = _context.SinhViens.FirstOrDefault(s => s.MaSV == username);

      ViewBag.SinhVien = sinhVien;

      // Điều chỉnh logic kiểm tra
      if (sinhVien != null && role == "SinhVien")
      {
         return View("Index"); // Hoặc trang phù hợp
      }

      return View();
   }

   [HttpPost]
   public IActionResult Create(SinhVien model)
   {
      var role = HttpContext.Session.GetString("Role");
      var username = HttpContext.Session.GetString("Username");

      ViewBag.Lop = new SelectList(_context.Lops, "MaLop", "TenLop");

      ViewBag.SinhVien = _context.SinhViens.FirstOrDefault(s => s.MaSV == username);

      if (role == "SinhVien" && username != null)
      {
         model.MaSV = username;
         _context.SinhViens.Add(model);
         _context.SaveChanges();
      }

      return RedirectToAction("Index");
   }

   [HttpGet("sinhvien/edit/{id}")] // Route dành cho GET
   public async Task<IActionResult> Edit(string id)
   {
      var sinhVien = await _context.SinhViens.FirstOrDefaultAsync(s => s.MaSV == id);
      if (sinhVien == null)
      {
         return NotFound();
      }
      ViewBag.Lop = new SelectList(_context.Lops, "MaLop", "TenLop", sinhVien.MaLop);
      return View(sinhVien);
   }

   [HttpPost("sinhvien/edit/{id}")] // Route dành cho POST
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> Edit(string id, SinhVien sinhVien)
   {
      if (id != sinhVien.MaSV)
      {
         return BadRequest();
      }

      if (ModelState.IsValid)
      {
         try
         {
            _context.Update(sinhVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!_context.SinhViens.Any(sv => sv.MaSV == id))
            {
               return NotFound();
            }
            else
            {
               throw;
            }
         }
      }

      ViewBag.Lop = new SelectList(_context.Lops, "MaLop", "TenLop", sinhVien.MaLop);
      return View(sinhVien);
   }

   // Xóa sinh viên
   [HttpGet("sinhvien/delete/{id}")] 
   public async Task<IActionResult> Delete(string id)
   {
      var sinhVien = await _context.SinhViens.SingleOrDefaultAsync(s => s.MaSV == id);
      if (sinhVien == null)
      {
         return NotFound();
      }
      _context.SinhViens.Remove(sinhVien);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
   }

}
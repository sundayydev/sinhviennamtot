using Microsoft.AspNetCore.Mvc;
using CSDLNC_QuanLySVNamTot.Models;
using Microsoft.EntityFrameworkCore;

namespace CSDLNC_QuanLySVNamTot.Controllers;

public class DangKyController : Controller
{

   private readonly AppDBContext _context;

   public DangKyController(AppDBContext context)
   {
      _context = context;
   }

   // Danh sách đăng ký
   public async Task<IActionResult> Index()
   {
      if (HttpContext.Session.GetString("Role") != "NguoiXetDuyet")
      {
         return RedirectToAction("Index", "Home");
      }

      var danhSachDangKy = await _context.DangKys.Include(d => d.NguoiXetDuyet).ToListAsync();
      return View(danhSachDangKy);
   }

   // Form tạo đăng ký
   [HttpGet]
   public IActionResult Create()
   {
      var username = HttpContext.Session.GetString("Username");
      var role = HttpContext.Session.GetString("Role");

      var sinhVien = _context.SinhViens.FirstOrDefault(s => s.MaSV == username);

      if(username == null)
      {
         return RedirectToAction("login", "Auth");
      }

      if (sinhVien == null && role == "SinhVien")
      {
         return RedirectToAction("Create", "SinhVien");
      }
      return View(); 
   }

   // Xử lý tạo đăng ký
   [HttpPost]
   public async Task<IActionResult> Create(DangKy dangKy)
   {
      _context.DangKys.Add(dangKy);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
   }

   // Form sửa đăng ký
   [HttpGet]
   public async Task<IActionResult> Edit(int id)
   {
      var role = HttpContext.Session.GetString("Role");
      if (role != "NguoiXetDuyet")
      {
         return RedirectToAction("Index");
      }
      var dangKy = await _context.DangKys.SingleOrDefaultAsync(d => d.MaDangKy == id);
      if (dangKy == null)
      {
         return NotFound();
      }
      return View(dangKy);
   }

   // Xử lý cập nhật đăng ký
   [HttpPost]
   public async Task<IActionResult> Edit(int id, DangKy dangKy)
   {
      if (id != dangKy.MaDangKy)
      {
         return BadRequest();
      }

      dangKy.MaNguoiXetDuyet = HttpContext.Session.GetString("Username");  // Lấy mã người xét duyệt từ session   

      _context.Update(dangKy);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));

   
   }

   public async Task<IActionResult> Delete(int id)
   {
      var dangKy = await _context.DangKys.SingleOrDefaultAsync(s => s.MaDangKy == id);
      if (dangKy == null)
      {
         return NotFound();
      }
      _context.DangKys.Remove(dangKy);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
   }

}

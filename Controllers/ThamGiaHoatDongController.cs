using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSDLNC_QuanLySVNamTot.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CSDLNC_QuanLySVNamTot.Controllers;

public class ThamGiaHoatDongController : Controller
{
   private readonly AppDBContext _context;

   public ThamGiaHoatDongController(AppDBContext context)
   {
      _context = context;
   }

   // GET: Hiển thị danh sách hoạt động
   public async Task<IActionResult> Index()
   {
      var username = HttpContext.Session.GetString("Username");
      var hoatDongs = await _context.ThamGiaHoatDongs
         .Include(h => h.SinhVien)
         .Include(h => h.TieuChi)
         .Where(h => h.MaSinhVien == username) // Lọc theo MaSinhVien
         .ToListAsync(); // Trả về danh sách
      return View(hoatDongs);
   }

   // GET: Hiển thị form tạo mới
   public IActionResult Create()
   {
      ViewBag.TieuChiList = new SelectList(_context.TieuChis.ToList(), "MaTieuChi", "TenTieuChi");
      return View();
   }

   // POST: Lưu hoạt động mới
   [HttpPost]
   public IActionResult Create(ThamGiaHoatDong hoatDong)
   {
      var username = HttpContext.Session.GetString("Username");
      if (string.IsNullOrEmpty(username))
      {
         TempData["Error"] = "Vui lòng đăng nhập để thêm hoạt động.";
         return RedirectToAction("Login", "Account");
      }

      hoatDong.MaSinhVien = username; // Gán MaSinhVien từ session
      _context.ThamGiaHoatDongs.Add(hoatDong);
      _context.SaveChanges();
      TempData["Success"] = "Thêm hoạt động thành công!";


      ViewBag.TieuChiList = new SelectList(_context.TieuChis.ToList(), "MaTieuChi", "TenTieuChi");
      TempData["Error"] = "Có lỗi khi thêm hoạt động. Vui lòng kiểm tra lại.";

      return RedirectToAction(nameof(Index));
   }


}
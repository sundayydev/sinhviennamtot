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

   public async Task<IActionResult> Index(int? maTieuChi, string? maSinhVien)
   {
      var username = HttpContext.Session.GetString("Username");

      if (maSinhVien == null)
      {
         maSinhVien = username;
      }

      var query = _context.ThamGiaHoatDongs
         .Include(h => h.SinhVien)
         .Include(h => h.TieuChi)
         .Where(h => h.MaSinhVien == maSinhVien);

      if (maTieuChi.HasValue)
      {
         query = query.Where(h => h.MaTieuChi == maTieuChi);
      }

      var danhSachThamGia = await query.ToListAsync();

      if (!danhSachThamGia.Any())
      {
         TempData["Error"] = "Không có dữ liệu tham gia hoạt động!";
      }

      return View(danhSachThamGia);
   }

   public IActionResult Create()
   {
      ViewBag.TieuChiList = new SelectList(_context.TieuChis.ToList(), "MaTieuChi", "TenTieuChi");
      return View();
   }

   [HttpPost]
   public IActionResult Create(ThamGiaHoatDong hoatDong)
   {
      var username = HttpContext.Session.GetString("Username");
      if (string.IsNullOrEmpty(username))
      {
         TempData["Error"] = "Vui lòng đăng nhập để thêm hoạt động.";
         return RedirectToAction("Login", "Account");
      }

      hoatDong.MaSinhVien = username;

      // Kiểm tra tiêu chí này đã thêm vào tiêu chí sinh viên chưa
      if(!_context.TieuChiSinhViens.Any(tc => tc.MaSinhVien == hoatDong.MaSinhVien && tc.MaTieuChi == hoatDong.MaTieuChi))
      {
         _context.TieuChiSinhViens.Add(new TieuChiSinhVien
         {
            MaSinhVien = hoatDong.MaSinhVien,
            MaTieuChi = hoatDong.MaTieuChi
         });
         _context.SaveChanges();
      }

      _context.ThamGiaHoatDongs.Add(hoatDong);
      _context.SaveChanges();
      TempData["Success"] = "Thêm hoạt động thành công!";


      ViewBag.TieuChiList = new SelectList(_context.TieuChis.ToList(), "MaTieuChi", "TenTieuChi");
      TempData["Error"] = "Có lỗi khi thêm hoạt động. Vui lòng kiểm tra lại.";

      return RedirectToAction(nameof(Index));
   }
}
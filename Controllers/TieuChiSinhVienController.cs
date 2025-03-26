using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSDLNC_QuanLySVNamTot.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSDLNC_QuanLySVNamTot.Controllers;

public class TieuChiSinhVienController : Controller
{
   private readonly AppDBContext _context;

   public TieuChiSinhVienController(AppDBContext context)
   {
      _context = context;
   }

   public IActionResult Index()
   {
      return View();
   }

   public IActionResult Create()
   {
      ViewBag.TieuChi = new SelectList(_context.TieuChis, "MaTieuChi", "TenTieuChi");
      return View();
   }

   [HttpPost]
   public async Task<IActionResult> Create(TieuChiSinhVien tieuChiSinhVien)
   {
      ViewBag.TieuChi = new SelectList(_context.TieuChis, "MaTieuChi", "TenTieuChi");
      await _context.TieuChiSinhViens.AddAsync(tieuChiSinhVien);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
   }

   public IActionResult Details()
   {
      return View();
   }

   public IActionResult Edit()
   {
      return View();
   }


}
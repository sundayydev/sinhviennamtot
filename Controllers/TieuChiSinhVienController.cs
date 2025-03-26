using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSDLNC_QuanLySVNamTot.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CSDLNC_QuanLySVNamTot.Controllers;

public class TieuChiSinhVienController : Controller
{
   private readonly AppDBContext _context;

   public TieuChiSinhVienController(AppDBContext context)
   {
      _context = context;
   }

  
    public IActionResult Index(string maSinhVien)
    {
        if (string.IsNullOrEmpty(maSinhVien))
        {
            return BadRequest("Mã sinh viên không h?p l?.");
        }

        // Debug: In ra mã sinh viên ?? ki?m tra
        Console.WriteLine("Mã sinh viên nh?n ???c: " + maSinhVien);

        var danhGiaSinhVien = _context.TieuChiSinhViens
            .Where(tc => tc.MaSinhVien == maSinhVien)
            .Include(tc => tc.TieuChi)
            .Include(tc => tc.SinhVien)
            .ToList();

        // Debug: Ki?m tra s? l??ng d? li?u tr? v?
        Console.WriteLine("S? b?n ghi tìm th?y: " + danhGiaSinhVien.Count);

        if (!danhGiaSinhVien.Any())
        {
            return NotFound("Không tìm th?y tiêu chí ?ánh giá cho sinh viên này.");
        }

        TempData["MaSinhVien"] = maSinhVien;
        return View(danhGiaSinhVien);
    }

    public IActionResult Duyet(string maSinhVien)
    {
        var danhGiaSinhVien = _context.TieuChiSinhViens
            .Where(tc => tc.MaSinhVien == maSinhVien)
            .Include(tc => tc.TieuChi)
            .Include(tc => tc.SinhVien)
            .ToList();

        if (!danhGiaSinhVien.Any())
        {
            return NotFound("Không tìm th?y ?ánh giá cho sinh viên này.");
        }

        return View(danhGiaSinhVien);
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

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var danhGia = _context.TieuChiSinhViens
            .Include(tc => tc.TieuChi)
            .Include(tc => tc.SinhVien)
            .FirstOrDefault(tc => tc.MaDanhGia == id);

        if (danhGia == null)
        {
            return NotFound("Không tìm th?y ?ánh giá.");
        }

        ViewBag.TieuChi = new SelectList(_context.TieuChis, "MaTieuChi", "TenTieuChi", danhGia.MaTieuChi);
        return View(danhGia);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TieuChiSinhVien tieuChiSinhVien)
    {
        if (id != tieuChiSinhVien.MaDanhGia)
        {
            return BadRequest("D? li?u không h?p l?.");
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(tieuChiSinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { maSinhVien = tieuChiSinhVien.MaSinhVien });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TieuChiSinhViens.Any(tc => tc.MaDanhGia == id))
                {
                    return NotFound("Không tìm th?y ?ánh giá.");
                }
                else
                {
                    throw;
                }
            }
        }
        ViewBag.TieuChi = new SelectList(_context.TieuChis, "MaTieuChi", "TenTieuChi", tieuChiSinhVien.MaTieuChi);
        return View(tieuChiSinhVien);
    }



}




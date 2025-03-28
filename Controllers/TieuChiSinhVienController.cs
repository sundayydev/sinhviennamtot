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
            ViewBag.Message = "Mã sinh viên không hợp lệ.";
        }

        var danhGiaSinhVien = _context.TieuChiSinhViens
            .Where(tc => tc.MaSinhVien == maSinhVien)
            .Include(tc => tc.TieuChi)
            .Include(tc => tc.SinhVien)
            .ToList();

        if (!danhGiaSinhVien.Any())
        {
            ViewBag.Message =  "Không tìm thấy đánh giá cho sinh viên này.";
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
            return NotFound("Kh�ng t�m th?y ?�nh gi� cho sinh vi�n n�y.");
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
            return NotFound("Kh�ng t�m th?y ?�nh gi�.");
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
            return BadRequest("D? li?u kh�ng h?p l?.");
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
                    return NotFound("Kh�ng t�m th?y ?�nh gi�.");
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




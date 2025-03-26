using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSDLNC_QuanLySVNamTot.Models;
using Microsoft.EntityFrameworkCore;

namespace CSDLNC_QuanLySVNamTot.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDBContext _context;

    public HomeController(ILogger<HomeController> logger, AppDBContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CheckStudent(string MaSV)
    {
        if (string.IsNullOrEmpty(MaSV))
        {
            TempData["ErrorMessage"] = "Vui lòng nh?p mã sinh viên!";
            return RedirectToAction("Index");
        }

        // Ki?m tra xem có sinh viên nào có mã MaSV không
        var sinhVien = await _context.SinhViens
            .Where(sv => sv.MaSV == MaSV)  // ?úng v?i tên thu?c tính trong model
            .FirstOrDefaultAsync();

        if (sinhVien == null)
        {
            TempData["ErrorMessage"] = "Không tìm th?y sinh viên!";
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index", "KetQua", new { maSinhVien = MaSV });
    }


}



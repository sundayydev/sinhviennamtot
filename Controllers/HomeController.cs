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
            TempData["ErrorMessage"] = "Vui l�ng nh?p m� sinh vi�n!";
            return RedirectToAction("Index");
        }

        // Ki?m tra xem c� sinh vi�n n�o c� m� MaSV kh�ng
        var sinhVien = await _context.SinhViens
            .Where(sv => sv.MaSV == MaSV)  // ?�ng v?i t�n thu?c t�nh trong model
            .FirstOrDefaultAsync();

        if (sinhVien == null)
        {
            TempData["ErrorMessage"] = "Kh�ng t�m th?y sinh vi�n!";
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index", "KetQua", new { maSinhVien = MaSV });
    }


}



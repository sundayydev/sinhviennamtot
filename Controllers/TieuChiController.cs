using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSDLNC_QuanLySVNamTot.Models;

namespace CSDLNC_QuanLySVNamTot.Controllers;

public class TieuChiController : Controller
{
private readonly AppDBContext _context;

   public TieuChiController(AppDBContext context)
   {
      _context = context;
   }

   public IActionResult Index()
   {
      return View();
   }

   public IActionResult ThongTinTieuChi()
   {
      var listTieuChi = _context.TieuChis.ToList();
      return View(listTieuChi);
   }

   public IActionResult Create()
   {
      return View();
   }
}

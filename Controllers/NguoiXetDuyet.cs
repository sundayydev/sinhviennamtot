using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSDLNC_QuanLySVNamTot.Models;

namespace CSDLNC_QuanLySVNamTot.Controllers;

public class NguoiXetDuyetController : Controller
{
   private readonly AppDBContext _context;

   public NguoiXetDuyetController(AppDBContext context)
   {
      _context = context;
   }

   public IActionResult Index()
   {
      return View();
   }

   

}
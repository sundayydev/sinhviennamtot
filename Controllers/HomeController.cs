using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSDLNC_QuanLySVNamTot.Models;

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

    
}

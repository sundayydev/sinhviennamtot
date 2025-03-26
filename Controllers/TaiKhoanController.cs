using System.Security.Claims;
using CSDLNC_QuanLySVNamTot.Models;
using CSDLNC_QuanLySVNamTot.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSDLNC_QuanLySVNamTot.Controllers
{
    public class TaiKhoanController : Controller
    {

        private readonly AppDBContext _context;

        public TaiKhoanController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.TaiKhoans.ToList());
        }

        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangNhap(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var taiKhoan = _context.TaiKhoans
                    .SingleOrDefault(tk => tk.TenDangNhap == model.TenDangNhap && tk.MatKhau == model.MatKhau);
                if (taiKhoan != null)
                {
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, taiKhoan.TenDangNhap),
                        new Claim(ClaimTypes.Role, taiKhoan.LoaiTaiKhoan)
                    };

                    var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("SecurePage", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
                }
            }
            return View(model);
        }

        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    TenDangNhap = model.TenDangNhap,
                    MatKhau = model.MatKhau,
                    LoaiTaiKhoan = model.LoaiTaiKhoan
                }; 
                _context.TaiKhoans.Add(taiKhoan);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = "Đăng ký tài khoản thành công!";

                return View();
            }    
            return View(model);
        }

        public IActionResult QuenMatKhau()
        {
            return View();
        }

        public IActionResult DangXuat()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "User")]
        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}

using CSDLNC_QuanLySVNamTot.Models;
using CSDLNC_QuanLySVNamTot.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSDLNC_QuanLySVNamTot.Controllers
{
   public class AuthController : Controller
   {
      private readonly AppDBContext _context;

      public AuthController(AppDBContext context)
      {
         _context = context;
      }

      // Hiển thị trang đăng ký
      [HttpGet]
      public IActionResult Register()
      {
         return View();
      }

      // Xử lý đăng ký
      [HttpPost]
      public async Task<IActionResult> Register(RegisterViewModel model)
      {
         if (!ModelState.IsValid)
            return View(model);

         if (await _context.TaiKhoans.AnyAsync(a => a.TenDangNhap == model.TenDangNhap))
         {
               ModelState.AddModelError("", "Username đã tồn tại!");
               return View(model);
         }

         // Mã hóa mật khẩu
         string hashedPassword = HashPassword(model.MatKhau);

         var account = new TaiKhoan
         {
               TenDangNhap = model.TenDangNhap,
               MatKhau = hashedPassword,
               LoaiTaiKhoan = model.LoaiTaiKhoan
         };

         _context.TaiKhoans.Add(account);
         await _context.SaveChangesAsync();

         return RedirectToAction("Login");
      }

      // Hiển thị trang đăng nhập
      [HttpGet]
      public IActionResult Login()
      {
         return View();
      }

      // Xử lý đăng nhập
      [HttpPost]
      public async Task<IActionResult> Login(LoginViewModel model)
      {
         if (!ModelState.IsValid)
               return View(model);

         var account = await _context.TaiKhoans.FirstOrDefaultAsync(a => a.TenDangNhap == model.TenDangNhap);
         if (account == null || !VerifyPassword(model.MatKhau, account.MatKhau))
         {
               ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu!");
               return View(model);
         }

         // Lưu thông tin đăng nhập vào Session
         HttpContext.Session.SetString("Username", account.TenDangNhap);
         HttpContext.Session.SetString("Role", account.LoaiTaiKhoan);

         if(account.LoaiTaiKhoan == "Admin")
            return RedirectToAction("Index", "Admin");
         else if (account.LoaiTaiKhoan == "NguoiXetDuyet")
            return RedirectToAction("Index", "NguoiXetDuyet");

         return RedirectToAction("Index", "Home");
      }

      // Đăng xuất
      public IActionResult Logout()
      {
         HttpContext.Session.Clear();
         return RedirectToAction("Login");
      }

      // Hàm băm mật khẩu
      private string HashPassword(string password)
      {
         using (SHA256 sha256 = SHA256.Create())
         {
               byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
               return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
         }
      }

      // Kiểm tra mật khẩu
      private bool VerifyPassword(string inputPassword, string storedPassword)
      {
         return HashPassword(inputPassword) == storedPassword;
      }
   }
}

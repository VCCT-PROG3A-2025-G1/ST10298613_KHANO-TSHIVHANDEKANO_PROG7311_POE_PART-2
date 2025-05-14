using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_PART_2.Models;
using PROG7311_POE_PART_2.Services;

namespace PROG7311_POE_PART_2.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _authService.LoginAsync(username, password);
            if (user == null)
            {
                ViewBag.Error = "Invalid username or password.";
                return View();
            }

            // Store user data in session
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);
            HttpContext.Session.SetInt32("UserId", user.Id);

            // Redirect based on role
            return user.Role switch
            {
                "Farmer" => RedirectToAction("Dashboard", "Product"),
                "Employee" => RedirectToAction("Dashboard", "Farmer"),
                _ => RedirectToAction("Login")
            };
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}


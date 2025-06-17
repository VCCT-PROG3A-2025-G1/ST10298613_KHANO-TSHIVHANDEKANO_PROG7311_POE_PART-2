using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_PART_2.Models;
using PROG7311_POE_PART_2.Services;

namespace PROG7311_POE_PART_2.Controllers
{
    public class FarmerController : Controller
    {
        private readonly FarmerService _farmerService;

        public FarmerController(FarmerService farmerService)
        {
            _farmerService = farmerService;
        }

        // Shows all farmers (Employee dashboard)
        public async Task<IActionResult> Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Employee")
                return RedirectToAction("Login", "Auth");

            var farmers = await _farmerService.GetAllFarmersAsync();
            return View(farmers);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Employee")
                return RedirectToAction("Login", "Auth");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Farmer farmer)
        {
            if (HttpContext.Session.GetString("Role") != "Employee")
                return RedirectToAction("Login", "Auth");

            if (!ModelState.IsValid) return View(farmer);

            await _farmerService.AddFarmerAsync(farmer);
            return RedirectToAction("Dashboard");
        }
    }
}



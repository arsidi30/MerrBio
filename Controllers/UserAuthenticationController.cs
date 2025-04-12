using Microsoft.AspNetCore.Mvc;
using FarmIt.Models.DTO;
using FarmIt.Respositories.Abstract;

namespace FarmIt.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
         /*public async  Task<IActionResult> Register()
         {
             var model = new Registration
             {
                 Email = "skullred005@gmail.com",
                 Username = "Admin",
                 Name = "Arsid",
                 Password = "Admin@123",
                 PasswordConfirmation = "Admin@123",
                 Role = "Admin",
             };
            var result = await authService.RegisterAsync(model);
             return Ok(result.Message);
         } */
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }
            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                TempData["msg"] = "Couldn't LogIn..";
                return RedirectToAction(nameof(Login)); 
            }
            
        }
        public async Task<IActionResult> Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Registration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await authService.RegisterAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Couldn't Register..";
                return RedirectToAction(nameof(Registration));
            }

        }

        public async Task<IActionResult> Logout()
        {
           await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

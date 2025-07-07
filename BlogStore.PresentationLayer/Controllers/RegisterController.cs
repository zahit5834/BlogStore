using BlogStore.EntityLayer.Entities;
using BlogStore.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterViewModel userRegisterViewModel)
        {
            AppUser appUser = new AppUser()
            {
                ImageUrl = "test",
                Description = "test",
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                Email = userRegisterViewModel.Email,
                UserName = userRegisterViewModel.UserName
            };
            await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
            return RedirectToAction("UserLogin", "Login");
        }

    }
}

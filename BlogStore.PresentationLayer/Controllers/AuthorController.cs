using BlogStore.BusinessLayer.Abstract;
using BlogStore.EntityLayer.Entities;
using BlogStore.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogStore.PresentationLayer.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public AuthorController(IArticleService articleService, ICategoryService categoryService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = userProfile.Name;
            ViewBag.surname = userProfile.Surname;
            ViewBag.id = userProfile.Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetProfile(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user); // Kullanıcının oturumunu güncelle
                ViewBag.Message = "Şifreniz başarıyla değiştirildi.";
                return View();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);

            article.Slug = SlugHelper.GenerateSlug(article.Title);
            article.AppUserId = userProfile.Id;
            article.CreatedDate = DateTime.Now;

            _articleService.TInsert(article);
            return RedirectToAction("Index","Default");
        }
        public async Task<IActionResult> MyArticles()
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUSer(userProfile.Id);
            return View(values);
        }
    }
}
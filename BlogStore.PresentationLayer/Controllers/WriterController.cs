using BlogStore.BusinessLayer.Concrete;
using BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.Controllers
{
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ArticleManager _articleManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult WriterList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        public IActionResult WriterArticleList(string id)
        {
            var values = _articleManager.TGetArticlesByAppUSer(id);
            return View(values);
        }
    }
}

using BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICategoryService _categoryService;

        public DashboardController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetBlogCategoryCounts()
        {
            var values = _categoryService.TGetCategoryWithArticleCount();

            var result = values.Select(x => new
            {
                categoryName = x.CategoryName,
                blogCount = x.ArticleCount
            }).ToList();

            return Json(result);
        }

    }
}

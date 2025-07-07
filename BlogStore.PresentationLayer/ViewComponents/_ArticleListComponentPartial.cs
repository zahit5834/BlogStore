using BlogStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.ViewComponents
{
    public class _ArticleListComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int? id)
        {
            var value =id.HasValue
                ? _articleService.TGetArticlesByCategoryId(id.Value)
                : _articleService.TGetArticlesWithCategories();
            return View(value);
        }
    }
}

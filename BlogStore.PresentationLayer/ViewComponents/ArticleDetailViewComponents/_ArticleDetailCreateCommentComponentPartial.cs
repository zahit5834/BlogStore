using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailCreateCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            return View();
        }
    }
}

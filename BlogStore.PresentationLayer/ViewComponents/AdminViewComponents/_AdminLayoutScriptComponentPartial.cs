using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.ViewComponents.AdminViewComponents
{
    public class _AdminLayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

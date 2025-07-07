using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index(int? id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}

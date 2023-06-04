using Microsoft.AspNetCore.Mvc;

namespace Traversal.MVC.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

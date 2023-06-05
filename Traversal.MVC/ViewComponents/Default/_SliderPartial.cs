using Microsoft.AspNetCore.Mvc;

namespace Traversal.MVC.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        { 
            return View(); 
        }

    }
}

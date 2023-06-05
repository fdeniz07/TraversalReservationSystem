using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccess.Concrete.EntityFramework;

namespace Traversal.MVC.ViewComponents.Default
{
    public class _PopularDestinationsPartial : ViewComponent
    {

        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());


        public IViewComponentResult Invoke()
        {
            var values = destinationManager.GetAll();
            return View(values);  
        }
    }
}

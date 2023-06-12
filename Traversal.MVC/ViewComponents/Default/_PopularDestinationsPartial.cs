using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccess.Concrete.EntityFramework;

namespace Traversal.MVC.ViewComponents.Default
{
    public class _PopularDestinationsPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _PopularDestinationsPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        //DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = _destinationService.GetAll();
            return View(values);
        }
    }
}

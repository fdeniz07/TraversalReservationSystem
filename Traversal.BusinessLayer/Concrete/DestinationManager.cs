using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccess.Abstract;
using Traversal.Entity.Concrete;

namespace Traversal.BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {

        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public List<Destination> GetAll()
        {
            return _destinationDal.GetAll();
        }

        public void TAdd(Destination entity)
        {
            _destinationDal.Insert(entity);
        }

        public void TDelete(Destination entity)
        {
            _destinationDal.Delete(entity);
        }

        public Destination TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Destination entity)
        {
           _destinationDal.Update(entity);
        }
    }
}

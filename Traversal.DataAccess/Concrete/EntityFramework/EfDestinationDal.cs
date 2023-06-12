using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.DataAccess.Contexts;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination, BaseDbContext>, IDestinationDal
    {
        public EfDestinationDal(BaseDbContext context) : base(context)
        {
        }
    }
}

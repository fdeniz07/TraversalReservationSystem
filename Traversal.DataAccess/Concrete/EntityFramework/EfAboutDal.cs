using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.DataAccess.Contexts;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfAboutDal : GenericRepository<About, BaseDbContext>, IAboutDal
    {
        public EfAboutDal(BaseDbContext context) : base(context)
        {
        }
    }
}

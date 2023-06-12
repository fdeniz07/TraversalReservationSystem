using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.DataAccess.Contexts;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfSubAboutDal : GenericRepository<SubAbout, BaseDbContext>, ISubAboutDal
    {
        public EfSubAboutDal(BaseDbContext context) : base(context)
        {
        }
    }
}

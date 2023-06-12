using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.DataAccess.Contexts;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfAbout2Dal : GenericRepository<About2, BaseDbContext>, IAbout2Dal
    {
        public EfAbout2Dal(BaseDbContext context) : base(context)
        {
        }
    }
}

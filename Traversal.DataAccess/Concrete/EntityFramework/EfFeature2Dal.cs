using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.DataAccess.Contexts;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfFeature2Dal : GenericRepository<Feature2, BaseDbContext>, IFeature2Dal
    {
        public EfFeature2Dal(BaseDbContext context) : base(context)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public EfFeatureDal(DbContext context) : base(context)
        {
        }
    }
}

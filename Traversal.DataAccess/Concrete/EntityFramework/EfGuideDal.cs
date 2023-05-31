using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public EfGuideDal(DbContext context) : base(context)
        {
        }
    }
}

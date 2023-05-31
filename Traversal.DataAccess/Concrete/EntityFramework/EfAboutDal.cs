using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(DbContext context) : base(context)
        {
        }
    }
}

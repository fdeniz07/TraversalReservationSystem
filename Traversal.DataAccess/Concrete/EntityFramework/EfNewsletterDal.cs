using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfNewsletterDal : GenericRepository<Newsletter>, INewsletterDal
    {
        public EfNewsletterDal(DbContext context) : base(context)
        {
        }
    }
}

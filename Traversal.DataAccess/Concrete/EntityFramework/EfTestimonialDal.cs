using Microsoft.EntityFrameworkCore;
using Traversal.CoreLayer.DataAccess.Concrete;
using Traversal.DataAccess.Abstract;
using Traversal.DataAccess.Contexts;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Concrete.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial, BaseDbContext>, ITestimonialDal
    {
        public EfTestimonialDal(BaseDbContext context) : base(context)
        {
        }
    }
}

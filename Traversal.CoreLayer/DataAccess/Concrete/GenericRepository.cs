using Traversal.CoreLayer.DataAccess.Abstract;

namespace Traversal.CoreLayer.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //private readonly Context _context;


        //public void Add(T entity)
        //{
        //    _context.Add(entity);
        //    _context.SaveChanges();
        //}

        //public void Delete(T entity)
        //{
        //    _context.Remove(entity);
        //    _context.SaveChanges();
        //}

        //public List<T> GetAll()
        //{
        //    return _context.Set<T>().ToList();
        //}

        //public void Update(T entity)
        //{
        //    _context.Update(entity);
        //}
        public void Add(T entity)
        {
          // using var c = Context()
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
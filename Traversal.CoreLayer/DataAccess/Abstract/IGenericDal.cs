namespace Traversal.CoreLayer.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetAll();
    }
}

using Traversal.CoreLayer.DataAccess.Abstract;
using Traversal.Entity.Concrete;

namespace Traversal.DataAccess.Abstract
{
    public interface IGuideDal : IGenericDal<Guide>
    {
        //Eger generic repository kullanamasaydik, tüm entity ile ilgili interface'lere asagidaki gibi metotlar yazmamiz gerekecekti.
        //void Insert(Guide guide);
        //void Update(Guide guide);
        //void Delete(Guide guide);
        //List<Guide> GetList(); 
    }
}

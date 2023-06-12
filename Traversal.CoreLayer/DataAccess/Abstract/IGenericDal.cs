using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Traversal.CoreLayer.Entity.Abstract;

namespace Traversal.CoreLayer.DataAccess.Abstract
{
    public interface IGenericDal<TEntity> where TEntity : class, IEntity
    {
        //Buraya yazdigimiz metotlar, tüm entitlerde ortak kullanmak istedigimiz metodlardir.

        #region Insert Metotlari

        // Insert Metotlari \\
        void Add(TEntity entity); //Geri dönüssüz
        TEntity Add2(TEntity entity); //Geri Dönüslü
        Task<TEntity> AddAsync(TEntity entity); //Tekil ekleme - asenkron 
        Task AddRangeAsync(IEnumerable<TEntity> entities);  //Coklu Ekleme - asenkron

        #endregion

        #region Update Metotlari

        // Update Metotlari \\
        void Update(TEntity entity); // --> Default senkron
        TEntity Update2(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);// Biz burada asenkron olarak ayarlayacagiz

        #endregion

        #region Delete Metotlari

        // Delete Metotlari \\
        void Delete(TEntity entity); //-->Default senkron --> Silme islemi EntityFramework de senkron olarak yapilir.
        Task DeleteAsync(TEntity entity); // Biz burada asenkron olarak ayarlayacagiz
        void DeleteRange(IEnumerable<TEntity> entities);

        #endregion

        #region Get Metotlari

        // Get Metotlari \\
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

        //Biz burada cok dinamik bir yapi kuruyoruz. Kullanicinin bilgilerini giriyoruz(filtreden gelen deger),
        //kullanicinin diger bilgilerini cagirmak icinde includProperties kullaniliyoruz, params anahtari ile birden fazla includeproperties getirtip dizeye atiyoruz 
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetAsyncV2(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includeProperties); //if(isActive==true) predicates.Add();
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> GetAsQueryable(); // Iqueryable olarak verilen enitity'i, bizlere return eder. Bu sayede bizler, herhangi bir sinir olmadan kompleks sorgular olusturabiliyoruz. Farzedelim, GetAsync icerisinde kategoriyi alirken,onun makalelerini include etmek istiyoruz ve makale icerisindeki yorumlari da onun sonrasinda ThenInclude ile include etmek istiyoruz. Burada komplex bir sorgu ile karsilasiyoruz. Bunu normal metotlarimiz icerisinde tamamlayamiyoruz.

        #endregion

        #region GetAll Metotlari

        // GetAll Metotlari \\
        List<TEntity> GetAll();
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<IList<TEntity>> GetAllAsyncV2(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includeProperties);

        //Biz burada tüm makaleleri(null) de görmek isteyebiliriz ya da bir kategorideki bir makaleyi(filtreye göre) de görmek isteyebiliriz
        //Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

        #endregion

        #region SaveChanges Metotlari

        // SaveChanges Metotlari \\

        int SaveChanges();
        Task<int> SaveChangesAsync();

        #endregion

        #region Count Metotlari

        // Count Metotlari \\

        int GetCount(Expression<Func<TEntity, bool>> expression = null);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        //Tüm entity lerin sayisini dönmek icin de Count kullaniyoruz (var commentCount = _commentRepository.CountAsync()), olurda tablodaki bilgileri dönmek istersek, predicate alanina varsayilan deger olarak null atiyoruz.

        #endregion

        #region Search Metotlari

        // Search Metotlari \\

        IQueryable<TEntity> Query();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate); // predicate = Lambda
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); // category.SingleOrDefaultAsync(x=>x.name = "teknoloji")
        Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties); //Ayni anda birden fazla arama kriteri istenilebilir. Aradigimiz makalelerin, kategori,yorum,kullanicilari ile gelmelerini isteyecegimizden params kullaniyoruz.
                                                                                                                                                           //var result = _userRepository.AnyAsync(u=>u.UserName == "Admin"); --> Admin isimli bir kullanici var mi
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate); //Böyle bir entity daha önceden var mi diye kontrol ediyoruz 

        #endregion

        #region Diger Metotlar

        // Diger Metotlar \\
        Task<int> Execute(FormattableString interpolatedQueryString);
        TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null);
        #endregion

    }
}

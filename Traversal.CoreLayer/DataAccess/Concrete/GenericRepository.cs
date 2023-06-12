using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Traversal.CoreLayer.DataAccess.Abstract;
using Traversal.CoreLayer.Entity.Abstract;

namespace Traversal.CoreLayer.DataAccess.Concrete
{
    public class GenericRepository<TEntity, TContext> : IGenericDal<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {

        protected TContext _context { get; }
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        #region Insert Metotlari

        // Insert Metotlari \\

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public TEntity Add2(TEntity entity)
        {
            return _context.Add(entity).Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        #endregion

        #region Update Metotlari

        // Update Metotlari \\

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public TEntity Update2(TEntity entity)
        {
            _context.Update(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            //_context.Entry(entity).State = EntityState.Modified; // Burasi(EntityState.Modified;) cok sütunlü tablolarda kullanmakta cok kullanisli olur.
            // Tek dezavantaji, bir alan bile degisse tüm entity alanlarini güncellemeye calisir

            //entity.name = product.name
            //entity.price = product.price ile yukaridaki performans sorunu azaltilabilir ama cok satira sahip tablolarda ölümcül olabilir.

            //Update islemleri asenkron islemler degildir. Eger asenkron yapilmak istenirse, bizim tarafimizca yeni bir Task olusturulup, icerisine anonim bir metot yazilmalidir.

            await Task.Run(() => { _dbSet.Update(entity); }); //--> olmalidir.

            return entity;
        }

        #endregion

        #region Delete Metotlari

        //Delete Metotlari \\

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            //_dbSet.Remove(entity);

            //Remove / Delete islemleri asenkron islemler degildir. Eger asenkron yapilmak istenirse, bizim tarafimizca yeni bir Task olusturulup, icerisine anonim bir metot yazilmalidir.
            await Task.Run(() => { _dbSet.Remove(entity); });
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        #endregion

        #region Get Metotlari

        // Get Metotlari \\
        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AsQueryable().FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetAsyncV2(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (predicates != null && predicates.Any()) //buraya yanlislikla bos bir liste gönderme ihtimalimiz var. O yüzden null olma durumunu ve listenin icerisinde verinin varligini kontrol ediyoruz
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate); // isActive==false && isDeleted==true gelebilir
                }
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return _dbSet.AsQueryable(); // UnitOfWork.Blog.GetAsQueryable(); dedigimizde bize blog nesnesini bir Querable nesnesi olarak return ediyor.
        }

        #endregion

        #region GetAll Metotlari

        // GetAll Metotlari \\
        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? _dbSet.AsNoTracking() : _dbSet.Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? await _dbSet.ToListAsync() : await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any()) //bu dizinin icerisinde bir deger varsa, icerisinde döngü ile dönecegiz
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().ToListAsync(); //yukarida dönen degerleri kullanicaya bir liste olarak dönecegiz.
        }

        public async Task<IList<TEntity>> GetAllAsyncV2(IList<Expression<Func<TEntity, bool>>> predicates, IList<Expression<Func<TEntity, object>>> includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (predicates != null && predicates.Any()) //buraya yanlislikla bos bir liste gönderme ihtimalimiz var. O yüzden null olma durumunu ve listenin icerisinde verinin varligini kontrol ediyoruz
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate); // isActive==false && isDeleted==true gelebilir
                }
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }

        #endregion

        #region SaveChanges Metotlari

        // SaveChanges Metotlari \\
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Count Metotlari

        // Count Metotlari \\
        public int GetCount(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? _dbSet.Count() : _dbSet.Count(expression);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
            {
                return await _dbSet.CountAsync();
            }
            else
            {
                return await _dbSet.CountAsync(expression);
            }
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await (predicate == null ? _dbSet.CountAsync() : _dbSet.CountAsync(predicate)); //predicate null gelirse, o zaman context e set edilmis olan tenitity nin countasync tamamiyle dönüyoruz. Null gelmezse, gelen predicate degeri filtreleme yaparak kullaniciya dönecegiz. Örnek: Kategori tablosunda 6 kayit varsa, toplam 6 degerini predicatesiz olarak dönecegiz. Fakat olur da silinmis kategorileri görmek istersek ve tablomuzda 3 kategori silinmisse; o zaman predicate ile toplam 3 kategori degerini kullaniciya dönüyoruz. Esnek bir yapi kurmus oluyoruz
        }

        #endregion

        #region Search Metotlari

        // Search Metotlari \\
        public IQueryable<TEntity> Query()
        {
            return _dbSet;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task<IList<TEntity>> SearchAsync(IList<Expression<Func<TEntity, bool>>> predicates, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (predicates.Any())
            {
                var predicateChain = PredicateBuilder.New<TEntity>();
                foreach (var predicate in predicates)
                {
                    //query.Where(predicate) predicate1 && predicate2 && predicate3 && predicateN ve operatörü ile calisir. Bize veya ile ilgili detayli sorgulama islemleri gerektigi icin bir nugetpaket kurmamiz gerekiyor.LinqKit.Microsoft.EntityFrameworkCore isimli paketi kuruyoruz.
                    //query = query.Where(predicate);

                    //predicateChain.Or(predicate) predicate1 || predicate2 || predicate3 || predicateN
                    predicateChain.Or(predicate);
                }

                query = query.Where(predicateChain);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync(); //AsNoTracking metodu bizim icin gereksiz include islemlerini önler veya sadece bizim istedigimiz include ler varsa getirir. Bu sayede gereksiz yere ayni islemler,birbirini tekrar eden islemler (Blog -> Kategori -> Makale -> Yorum -> Blog) gerceklesmeyecegi icin epey bir performans saglamis olacagiz.
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        #endregion

        #region Diger Metotlar

        // Diger Metotlar \\
        public Task<int> Execute(FormattableString interpolatedQueryString)
        {
            throw new NotImplementedException();
        }

        public TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null)
        {
            var result = default(TResult);
            try
            {
                if (_context.Database.ProviderName.EndsWith("InMemory"))
                {
                    result = action();
                    SaveChanges();
                }
                else
                {
                    using (var tx = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            result = action();
                            SaveChanges();
                            tx.Commit();
                        }
                        catch (Exception)
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                successAction?.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionAction == null)
                {
                    throw;
                }

                exceptionAction(ex);
            }
            return result;
        }

        #endregion

    }
}
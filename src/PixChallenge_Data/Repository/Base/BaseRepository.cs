using Microsoft.EntityFrameworkCore;
using PixChallenge_Core.Interfaces.Base;
using PixChallenge_Data.Context;
using System.Linq.Expressions;

namespace PixChallenge_Data.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly PixChallengeContext _context;

        protected DbSet<T> DbSet
        {
            get { return _context.Set<T>(); }
        }

        public BaseRepository(PixChallengeContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T model)
        {
            try
            {
                await DbSet.AddAsync(model);
                await SaveAsync();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = DbSet;
                if (includes.Length > 0)
                    foreach (var item in includes)
                        query = query.Include(item);
                return await query.AsNoTracking().FirstOrDefaultAsync(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            try
            {
                return await DbSet.AsNoTracking().FirstOrDefaultAsync(where);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = DbSet;

                if (includes.Length > 0)
                    foreach (var item in includes)
                        query = query.Include(item);

                return query.Where(predicate).AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

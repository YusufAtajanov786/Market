using Market.Data.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        internal DbSet<T> dbSet;

        public GenericRepository(
            AppDbContext appDbContext
            )
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            dbSet = appDbContext.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }     

        public async Task<bool> Delete(Guid id, string userId)
        {
            var obj = await dbSet.FindAsync(id);
            if (obj == null)
            {
                return false;
            }
            dbSet.Remove(obj);
            return true;
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual  Task<bool> Upsert(T entity)
        {
          throw new NotImplementedException();
            
        }

        public async Task CompleteAsync()
        {
           await _appDbContext.SaveChangesAsync();
        }
    }
}

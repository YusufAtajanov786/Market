using Market.Data.Data.IRepository;
using Market.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Data
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext):base(appDbContext)
        {

        }
        public async Task<Category> GetCategoryById(Guid id)
        {
            var category = await dbSet.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
                return null;
            return category;
        }

        public override async Task<bool> Upsert(Category entity)
        {
            var category = await dbSet.FindAsync(entity.Id);
            if (category == null)
            {
                return false;
            }
            category.Name = entity.Name;
            return true;
        }


    }
}

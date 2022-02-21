using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Data.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryById(Guid id); 
    }
}

using Market.ViewModel;
using Market.ViewModel.Incoming.CategoryController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markek.Service.Services.IService
{
    public interface ICategoryService
    {
        Task<CategoryVIewModel> GetCategoryById(Guid id);

        Task<CategoryVIewModel> PostCategory(PostCategoryVM postCategoryVM);

        Task<IEnumerable<CategoryVIewModel>> GetAll();

        Task<bool> DeleteCategory(Guid id);

        Task<bool> Upsert(CategoryVIewModel newcategory);
    }
}

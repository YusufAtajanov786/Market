using Markek.Service.Services.IService;
using Market.Data.Data;
using Market.Data.Data.IRepository;
using Market.Domain;
using Market.ViewModel;
using Market.ViewModel.Incoming.CategoryController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markek.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

      
        public async Task<IEnumerable<CategoryVIewModel>> GetAll()
        {
            var categories = await _categoryRepository.All();
            IEnumerable<CategoryVIewModel> ct = categories.Select(c => new CategoryVIewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
            return ct;
        }

        public async Task<CategoryVIewModel> GetCategoryById(Guid id)
        { 
            
            var category =  await _categoryRepository.GetById(id);
            if(category == null)
            {
                return null;
            }

            return (CategoryVIewModel)category;
        }

        public async Task<CategoryVIewModel> PostCategory(PostCategoryVM postCategoryVM)
        {
            Category category = new Category()
            {
                Name = postCategoryVM.Name
            };
            var result = await _categoryRepository.Add(category);
            if(result == false)
            {
                return null;
            }
             await _categoryRepository.CompleteAsync();
            return (CategoryVIewModel)category;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var result = await _categoryRepository.Delete(id, "9245fe4a-d402-451c-b9ed-9c1a04247482");
            if(result != false)
                result = false;
            await _categoryRepository.CompleteAsync();
            return result;
        }

       

        public async Task<bool> Upsert(CategoryVIewModel newcategory)
        {
            Category category = new Category()
            {
                Id = newcategory.Id,
                Name = newcategory.Name
            };
            var isUpdated = await _categoryRepository.Upsert(category);
            if (isUpdated == false)
                return false;
            await _categoryRepository.CompleteAsync();
            return true;
        }
    }
}

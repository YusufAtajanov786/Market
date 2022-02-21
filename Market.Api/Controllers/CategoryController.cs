using Markek.Service.Services.IService;
using Market.Domain;
using Market.ViewModel;
using Market.ViewModel.Generic;
using Market.ViewModel.Incoming.CategoryController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
            ICategoryService categoryService 
            )
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            var result = new PageResult<CategoryVIewModel>();
            result.Content = categories.Select(c=> new CategoryVIewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
            return Ok(result);
        }



        [HttpGet]
        [Route("{id:Guid}" , Name = "GetByid")]
        public async Task<IActionResult> GetByid([FromRoute] Guid id)
        {
            var category = await _categoryService.GetCategoryById(id);
            var result = new Result<CategoryVIewModel>()
            {
                Content = category
            };
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] PostCategoryVM postCategoryVM)
        {
            var newCategory = await _categoryService.PostCategory(postCategoryVM);
            var result = new Result<CategoryVIewModel>()
            {
                Content = newCategory
            };
            return CreatedAtRoute(nameof(GetByid), new { id = newCategory.Id }, result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
           var isDeleted =  await _categoryService.DeleteCategory(id);
            if (isDeleted)
            {
                return BadRequest();
            }
           return Ok();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put([FromBody] CategoryVIewModel categoryVIew)
        {
            var isUpdated = await _categoryService.Upsert(categoryVIew);
            if (!isUpdated)  
                return BadRequest();
            var result = new Result<CategoryVIewModel>()
            {
                Content = categoryVIew
            };
            return Ok(result);
        }
    }
}

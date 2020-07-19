using DataLayer.DTOs;
using DataLayer.Entities;
using Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface  ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<IEnumerable<Category>> GetChildrenByID(int ID);
        public Task<IEnumerable<Category>> GetCategoryByID(int ID);
        public Task<Category> AddNewCategory(CategoryDTO newCategory);
        public Task<ReqResult> UpdateCategory(int ID, CategoryUpdateDTO updateDto);

    }
}

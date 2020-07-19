using AutoMapper;
using DataLayer.Context;
using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Models.Enums;
using Models.Interfaces;

namespace Services
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private readonly ItemContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ItemContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories
                .Where(category => category.is_active == true)
                .ToListAsync<Category>();
        }

        public async Task<IEnumerable<Category>> GetChildrenByID(int ID)
        {
            return await _context.Categories
                   .Where(category => category.parent_id == ID)
                   .ToListAsync<Category>();
        }

        public async Task<IEnumerable<Category>> GetCategoryByID(int ID)
        {
            return await _context.Categories
                    .Where(category => category.category_id == ID)
                    .ToListAsync<Category>();
        }

        public async Task<Category> AddNewCategory(CategoryDTO newCategory)
        {
            var dbInsertPayload = _mapper.Map<Category>(newCategory);

            await _context.AddAsync(dbInsertPayload);
            await _context.SaveChangesAsync();

            return dbInsertPayload;

        }
        public async Task<ReqResult> UpdateCategory(int ID, CategoryUpdateDTO updateDto)
        {
            var target = await _context.Categories
                               .FirstOrDefaultAsync(category => category.category_id == ID);

            if (target == null)
            {
                return ReqResult.NotFound;
            }

            // TODO: This code is horrendous. Is there a better way?
            if (updateDto.name != null)
            {
                target.name = updateDto.name;
            }
            if (updateDto.parent_id != null)
            {
                target.parent_id = updateDto.parent_id;
            }
            if (updateDto.is_active != null)
            {
                if (target.parent_id == null && updateDto.is_active == false)
                {
                    var childrenToDeactivate = await _context.Categories
                           .Where(category => category.parent_id == target.category_id)
                           .ToListAsync<Category>();
                    foreach (var child in childrenToDeactivate)
                    {
                        child.is_active = false;
                    }
                    target.is_active = false;
                    await _context.SaveChangesAsync();
                }
            }

            await _context.SaveChangesAsync();

            return ReqResult.Success;

        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

    }
}

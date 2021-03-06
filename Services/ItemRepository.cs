﻿using AutoMapper;
using DataLayer.Context;
using DataLayer.DTOs;
using DataLayer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Models.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Services
{
    public class ItemRepository : IItemRepository, IDisposable
    {
        private readonly ItemContext _context;
        private readonly IMapper _mapper;

        public ItemRepository(ItemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(Guid itemId)
        {
            return await _context.Items
                .Where(item => item.item_id == itemId)
                .FirstOrDefaultAsync<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemByCategory(int categoryId)
        {
            return await _context.Items
                    .Where(item => item.category == categoryId)
                    .ToListAsync<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemByOwner(int ownerId)
        {
            return await _context.Items
                    .Where(item => item.item_owner == ownerId)
                    .ToListAsync<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemByStatus(int statusCode)
        {
            return await _context.Items
                   .Where(item => item.item_status == statusCode)
                   .ToListAsync<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemByCondition(int conditionCode)
        {
            return await _context.Items
                .Where(item => item.item_condition == conditionCode)
                .ToListAsync<Item>();
        }

        public async Task<ReqResult> AddNewItem(ItemDTO item)
        {
            var payload = _mapper.Map<Item>(item);
            await _context.AddAsync(payload);
            await _context.SaveChangesAsync();

            return ReqResult.Success;
        }

        public async Task<ReqResult> UpdateItem(Guid itemToPatch, [FromBody] JsonPatchDocument<Item> patchDocument)
        {
            var target = await _context.Items
                .Where(item => item.item_id == itemToPatch)
                .FirstOrDefaultAsync();
            
            if (target == null)
            {
                return ReqResult.NotFound;
            }
            patchDocument.ApplyTo(target);

            var result = new ObjectResult(target);
            return ReqResult.Success;
            
        }

        public async Task<int> GetItemCount()
        {
            return await _context.Items
                .CountAsync();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
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


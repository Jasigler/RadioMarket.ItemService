using DataLayer.DTOs;
using DataLayer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetItems();
        public Task<Item> GetItemById(Guid itemId);
        public Task<IEnumerable<Item>> GetItemByCategory(int categoryId);
        public Task<IEnumerable<Item>> GetItemByOwner(int ownerId);
        public Task<IEnumerable<Item>> GetItemByStatus(int statusCode);
        public Task<IEnumerable<Item>> GetItemByCondition(int conditionCode);
        public Task<ReqResult> AddNewItem(ItemDTO item);
        public Task<ReqResult> UpdateItem(Guid itemId, JsonPatchDocument<Item> patchDoc);
        public Task<int> GetItemCount();
    }
}

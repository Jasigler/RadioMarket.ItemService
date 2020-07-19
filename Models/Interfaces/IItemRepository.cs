using DataLayer.DTOs;
using DataLayer.Entities;
using Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetItems();
        public Task<Item> GetItemById(int itemId);
        public Task<IEnumerable<Item>> GetItemByCategory(int categoryId);
        public Task<IEnumerable<Item>> GetItemByOwner(int ownerId);
        public Task<IEnumerable<Item>> GetItemByStatus(int statusCode);
        public Task<IEnumerable<Item>> GetItemByCondition(int conditionCode);
        public Task<ReqResult> AddNewItem(ItemDTO item);
    }
}

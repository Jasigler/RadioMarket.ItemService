using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DTOs;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Interfaces;
using Services;

namespace Radiomarket.Itemservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;
        
        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Item>> GetItems()
        {
            var result = await _repository.GetItems();
            if (result.Any<Item>())
            {
                return Ok(result);
            }
            else return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(Guid id)
        {
            var result = await _repository.GetItemById(id);

            if (result != null)
            {
                return Ok(result);
            }
            else return NotFound();
        }

        [HttpGet("category/{categoryID}")]
        public async Task<ActionResult<Item>> GetItemsByCategory(int categoryID)
        {
            var result = await _repository.GetItemByCategory(categoryID);

            if (result.Any<Item>())
            {
                return Ok(result);
            }
            else return NotFound();
        }

        [HttpGet("owner/{ownerID}")]
        public async Task<ActionResult<Item>> GetItemsByOwner(int ownerID)
        {
            var result = await _repository.GetItemByOwner(ownerID);

            if (result.Any<Item>())
            {
                return Ok(result);
            }
            else return NotFound();
        }

        
        [HttpGet("status/{statusCode}")]
        public async Task<ActionResult<Item>> GetItemsByStatus(int statusCode)
        {
            var result = await _repository.GetItemByStatus(statusCode);
           
            if (result.Any<Item>())
            {
                return Ok(result);
            }
            else return NotFound();
        }

        [HttpGet("condition/{condition}")]
        public async Task<ActionResult<Item>> GetItemsInCondition(int condition)
        {
            var result = await _repository.GetItemByCondition(condition);
            if (result.Any())
            {
                return Ok(result);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ReqResult>> CreateNewItem([FromBody] ItemDTO newItem)
        {
            var addItemResult = await _repository.AddNewItem(newItem);

            if (addItemResult == ReqResult.Success)
            {
                return StatusCode(201);
            }
            else return StatusCode(500);
        }

        [HttpPatch("{itemId}")]
        public async Task<ActionResult<ReqResult>> UpdateItem(Guid itemId, JsonPatchDocument<Item> patchDocument)
        {
            var result = await _repository.UpdateItem(itemId, patchDocument);

            if (result == ReqResult.NotFound)
            {
                return NotFound();
            }
            else return Ok();
        }

        [HttpGet("count")]

        public async Task<ActionResult<int>> GetItemCount()
        {
            var count = await _repository.GetItemCount();
            return Ok(count);
        }

    }
}

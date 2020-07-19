using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DTOs;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Interfaces;
using Services;

namespace Radiomarket.Itemservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<DataLayer.Entities.Category>> getCategories()
        {
            var categoryResults = await _repository.GetCategories();
            if (categoryResults.Any())
            {
                return Ok(categoryResults);
            }
            else return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataLayer.Entities.Category>> getCategoryById(int ID)
        {
            var categoryResult = await _repository.GetCategoryByID(ID);
            if (categoryResult.Any<DataLayer.Entities.Category>())
            {
                return Ok(categoryResult);
            }
            else return NotFound("No matching category found");
        }

        [HttpGet("children/{categoryId}")]
        public async Task<ActionResult<DataLayer.Entities.Category>> GetCategoryChildrenByID(int categoryId)
        {
            var childResult = await _repository.GetChildrenByID(categoryId);

            if (childResult.Any())
            {
                return Ok(childResult);
            }
            else return NotFound();
            
        }

        [HttpPost]
        public async Task<ActionResult<DataLayer.Entities.Category>> AddnewCategory([FromBody] CategoryDTO newCategoryObject)
        {
            var addCategoryResult = await _repository.AddNewCategory(newCategoryObject);
            return StatusCode(201, addCategoryResult);
        }

        [HttpPatch("{categoryId}")]
        public async Task<ActionResult> updateCategory(int categoryId, [FromBody] CategoryUpdateDTO updateObject)
        {
            var result = await _repository.UpdateCategory(categoryId, updateObject);
            if (result == ReqResult.NotFound)
            {
                return NotFound();
            }
            else
            {
                return Ok("Category updated");
            }
        }


    }
}

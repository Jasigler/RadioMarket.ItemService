using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Entities;

namespace Radiomarket.Itemservice.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryUpdateDTO>();
            CreateMap<CategoryUpdateDTO, Category>();
        }
    }
}

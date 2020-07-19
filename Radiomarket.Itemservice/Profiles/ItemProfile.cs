using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiomarket.Itemservice.Profiles
{
    public class ItemProfile: Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();
            CreateMap<Item, ItemUpdateDTO>();
            CreateMap<ItemUpdateDTO, Item>();
        }
    }
}

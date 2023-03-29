using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Domain.Entities;
using YAB.App.Service.Dto;

namespace YAB.App.Service.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
            this.CreateMap<Category, CreatedCategoryDto>().ReverseMap();
        }
    }
}

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
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            this.CreateMap<Product,ProductListDto>().ReverseMap();
            this.CreateMap<Product,CreatedCategoryDto>().ReverseMap();
        }
    }
}

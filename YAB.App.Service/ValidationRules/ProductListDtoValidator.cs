using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Service.Dto;

namespace YAB.App.Service.ValidationRules
{
    public class ProductListDtoValidator:AbstractValidator<ProductListDto>
    {
        public ProductListDtoValidator()
        {   
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Stock).NotEmpty();
            RuleFor(x=>x.Price).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
        }

    }
}

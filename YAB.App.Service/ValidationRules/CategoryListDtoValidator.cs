using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Service.Dto;

namespace YAB.App.Service.ValidationRules
{
    public class CategoryListDtoValidator:AbstractValidator<CategoryListDto>
    {
        public CategoryListDtoValidator()
        {
            //RuleFor(x => x.Id).NotEmpty().WithMessage("boş olmamalı");
            RuleFor(x => x.Definition).NotEmpty().WithMessage("boş olmamalı");
        }
    }
}

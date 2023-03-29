using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Service.Dto;

namespace YAB.App.Service.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest:IRequest<CreatedCategoryDto?>
    {
        public string? Definition { get; set; }
    }
}

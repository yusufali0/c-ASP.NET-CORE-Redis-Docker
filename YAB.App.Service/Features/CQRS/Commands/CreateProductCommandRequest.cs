using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Service.Dto;

namespace YAB.App.Service.Features.CQRS.Commands
{
    public class CreateProductCommandRequest:IRequest<CreatedProductDto>
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}

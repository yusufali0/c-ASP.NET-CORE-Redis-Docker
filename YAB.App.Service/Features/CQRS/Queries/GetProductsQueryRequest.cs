using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Service.Dto;

namespace YAB.App.Service.Features.CQRS.Queries
{
    public class GetProductsQueryRequest:IRequest<List<ProductListDto>>
    {
    }
}

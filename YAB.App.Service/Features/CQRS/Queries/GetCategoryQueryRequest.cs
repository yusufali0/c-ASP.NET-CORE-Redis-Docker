using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Domain.Entities;
using YAB.App.Service.Dto;

namespace YAB.App.Service.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest:IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}

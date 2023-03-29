using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Domain.Entities;
using YAB.App.Service.Dto;
using YAB.App.Service.Features.CQRS.Queries;
using YAB.App.Service.Interfaces;

namespace YAB.App.Service.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto?>
    {
        private readonly IGenericRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoryQueryHandler(IGenericRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryListDto?> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            return this.mapper.Map<CategoryListDto>(data);
        }
    }
}

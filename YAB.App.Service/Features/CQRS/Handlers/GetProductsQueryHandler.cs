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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IGenericRepository<Product> repository;
        private readonly IMapper mapper;

        public GetProductsQueryHandler(IGenericRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await this.repository.GetAllAsync();

            return this.mapper.Map<List<ProductListDto>>(products);
        }
    }
}

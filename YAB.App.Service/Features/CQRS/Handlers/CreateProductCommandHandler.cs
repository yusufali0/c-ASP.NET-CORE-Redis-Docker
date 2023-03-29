using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Domain.Entities;
using YAB.App.Service.Dto;
using YAB.App.Service.Features.CQRS.Commands;
using YAB.App.Service.Interfaces;

namespace YAB.App.Service.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreatedProductDto?>
    {
        private readonly IGenericRepository<Product> repository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IGenericRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedProductDto?> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.CreateAsync(new Product
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });

            return this.mapper.Map<CreatedProductDto>(data);
        }
    }
}

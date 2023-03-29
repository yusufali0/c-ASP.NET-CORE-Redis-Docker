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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreatedCategoryDto?>
    {
        private readonly IGenericRepository<Category> repository;
        private readonly IMapper mapper;


        public CreateCategoryCommandHandler(IGenericRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedCategoryDto?> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = new Category { Definition = request.Definition };
            var result = await this.repository.CreateAsync(category);
            return this.mapper.Map<CreatedCategoryDto>(result);

        }
    }
}

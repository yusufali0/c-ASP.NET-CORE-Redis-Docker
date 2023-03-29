using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAB.App.Domain.Entities;
using YAB.App.Service.Features.CQRS.Commands;
using YAB.App.Service.Interfaces;

namespace YAB.App.Service.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IGenericRepository<Category> repository;

        public UpdateCategoryCommandHandler(IGenericRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await this.repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.Definition = request.Definition;
                await this.repository.UpdateAsync(updatedEntity);
            }

            return Unit.Value;
        }


        
    }
}

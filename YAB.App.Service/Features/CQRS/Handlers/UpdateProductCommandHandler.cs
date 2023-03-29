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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IGenericRepository<Product> repository;

        public UpdateProductCommandHandler(IGenericRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await this.repository.GetByIdAsync(request.Id);

            if (updatedEntity != null)
            {
                updatedEntity.Name = request.Name;
                updatedEntity.Price = request.Price;
                updatedEntity.Stock = request.Stock;
                updatedEntity.CategoryId = request.CategoryId;
                await this.repository.UpdateAsync(updatedEntity);
            }

            return Unit.Value;
        }
    }
}

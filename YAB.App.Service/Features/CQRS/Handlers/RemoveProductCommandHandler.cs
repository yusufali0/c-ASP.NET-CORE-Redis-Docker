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
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest>
    {
        private readonly IGenericRepository<Product> repository;

        public RemoveProductCommandHandler(IGenericRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var removeEntity=await this.repository.GetByIdAsync(request.Id);
            if(removeEntity != null)
            {
                await this.repository.Remove(removeEntity);
            }

            return Unit.Value;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAB.App.Service.Features.CQRS.Commands
{
    public class RemoveCategoryCommandRequest:IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryCommandRequest(int id)
        {
            Id= id;
        }
    }
}

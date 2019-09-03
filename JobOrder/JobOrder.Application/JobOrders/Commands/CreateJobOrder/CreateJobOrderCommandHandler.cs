using System.Threading;
using System.Threading.Tasks;
using MediatR;
using JobOrder.Application.Interfaces;
using JobOrder.Domain.Entities;
using System;

namespace JobOrder.Application.JobOrders.Commands.CreateJobOrder
{
    public class CreateJobOrderCommandHandler : IRequestHandler<CreateJobOrderCommand, int>
    {
        private readonly IMediator _mediator;

        public CreateJobOrderCommandHandler(IMediator mediator)
        {
          _mediator = mediator;
        }


        public async Task<int> Handle(CreateJobOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new JobOrderEntity
            {
              JobOrderId = 12345,
              Address = request.Address,
              City = request.City,
              CompanyName = request.CompanyName,
              ContactName = request.ContactName,
              ContactTitle = request.ContactTitle,
              Country = request.Country,
              Fax = request.Fax,
              Phone = request.Phone,
              PostalCode = request.PostalCode
            };


      //await _context.SaveChangesAsync(cancellationToken);
      
      await _mediator.Publish(new JobOrderCreated { JobOrderId = entity.JobOrderId }, cancellationToken);

      return entity.JobOrderId;
        }
    }
}

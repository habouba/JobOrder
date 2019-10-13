using System.Threading;
using System.Threading.Tasks;
using MediatR;
using JobOrder.Application.Interfaces;
using JobOrder.Domain.Entities;
using System;

namespace JobOrder.Application.JobOrders.Commands.CreateJobOrder
{
    public class CreateJobOrderCommandHandler : IRequestHandler<ContextualRequest<CreateJobOrderCommand, int>, int>
  {
        private readonly IMediator _mediator;

        public CreateJobOrderCommandHandler(IMediator mediator)
        {
          _mediator = mediator;
        }


        public async Task<int> Handle(ContextualRequest<CreateJobOrderCommand, int>  request, CancellationToken cancellationToken)
        {
            var requestData = request.Data;
            var entity = new JobOrderEntity
            {
              JobOrderId = 12345,
              Address = requestData.Address,
              City = requestData.City,
              CompanyName = requestData.CompanyName,
              ContactName = requestData.ContactName,
              ContactTitle = requestData.ContactTitle,
              Country = requestData.Country,
              Fax = requestData.Fax,
              Phone = requestData.Phone,
              PostalCode = requestData.PostalCode
            };


      //await _context.SaveChangesAsync(cancellationToken);
      
      await _mediator.Publish(new JobOrderCreated { JobOrderId = entity.JobOrderId }, cancellationToken);

      return entity.JobOrderId;
        }
    }
}

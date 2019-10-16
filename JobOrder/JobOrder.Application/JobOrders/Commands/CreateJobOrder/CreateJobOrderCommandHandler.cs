using System.Threading;
using System.Threading.Tasks;
using MediatR;
using JobOrder.Domain.Entities;
using System;

namespace JobOrder.Application.JobOrders.Commands.CreateJobOrder
{
    public class CreateJobOrderCommandHandler : IRequestHandler<ContextualRequest<CreateJobOrderCommand, Guid>, Guid>
  {
        private readonly IMediator _mediator;

        public CreateJobOrderCommandHandler(IMediator mediator)
        {
          _mediator = mediator;
        }

        public async Task<Guid> Handle(ContextualRequest<CreateJobOrderCommand, Guid> request, CancellationToken cancellationToken)
        {
            var requestData = request.Data;

            var entity = JobOrderEntity.Factory.CreateNewEntry(
              requestData.CompanyName,
              requestData.ContactTitle,
              requestData.Address,
              requestData.Phone);
            
            await _mediator.Publish(new JobOrderCreated { JobOrderId = entity.JobOrderId }, cancellationToken);

            return entity.JobOrderId;
        }
    }
}

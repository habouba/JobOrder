using System;
using System.Threading;
using System.Threading.Tasks;
using JobOrder.Application.JobOrders.Commands.CreateJobOrder;
using MediatR;

namespace JobOrder.Infrastructure
{
  public class JobOrderCreatedHandler : INotificationHandler<JobOrderCreated>
  {

    public async Task Handle(JobOrderCreated notification, CancellationToken cancellationToken)
    {
       await Task.FromResult(notification);
    }
  }
  
}

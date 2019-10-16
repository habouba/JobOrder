using MediatR;
using System;

namespace JobOrder.Application.JobOrders.Commands.CreateJobOrder
{
    public class JobOrderCreated : INotification
    {
        public Guid JobOrderId { get; set; }
    }
}

using MediatR;
using JobOrder.Application.Interfaces;
using JobOrder.Application.Notifications.Models;
using System.Threading;
using System.Threading.Tasks;

namespace JobOrder.Application.JobOrders.Commands.CreateJobOrder
{
    public class JobOrderCreated : INotification
    {
        public int JobOrderId { get; set; }

        public class JobOrderCreatedHandler : INotificationHandler<JobOrderCreated>
        {
            private readonly INotificationService _notification;

            public JobOrderCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(JobOrderCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}

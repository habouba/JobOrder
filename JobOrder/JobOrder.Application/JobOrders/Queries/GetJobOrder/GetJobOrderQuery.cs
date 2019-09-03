using MediatR;

namespace JobOrder.Application.JobOrders.Queries.GetJobOrder
{
    public class GetJobOrderQuery : IRequest<JobOrderViewModel>
    {
        public int JobOrderId { get; set; }
    }
}

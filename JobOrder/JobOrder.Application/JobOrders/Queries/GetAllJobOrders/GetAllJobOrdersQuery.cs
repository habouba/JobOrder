using MediatR;

namespace JobOrder.Application.JobOrders.Queries.GetAllJobOrders
{
    public class GetAllJobOrdersQuery : IRequest<JobOrdersListViewModel>
    {
    }
}

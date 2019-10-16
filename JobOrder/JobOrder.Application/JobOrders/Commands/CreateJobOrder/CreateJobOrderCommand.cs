using System;
using MediatR;

namespace JobOrder.Application.JobOrders.Commands.CreateJobOrder
{
    public class CreateJobOrderCommand : IRequest<Guid>
    {
    public string CompanyName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
  }
}

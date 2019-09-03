using System.Collections.Generic;

namespace JobOrder.Application.JobOrders.Queries.GetAllJobOrders
{
    public class JobOrdersListViewModel
  {
        public IEnumerable<JobOrderDto> JobOrders { get; set; }

        public bool CreateEnabled { get; set; }
    }
}

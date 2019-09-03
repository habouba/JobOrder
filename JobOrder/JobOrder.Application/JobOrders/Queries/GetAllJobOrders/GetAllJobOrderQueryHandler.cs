using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

using JobOrder.Application.Interfaces;

namespace JobOrder.Application.JobOrders.Queries.GetAllJobOrders
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllJobOrdersQuery, JobOrdersListViewModel>
    {

        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler( IMapper mapper)
        {
 
            _mapper = mapper;
        }

        public async Task<JobOrdersListViewModel> Handle(GetAllJobOrdersQuery request, CancellationToken cancellationToken)
        {
      // TODO: Set view model state based on user permissions.
      //var jobOrders = await _context.JobOrders.OrderBy(p => p.JobOrderName).Include(p => p.Supplier).ToListAsync(cancellationToken);
    
            var model = new JobOrdersListViewModel
            {
               //JobOrders = _mapper.Map<IEnumerable<JobOrderDto>>(jobOrders),
               JobOrders = new List<JobOrderDto> { new JobOrderDto { JobOrderId= 12345,CompanyName = "test"} },
                CreateEnabled = true
            };

            return await Task.FromResult(model);
        }
    }
}

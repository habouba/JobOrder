using AutoMapper;
using JobOrder.Application.Exceptions;
using JobOrder.Application.Interfaces;
using JobOrder.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JobOrder.Application.JobOrders.Queries.GetJobOrder
{
    public class GetJobOrderQueryHandler : IRequestHandler<GetJobOrderQuery, JobOrderViewModel>
    {
  
        private readonly IMapper _mapper;

        public GetJobOrderQueryHandler(IMapper mapper)
        {

            _mapper = mapper;
        }

        public async Task<JobOrderViewModel> Handle(GetJobOrderQuery request, CancellationToken cancellationToken)
        {
      /*var jobOrder = _mapper.Map<JobOrderViewModel>(await _context
          .JobOrders.Where(p => p.JobOrderId == request.Id)
          .SingleOrDefaultAsync(cancellationToken));
          */
      if (request.JobOrderId == 0)
      {
        throw new NotFoundException(nameof(JobOrder), request.JobOrderId);
      }
      /*
      // TODO: Set view model state based on user permissions.
      jobOrder.EditEnabled = true;
      jobOrder.DeleteEnabled = false;

      return jobOrder;*/
      //var jobOrder = new JobOrderViewModel() { JobOrderId = 1234556, CompanyName = "test" };
      //return jobOrder;
      //var entity = new JobOrderEntity { JobOrderId = 1234556, CompanyName = "test" };
      //return await Task.FromResult(JobOrderViewModel.Create(entity));
      return await Task.FromResult(new JobOrderViewModel());
    }
    }
}

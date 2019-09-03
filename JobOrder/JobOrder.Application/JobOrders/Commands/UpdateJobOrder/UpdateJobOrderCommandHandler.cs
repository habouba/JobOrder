using System.Threading;
using System.Threading.Tasks;
using MediatR;
using JobOrder.Application.Exceptions;
using JobOrder.Application.Interfaces;
using JobOrder.Domain.Entities;

namespace JobOrder.Application.JobOrders.Commands.UpdateJobOrder
{
    public class UpdateJobOrderCommandHandler : IRequestHandler<UpdateJobOrderCommand, Unit>
    {
       
        public async Task<Unit> Handle(UpdateJobOrderCommand request, CancellationToken cancellationToken)
        {
      /*var entity = await _context.Products.FindAsync(request.JobOrderId);

      if (entity == null)
      {
          throw new NotFoundException(nameof(JobOrderEntity), request.JobOrderId);
      }

      entity.Address = request.Address;
          entity.City = request.City;
          entity.CompanyName = request.CompanyName;
          entity.ContactName = request.ContactName;
          entity.ContactTitle = request.ContactTitle;
          entity.Country = request.Country;
          entity.Fax = request.Fax;
          entity.Phone = request.Phone;
          entity.PostalCode = request.PostalCode;

      await _context.SaveChangesAsync(cancellationToken);
      */
      return Unit.Value;
        }
    }
}

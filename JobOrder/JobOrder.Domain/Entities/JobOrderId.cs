using System;
namespace JobOrder.Domain.Entities
{
  public class JobOrderId : TypedIdValueBase
  {
    public JobOrderId(Guid value) : base(value)
    {
    }
  }
}

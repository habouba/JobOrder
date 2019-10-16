using System;
using JobOrder.Domain.Entities;

namespace JobOrder.Domain
{
  public class JobOrderRegisteredEvent : DomainEventBase
  {
    public JobOrderEntity JobOrderEntity { get; }
    public JobOrderRegisteredEvent(JobOrderEntity jobOrder)
    {
        this.JobOrderEntity = jobOrder;
    }
  }
}

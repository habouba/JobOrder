using System;
using System.Collections.Generic;

namespace JobOrder.Domain
{
  public interface IAggregate
  {
    Guid Id { get; }

    bool HasPendingChanges { get; }

    IEnumerable<DomainEvent> GetUncommittedEvents();

    void ClearUncommittedEvents();
  }
}

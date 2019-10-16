using System;
using MediatR;

namespace JobOrder.Domain
{
  public interface IDomainEvent : INotification
  {
    DateTime OccurredOn { get; }
  }
}
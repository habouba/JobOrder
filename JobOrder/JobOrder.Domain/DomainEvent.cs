using System;
namespace JobOrder.Domain
{
  public class DomainEvent
  {
    public DateTime TimeStamp { get; private set; }

    public DomainEvent()
    {
      this.TimeStamp = DateTime.Now;
    }
  }
}

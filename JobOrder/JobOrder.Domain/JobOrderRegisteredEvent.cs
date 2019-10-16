using System;

namespace JobOrder.Domain
{
  public class JobOrderRegisteredEvent : DomainEvent
  {
    public Guid JobOrderId { get; private set; }
    public string CompanyName { get; private set; }
    public string ContactTitle { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }


    public JobOrderRegisteredEvent(Guid jobOrderId, string companyName, string contactTitle, string address, string phone)
    {
      JobOrderId = jobOrderId;
      CompanyName = companyName;
      ContactTitle = contactTitle;
      Address = address;
      Phone = phone;
    }
  }
}

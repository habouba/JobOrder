using System;
namespace JobOrder.Domain.Entities
{
  public class JobOrderEntity : Entity, IAggregateRoot
  {
    public JobOrderId JobOrderId { get; private set; }
    public string CompanyName { get; private set; }
    public string ContactTitle { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }

    public  JobOrderEntity(string companyName, string contactTitle, string address, string phone)
    {
      JobOrderId = new JobOrderId(Guid.NewGuid());
      CompanyName = companyName;
      ContactTitle = contactTitle;
      Address = address;
      Phone = phone;

      this.AddDomainEvent(new JobOrderRegisteredEvent(this));
    }
  }
}


using System;
namespace JobOrder.Domain.Entities
{
  public class JobOrderEntity : Aggregate
  {
    public Guid JobOrderId { get; private set; }
    public string CompanyName { get; private set; }
    public string ContactTitle { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }

    public void Apply(JobOrderRegisteredEvent evt)
    {
      JobOrderId = evt.JobOrderId;
      CompanyName = evt.CompanyName;
      ContactTitle = evt.ContactTitle;
      Address = evt.Address;
      Phone = evt.Phone;
    }

    public static class Factory
    {
      public static JobOrderEntity CreateNewEntry(string companyName, string contactTitle, string address, string phone)
      {
        var e = new JobOrderRegisteredEvent(Guid.NewGuid(), companyName, contactTitle, address, phone);
        var p = new JobOrderEntity();
        p.RaiseEvent(e);
        return p;
      }
    }
  }
}


using AutoMapper;
using JobOrder.Application.Interfaces.Mapping;
using JobOrder.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace JobOrder.Application.JobOrders.Queries.GetJobOrder
{
  public class JobOrderViewModel
  {
    public int JobOrderId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Country { get; set; }
    public string Fax { get; set; }
    public string Phone { get; set; }
    public string PostalCode { get; set; }
    public string Region { get; set; }

    public static Expression<Func<JobOrderEntity, JobOrderViewModel>> Projection
    {
      get
      {
        return jobOrder => new JobOrderViewModel
        {
          /*JobOrderId = jobOrder.JobOrderId.Value,
          Address = jobOrder.Address,
          City = jobOrder.City,
          CompanyName = jobOrder.CompanyName,
          ContactName = jobOrder.ContactName,
          ContactTitle = jobOrder.ContactTitle,
          Country = jobOrder.Country,
          Fax = jobOrder.Fax,
          Phone = jobOrder.Phone,
          PostalCode = jobOrder.PostalCode,
          Region = jobOrder.Region*/
        };
      }
    }

    public static JobOrderViewModel Create(JobOrderEntity jobOrder)
    {
      return Projection.Compile().Invoke(jobOrder);
    }
  }
}

using System;
using System.Linq.Expressions;
using AutoMapper;
using JobOrder.Application.Interfaces.Mapping;
using JobOrder.Domain.Entities;

namespace JobOrder.Application.JobOrders.Queries.GetAllJobOrders
{
    public class JobOrderDto 
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

  }
}
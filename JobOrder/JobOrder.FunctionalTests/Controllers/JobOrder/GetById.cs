using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JobOrder.Api;
using JobOrder.Application.JobOrders.Queries.GetJobOrder;
using JobOrder.FunctionalTests.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace JobOrder.FunctionalTests.Controllers.JobOrder
{
  public class GetById : IClassFixture<WebApplicationFactory<Startup>>
  {
    private readonly HttpClient _client;

    public GetById(WebApplicationFactory<Startup> factory)
    {
      _client = factory.CreateClient();
    }

    [Fact]
    public async Task GivenId_ReturnsJobOrderViewModel()
    {
      var id = 1234556;

      var response = await _client.GetAsync($"/api/joborders/get/{id}");

      response.EnsureSuccessStatusCode();

      var jobOrder = await Utilities.GetResponseContent<JobOrderViewModel>(response);

      Assert.Equal(id, jobOrder.JobOrderId);
    }

    [Fact]
    public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
    {
      var invalidId = 0;

      var response = await _client.GetAsync($"/api/joborders/get/{invalidId}");

      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
  }
}

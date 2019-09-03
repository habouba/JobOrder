using System.Net.Http;
using System.Threading.Tasks;
using JobOrder.Api;
using JobOrder.Application.JobOrders.Queries.GetAllJobOrders;
using JobOrder.FunctionalTests.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace JobOrder.FunctionalTests.Controllers.JobOrder
{
  public class GetAll : IClassFixture<WebApplicationFactory<Startup>>
  {
    private readonly HttpClient _client;

    public GetAll(WebApplicationFactory<Startup> factory)
    {
      _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnsJobOrdersListViewModel()
    {
      var response = await _client.GetAsync("/api/joborders/getall");

      response.EnsureSuccessStatusCode();

      var vm = await Utilities.GetResponseContent<JobOrdersListViewModel>(response);

      Assert.IsType<JobOrdersListViewModel>(vm);
      Assert.NotEmpty(vm.JobOrders);
    }
  }
}

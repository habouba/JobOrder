using System.Net.Http;
using System.Threading.Tasks;
using JobOrder.Api;
using JobOrder.Application.JobOrders.Commands.CreateJobOrder;
using JobOrder.FunctionalTests.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace JobOrder.FunctionalTests.Controllers.JobOrder
{
    public class Create : IClassFixture<WebApplicationFactory<Startup>>
    {
      private readonly HttpClient _client;

      public Create(WebApplicationFactory<Startup> factory)
      {
        _client = factory.CreateClient();
      }

      [Fact]
      public async Task GivenCreateJobOrderCommand_ReturnsNewJobOrderId()
      {
        var command = new CreateJobOrderCommand
        {
          CompanyName = "Coffee",
          ContactTitle = "Bibo",
          Address = "Address"
        };

        var content = Utilities.GetRequestContent(command);

        var response = await _client.PostAsync($"/api/joborders/create", content);

        response.EnsureSuccessStatusCode();

        var jobOrderId = await Utilities.GetResponseContent<int>(response);

        Assert.NotEqual(0, jobOrderId);
      }
    }
  
}

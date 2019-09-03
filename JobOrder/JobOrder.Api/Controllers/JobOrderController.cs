using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobOrder.Application.JobOrders.Commands.CreateJobOrder;
using JobOrder.Application.JobOrders.Commands.UpdateJobOrder;
using JobOrder.Application.JobOrders.Queries.GetAllJobOrders;
using JobOrder.Application.JobOrders.Queries.GetJobOrder;
using Microsoft.AspNetCore.Http;

namespace JobOrder.Api.Controllers
{
  public class JobOrdersController : BaseController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<ActionResult<JobOrdersListViewModel>> GetAll()
    {
      return Ok(await Mediator.Send(new GetAllJobOrdersQuery()));
    }

    [HttpGet("{jobOrderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces("application/json")]
    public async Task<ActionResult<JobOrderViewModel>> Get(int jobOrderId)
    {
      return Ok(await Mediator.Send(new GetJobOrderQuery { JobOrderId = jobOrderId }));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ActionResult<int>> Create([FromBody] CreateJobOrderCommand command)
    {
      var JobOrderId = await Mediator.Send(command);

      return Ok(JobOrderId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> Update([FromBody] UpdateJobOrderCommand command)
    {
      await Mediator.Send(command);

      return NoContent();
    }
  }
}

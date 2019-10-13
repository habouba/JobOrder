using System;
using MediatR;

namespace JobOrder.Application.JobOrders
{
  public class ContextualRequest<TRequest, TResponse> : IRequest<TResponse>
    where TRequest : IRequest<TResponse>
  {
    public ContextualRequest(TRequest data, string userName)
    {
      Data = data;
      UserName = userName;
    }

    public TRequest Data { get; }

    public string UserName { get; }
  }
}

using JobOrder.Application.Interfaces;
using JobOrder.Application.Notifications.Models;
using System.Threading.Tasks;

namespace JobOrder.Infrastructure
{
  public class NotificationService : INotificationService
  {
    public Task SendAsync(Message message)
    {
      return Task.CompletedTask;
    }
  }
}

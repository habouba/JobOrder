using JobOrder.Application.Notifications.Models;
using System.Threading.Tasks;

namespace JobOrder.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}

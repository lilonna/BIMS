using BIMS.Models;

namespace BIMS.Services
{
    public interface INotificationService
    {
        Task NotifyAdmin(Order order);
        Task NotifyShopOwner(Order order);
    }
}

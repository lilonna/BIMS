using BIMS.Models;

namespace BIMS.Services
{
    public interface INotificationService
    {
        Task NotifyAdmin(int orderId);
        Task NotifyShopOwners(int orderId);
        Task<List<Notification>> GetNotificationsForShopOwnerAsync(int shopOwnerUserId);
    }
}

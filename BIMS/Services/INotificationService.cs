using BIMS.Models;

namespace BIMS.Services
{
    public interface INotificationService
    {
        Task NotifyAdmin(int orderId);
        Task NotifyShopOwners(int orderId);
        Task<List<Notification>> GetNotificationsForShopOwnerAsync(int shopOwnerUserId);
        Task NotifyAdminOfOwnerRequest(int userId);  // ✅ Add this method
        Task NotifyUserOfApproval(int userId);
    }
}

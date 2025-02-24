using BIMS.Models;

namespace BIMS.Services
{
    public interface INotificationService
    {
        Task MarkAsRead(int notificationId);
        Task NotifyAdmin(int orderId);
        Task NotifyShopOwners(int orderId);
        Task<List<Notification>> GetUserNotifications ();
        Task NotifyAdminOfOwnerRequest(int userId);  // ✅ Add this method
        Task NotifyUserOfApproval(int userId);
    }
}

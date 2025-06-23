namespace BIMS.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int SubscriptionOptionId { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }

        public string ChapaTxnRef { get; set; }

        public SubscriptionOption SubscriptionOption { get; set; }
    }

}

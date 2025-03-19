namespace BIMS.Models
{
    public class ChapaWebhookResponse
    {
        public int Id { get; set; }
        public string TxRef { get; set; } // Transaction reference
        public string? Amount { get; set; }  // Nullable string for flexibility

        public string Status { get; set; } // Success or Failed
    }
}

namespace BIMS.Models
{
    public class SubscriptionOption
    {
        public int Id { get; set; }

        public int SubscriptionPlanId { get; set; }

        public int DurationInMonths { get; set; } // e.g., 1, 3, 6, 12

        public decimal Price { get; set; }

        public string DisplayLabel => $"{DurationInMonths} month(s) - {Price} ETB";
    }

}

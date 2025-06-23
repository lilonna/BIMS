namespace BIMS.Models
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }

        public string Name { get; set; } // e.g. "Basic", "Premium"

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<SubscriptionOption> Options { get; set; }
    }

}

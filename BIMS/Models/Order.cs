using System.ComponentModel.DataAnnotations.Schema;

namespace BIMS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; } // FK from Identity
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public string? TransactionRef { get; set; }
      

        public string Status { get; set; } = "Pending"; // "Pending", "Shipped", "Delivered"
        public string PaymentStatus { get; set; } = "Unpaid"; // "Paid" after Chapa payment

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

}

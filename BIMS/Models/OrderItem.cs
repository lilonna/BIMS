using System.ComponentModel.DataAnnotations.Schema;

namespace BIMS.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // FK from Order
        public int ItemId { get; set; } // FK from Product
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Price at the time of order

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }

}

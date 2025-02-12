using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; } // FK from Identity
        public int ItemId { get; set; } // FK from Product
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; } // Quantity * Product.Price

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }

}

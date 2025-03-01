using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

[Index("ShopId", Name = "IX_Items_ShopId")]
public partial class Item
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int ItemCategoryId { get; set; }

    public bool IsAvailable { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
    public int Stock { get; set; }
    public decimal DiscountPrice { get; set; } // New field for discounts
    public int SalesCount { get; set; }
    public string ImagePath { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public int ShopId { get; set; }

    [ForeignKey("ItemCategoryId")]
    [InverseProperty("Items")]
    public virtual ItemCategory ItemCategory { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<ItemImage> ItemImages { get; set; } = new List<ItemImage>();

    [InverseProperty("Item")]
    public virtual ICollection<ItemPrice> ItemPrices { get; set; } = new List<ItemPrice>();
}

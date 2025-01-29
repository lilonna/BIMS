using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class Shop
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int UserId { get; set; }

    public int BusinessAreaId { get; set; }

    [Required]
    [StringLength(100)]
    public string Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    [ForeignKey("BusinessAreaId")]
    [InverseProperty("Shops")]
    public virtual BusinessArea BusinessArea { get; set; }

    [InverseProperty("Shop")]
    public virtual ICollection<ShopLocation> ShopLocations { get; set; } = new List<ShopLocation>();
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    [ForeignKey("UserId")]
    [InverseProperty("Shops")]
    public virtual User User { get; set; }
}

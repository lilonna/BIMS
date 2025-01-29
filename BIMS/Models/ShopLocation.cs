using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class ShopLocation
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int RoomId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int ShopId { get; set; }

    public DateOnly CreatedDate { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("ShopLocations")]
    public virtual Room Room { get; set; }

    [ForeignKey("ShopId")]
    [InverseProperty("ShopLocations")]
    public virtual Shop Shop { get; set; }
}

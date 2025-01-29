using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class Floor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int BuildingId { get; set; }

    [Required]
    [StringLength(50)]
    public string NumberOfRoom { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("BuildingId")]
    [InverseProperty("Floors")]
    public virtual Building Building { get; set; }

    [InverseProperty("Floor")]
    public virtual ICollection<FloorPrice> FloorPrices { get; set; } = new List<FloorPrice>();

    [InverseProperty("Floor")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}

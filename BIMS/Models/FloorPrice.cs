using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class FloorPrice
{
    [Key]
    public int Id { get; set; }

    public int FloorId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public double Price { get; set; }

    public DateOnly AppliedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("FloorId")]
    [InverseProperty("FloorPrices")]
    public virtual Floor Floor { get; set; }
}

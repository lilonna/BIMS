using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class OwnershipType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(200)]
    public string Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("OwnershipType")]
    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    [InverseProperty("OwnershipType")]
    public virtual ICollection<Owner> Owners { get; set; } = new List<Owner>();
}

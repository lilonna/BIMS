using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class Tenant
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string Description { get; set; }

    [Required]
    [StringLength(50)]
    public string Contact { get; set; }

    public int TenantTypeId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Tenant")]
    public virtual ICollection<RoomRental> RoomRentals { get; set; } = new List<RoomRental>();

    [ForeignKey("TenantTypeId")]
    [InverseProperty("Tenants")]
    public virtual TenantType TenantType { get; set; }
}

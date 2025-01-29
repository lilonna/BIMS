using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class RoomPropertyType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("RoomPropertyType")]
    public virtual ICollection<RoomProperty> RoomProperties { get; set; } = new List<RoomProperty>();

    [InverseProperty("RoomPropertyType")]
    public virtual ICollection<RoomPropertyTypeOption> RoomPropertyTypeOptions { get; set; } = new List<RoomPropertyTypeOption>();
}

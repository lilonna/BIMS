using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class RoomPropertyTypeOption
{
    [Key]
    public int Id { get; set; }

    public int RoomPropertyTypeId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("RoomPropertyTypeId")]
    [InverseProperty("RoomPropertyTypeOptions")]
    public virtual RoomPropertyType RoomPropertyType { get; set; }
}

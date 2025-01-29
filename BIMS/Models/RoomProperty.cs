using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class RoomProperty
{
    [Key]
    public int Id { get; set; }

    public int RoomId { get; set; }

    public int RoomPropertyTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string Value { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("RoomProperties")]
    public virtual Room Room { get; set; }

    [ForeignKey("RoomPropertyTypeId")]
    [InverseProperty("RoomProperties")]
    public virtual RoomPropertyType RoomPropertyType { get; set; }
}

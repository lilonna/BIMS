using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class BusinessArea
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("BusinessArea")]
    public virtual ICollection<RoomRental> RoomRentals { get; set; } = new List<RoomRental>();

    [InverseProperty("BusinessArea")]
    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}

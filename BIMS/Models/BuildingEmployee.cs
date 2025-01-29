using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class BuildingEmployee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FullName { get; set; }

    [Required]
    [StringLength(50)]
    public string PhoneNumber { get; set; }

    public int BuildingId { get; set; }

    public int? UserId { get; set; }

    public int ServiceCategoryId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("BuildingId")]
    [InverseProperty("BuildingEmployees")]
    public virtual Building Building { get; set; }

    [InverseProperty("BuildingEmployee")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    [ForeignKey("ServiceCategoryId")]
    [InverseProperty("BuildingEmployees")]
    public virtual ServiceCategory ServiceCategory { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("BuildingEmployees")]
    public virtual User User { get; set; }
}

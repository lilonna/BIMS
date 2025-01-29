using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class MaintenanceRequest
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoomId { get; set; }

    public int MaintenanceTypeId { get; set; }

    public int BuildingEmployeeId { get; set; }

    public int MaintenanceStatusId { get; set; }

    [Required]
    [StringLength(150)]
    public string Description { get; set; }

    public DateOnly DateSubmitted { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("BuildingEmployeeId")]
    [InverseProperty("MaintenanceRequests")]
    public virtual BuildingEmployee BuildingEmployee { get; set; }

    [ForeignKey("MaintenanceStatusId")]
    [InverseProperty("MaintenanceRequests")]
    public virtual MaintenanceStatus MaintenanceStatus { get; set; }

    [ForeignKey("MaintenanceTypeId")]
    [InverseProperty("MaintenanceRequests")]
    public virtual MaintenanceType MaintenanceType { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("MaintenanceRequests")]
    public virtual Room Room { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("MaintenanceRequests")]
    public virtual User User { get; set; }
}

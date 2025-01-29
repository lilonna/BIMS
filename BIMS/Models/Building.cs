using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class Building
{
    [Key]
    public int Id { get; set; }

    public int UseTypeId { get; set; }

    public int UserId { get; set; }

    public int CityId { get; set; }

    public int LocationId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(200)]
    public string Description { get; set; }

    [Required]
    [StringLength(50)]
    public string ConstractionYear { get; set; }

    public int NumberOfFloor { get; set; }

    public int BuildingTypeId { get; set; }

    public int OwnershipTypeId { get; set; }

    public int OwnerId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Building")]
    public virtual ICollection<BuildingEmployee> BuildingEmployees { get; set; } = new List<BuildingEmployee>();

    [ForeignKey("BuildingTypeId")]
    [InverseProperty("Buildings")]
    public virtual BuildingType BuildingType { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("Buildings")]
    public virtual City City { get; set; }

    [InverseProperty("Building")]
    public virtual ICollection<Floor> Floors { get; set; } = new List<Floor>();

    [ForeignKey("LocationId")]
    [InverseProperty("Buildings")]
    public virtual Location Location { get; set; }

    [ForeignKey("OwnerId")]
    [InverseProperty("Buildings")]
    public virtual Owner Owner { get; set; }

    [ForeignKey("OwnershipTypeId")]
    [InverseProperty("Buildings")]
    public virtual OwnershipType OwnershipType { get; set; }

    [ForeignKey("UseTypeId")]
    [InverseProperty("Buildings")]
    public virtual UseType UseType { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Buildings")]
    public virtual User User { get; set; }
}

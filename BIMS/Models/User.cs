using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class User : IdentityUser<int>
{
    [Key]
    public override int Id { get; set; }

    public int GenderId { get; set; }

    [Required]
    [StringLength(30)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30)]
    public string MiddleName { get; set; }

    [StringLength(30)]
    public string LastName { get; set; }

    [Required]
    [StringLength(100)]
    public new string Email { get; set; }

    [Required]
    [StringLength(50)]
    public new string PhoneNumber { get; set; }

    public DateOnly CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [Required]
    [StringLength(30)]
    public string Password { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<BuildingEmployee> BuildingEmployees { get; set; } = new List<BuildingEmployee>();

    [InverseProperty("User")]
    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    [InverseProperty("Receiver")]
    public virtual ICollection<Chat> ChatReceivers { get; set; } = new List<Chat>();

    [InverseProperty("Sender")]
    public virtual ICollection<Chat> ChatSenders { get; set; } = new List<Chat>();

    [ForeignKey("GenderId")]
    [InverseProperty("Users")]
    public virtual Gender Gender { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [InverseProperty("User")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    [InverseProperty("User")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty("User")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    [InverseProperty("User")]
    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}

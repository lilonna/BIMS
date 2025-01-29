using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class RoomRental
{
    [Key]
    public int Id { get; set; }

    public int RoomId { get; set; }

    public int TenantId { get; set; }

    public double TotalPrice { get; set; }

    public DateOnly StartDate { get; set; }

    public int BusinessAreaId { get; set; }

    public int? DocumentId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("BusinessAreaId")]
    [InverseProperty("RoomRentals")]
    public virtual BusinessArea BusinessArea { get; set; }

    [ForeignKey("DocumentId")]
    [InverseProperty("RoomRentals")]
    public virtual Documente Document { get; set; }

    [InverseProperty("RoomRental")]
    public virtual ICollection<RentalAgreementTermination> RentalAgreementTerminations { get; set; } = new List<RentalAgreementTermination>();

    [ForeignKey("RoomId")]
    [InverseProperty("RoomRentals")]
    public virtual Room Room { get; set; }

    [InverseProperty("RoomRental")]
    public virtual ICollection<RoomRentalPayment> RoomRentalPayments { get; set; } = new List<RoomRentalPayment>();

    [ForeignKey("TenantId")]
    [InverseProperty("RoomRentals")]
    public virtual Tenant Tenant { get; set; }
}

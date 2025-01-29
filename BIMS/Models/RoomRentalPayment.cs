using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class RoomRentalPayment
{
    [Key]
    public int Id { get; set; }

    public int RoomRentalId { get; set; }

    public int PaymentTypeId { get; set; }

    public int PaymentModeId { get; set; }

    public DateOnly PaidDate { get; set; }

    public double TotalAmount { get; set; }

    [Required]
    [StringLength(50)]
    public string InvoiceNumber { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("PaymentModeId")]
    [InverseProperty("RoomRentalPayments")]
    public virtual PaymentMode PaymentMode { get; set; }

    [ForeignKey("PaymentTypeId")]
    [InverseProperty("RoomRentalPayments")]
    public virtual PaymentType PaymentType { get; set; }

    [ForeignKey("RoomRentalId")]
    [InverseProperty("RoomRentalPayments")]
    public virtual RoomRental RoomRental { get; set; }
}

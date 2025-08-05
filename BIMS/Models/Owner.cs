using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BIMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class Owner
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string FullName { get; set; }

    public int OwnershipTypeId { get; set; }

    [Column("TIN")]
    public int Tin { get; set; }

    public int? DocumentId { get; set; }

    public bool Verified { get; set; }
    
    [Required]
    [StringLength(50)]
    public string BankName { get; set; } 

   

    public DateOnly RegisteredDate { get; set; }

    [StringLength(255)]
    public string License { get; set; } 

    public bool IsActive { get; set; }
    [Required]
    [StringLength(50)]
    public string BankAccountNumber { get; set; }

    public bool IsDeleted { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    [ForeignKey("DocumentId")]
    [InverseProperty("Owners")]
    public virtual Documente Document { get; set; }


    [ForeignKey("OwnershipTypeId")]
    [InverseProperty("Owners")]
    public virtual OwnershipType OwnershipType { get; set; }
}

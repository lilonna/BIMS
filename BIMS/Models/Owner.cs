using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models
{
    public partial class Owner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public int OwnershipTypeId { get; set; }

        [Column("TIN")]
        public int Tin { get; set; }

        [StringLength(255)] // Store only the document file name (not the file itself)
        public string License { get; set; }

        public bool Verified { get; set; }

        public DateOnly RegisteredDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [InverseProperty("Owner")]
        public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

        [ForeignKey("OwnershipTypeId")]
        [InverseProperty("Owners")]
        public virtual OwnershipType OwnershipType { get; set; }
    }
}

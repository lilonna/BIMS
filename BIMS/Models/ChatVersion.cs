using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class ChatVersion
{
    [Key]
    public int Id { get; set; }

    public int ChatId { get; set; }

    public DateOnly Date { get; set; }

    [Required]
    [StringLength(50)]
    public string OldMessage { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("ChatId")]
    [InverseProperty("ChatVersions")]
    public virtual Chat Chat { get; set; }
}

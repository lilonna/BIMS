using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BIMS.Models;

public partial class Notification
{
    [Key]
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;

    public bool TempColumn { get; set; } = false;



    public int UserId { get; set; }

    public int NotificationTypeId { get; set; }

    public int NotificationStatusId { get; set; }

    public DateTime NotificationDate { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false;

    public bool IsDeleted { get; set; }

    [ForeignKey("NotificationStatusId")]
    [InverseProperty("Notifications")]
    public virtual NotificationStatus NotificationStatus { get; set; }

    [ForeignKey("NotificationTypeId")]
    [InverseProperty("Notifications")]
    public virtual NotificationType NotificationType { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Notifications")]
    public virtual User User { get; set; }
}

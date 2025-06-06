using System.ComponentModel.DataAnnotations;

namespace BIMS.Models
{
    public class ContactFormModel
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }

}

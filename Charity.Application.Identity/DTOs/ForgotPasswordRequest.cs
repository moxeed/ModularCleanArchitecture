using System.ComponentModel.DataAnnotations;

namespace Charity.Application.IdentityModule.DTOs
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AllocationTeamAPI.Dtos
{
    public class UserRegisterRequest
    {
        public string? Username {  get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public required string Password { get; set; }
    }
}

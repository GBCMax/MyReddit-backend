using System.ComponentModel.DataAnnotations;

namespace MyReddit.API.Contracts.Users
{
    public record class LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
}

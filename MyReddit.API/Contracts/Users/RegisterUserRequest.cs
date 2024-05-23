using System.ComponentModel.DataAnnotations;

namespace MyReddit.API.Contracts.Users
{
    public record class RegisterUserRequest(
        [Required] string UserName,
        [Required] string Password,
        [Required] string Email);
}

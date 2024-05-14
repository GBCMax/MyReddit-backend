namespace MyReddit.API.Contracts.Users
{
    public record class UsersResponse(
        Guid Id,
        string Name,
        string Password,
        string Email);
}

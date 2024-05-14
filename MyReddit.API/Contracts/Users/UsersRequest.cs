namespace MyReddit.API.Contracts.Users
{
    public record class UsersRequest(
        string Name,
        string Password,
        string Email);
}

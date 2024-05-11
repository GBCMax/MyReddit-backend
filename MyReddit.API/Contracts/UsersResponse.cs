namespace MyReddit.API.Contracts
{
    public record class UsersResponse(
        Guid Id, 
        string Name, 
        string Password, 
        string Email);
}

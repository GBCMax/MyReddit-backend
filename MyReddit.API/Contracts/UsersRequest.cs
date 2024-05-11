namespace MyReddit.API.Contracts
{
    public record class UsersRequest(
        string Name, 
        string Password, 
        string Email);
}

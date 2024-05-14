namespace MyReddit.API.Contracts.Posts
{
    public record class PostsResponse(
        Guid Id,
        string Title,
        string Content);
}

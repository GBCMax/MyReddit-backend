namespace MyReddit.API.Contracts.Posts
{
    public record class PostsRequest(
        string Title,
        string Content,
        Guid UserId,
        Guid TopicId);
}

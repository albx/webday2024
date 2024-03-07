using WebDay2024.Client.Services;
using WebDay2024.Models;

namespace WebDay2024.Services;

public class CommentsServerService : ICommentsService
{
    public Task AddCommentAsync(CommentModel comment)
    {
        CommentsStore.Comments.Add(comment);
        return Task.CompletedTask;
    }

    public Task<CommentModel[]> GetCommentsAsync() 
        => Task.FromResult(CommentsStore.Comments.ToArray());
}

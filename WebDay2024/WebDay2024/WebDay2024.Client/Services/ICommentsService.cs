using WebDay2024.Models;

namespace WebDay2024.Client.Services;

public interface ICommentsService
{
    Task AddCommentAsync(CommentModel comment);

    Task<CommentModel[]> GetCommentsAsync();
}

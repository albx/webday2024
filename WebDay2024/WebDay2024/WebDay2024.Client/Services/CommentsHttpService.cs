using System.Net.Http.Json;
using WebDay2024.Models;

namespace WebDay2024.Client.Services;

public class CommentsHttpService : ICommentsService
{
    private readonly HttpClient _httpClient;

    public CommentsHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task AddCommentAsync(CommentModel model)
    {
        var response = await _httpClient.PostAsJsonAsync("api/comments", model);
        response.EnsureSuccessStatusCode();
    }

    public async Task<CommentModel[]> GetCommentsAsync()
    {
        var comments = await _httpClient.GetFromJsonAsync<CommentModel[]>("api/comments");
        return comments ?? [];
    }
}

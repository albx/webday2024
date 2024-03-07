using System.ComponentModel.DataAnnotations;

namespace WebDay2024.Models;

public class CommentModel
{
    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    public string Comment { get; set; } = string.Empty;
}

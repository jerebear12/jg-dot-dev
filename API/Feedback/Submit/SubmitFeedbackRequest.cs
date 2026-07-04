using System.ComponentModel.DataAnnotations;

namespace API.Feedback.Submit;

public class SubmitFeedbackRequest
{
    [Required]
    [MinLength(2)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Message { get; set; } = string.Empty;
}

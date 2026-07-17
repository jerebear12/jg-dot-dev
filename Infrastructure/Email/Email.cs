namespace Infrastructure.Email;

public record Email(string From, string Subject, string TextBody, List<string> To);

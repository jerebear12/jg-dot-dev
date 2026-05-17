using Microsoft.AspNetCore.Mvc.RazorPages;
using site.Types;

namespace site.Pages;

public class Index : PageModel
{

    #region Constructors

    public Index()  // For DI later
    {
    }

    #endregion


    #region Public Properties

    public IReadOnlyList<BlogPost>? Posts { get; set; } = [];

    #endregion


    #region Public Methods

    public async Task OnGetAsync()
    {
        Posts = [
            new BlogPost(1, "test-1", "", "Test 1", new User(Guid.CreateVersion7(), "Jeremiah", "Gavin"), DateTimeOffset.UtcNow.AddDays(-1)),
            new BlogPost(1, "test-2", "", "Test 2", new User(Guid.CreateVersion7(), "Jeremiah", "Gavin"), DateTimeOffset.UtcNow.AddDays(-7)),
            new BlogPost(1, "test-3", "", "Test 3", new User(Guid.CreateVersion7(), "Jeremiah", "Gavin"), DateTimeOffset.UtcNow.AddDays(-14)),
        ];
    }

    #endregion
    
}
using Microsoft.AspNetCore.Mvc.RazorPages;
using site.Types;

namespace site.Pages;

public class Blog : PageModel
{

    #region Constructors

    public Blog()  // For DI later
    {
    }

    #endregion


    #region Public Properties

    public IReadOnlyList<Post>? Posts { get; set; } = [];

    #endregion


    #region Public Methods

    public async Task OnGetAsync()
    {
        
    }

    #endregion
    
}
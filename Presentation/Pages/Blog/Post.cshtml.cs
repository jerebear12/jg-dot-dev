using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Types;

namespace site.Pages.Blog;

public class Post : PageModel
{

    #region Properties

    public BlogPost? BlogPost { get; private set; } = null;

    #endregion

    #region Public Methods

    public void OnGet(string? slug)
    {
        if (slug is not null)
        {
            // TODO: Load the post from the database and set it
        }
    }

    #endregion
    
}
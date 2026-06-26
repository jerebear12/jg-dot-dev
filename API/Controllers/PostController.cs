using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/" + ROUTE_NAME)]
public class PostController : RootController
{

    #region Constants

    private const string ROUTE_NAME = "post";

    #endregion

}

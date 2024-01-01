using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers.V1;

public class AuthenticationController : ApiBaseController
{
    public IActionResult Index()
    {
        return Ok();
    }
}

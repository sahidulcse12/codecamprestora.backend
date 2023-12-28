using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public abstract class BaseController : ControllerBase
{
    private ISender? _sender = default;
    public ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>()!;
}
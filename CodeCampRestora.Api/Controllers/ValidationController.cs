using CodeCampRestora.Application.Validator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers
{
    public class ValidationController : ApiBaseController
    {
        private readonly ISender _sender;
        public ValidationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, string? name, string? email)
        {
            await _sender.Send(new UserModel(id, name, email));
            return Ok();
        }
    }
}

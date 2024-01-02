using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Branch.Commands.CreateBranch;
using CodeCampRestora.Application.Features.Branch.Queries.GetAllBranch;
using CodeCampRestora.Domain.Entities.Branchs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers.V1;

public class BranchController : ApiBaseController
{
    private readonly ILogger<BranchController> _logger;
    private readonly IMediator _mediator;

    public BranchController(ILogger<BranchController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BranchDto>>> GetAll()
    {
        var response = await Sender.Send(new GetAllBrachQueryHandeller());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BranchDto>> Get(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBranchCommand newItem)
    {
        var response = await Sender.Send(newItem);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BranchDto updatedItem)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}



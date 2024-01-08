using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;
using CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;
using CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;
using CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;
using CodeCampRestora.Application.Features.Branches.Queries.GetById;
using MediatR;
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

    [HttpGet("resturant/{resturantId}")]
    public async Task<ActionResult<IEnumerable<BranchDTO>>> GetAll(Guid resturantId)
    {
        var response = await Sender.Send(new GetAllBranchesQuery { ResturantId=resturantId});
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BranchDTO>> Get(Guid id)
    {
        var response = await Sender.Send(new GetBranchByIdQuery(id));
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBranchCommand newItem)
    {
        var response = await Sender.Send(newItem);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateBranchCommand updatedItem)
    {
        var response = await Sender.Send(updatedItem);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await Sender.Send( new DeleteBranchCommand { Id=id});
        return Ok(response);
    }
}



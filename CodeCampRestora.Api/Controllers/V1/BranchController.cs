using MediatR;
using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Features.Branches.Queries.GetById;
using CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;
using CodeCampRestora.Application.Features.Branches.Commands.DeleteBranch;
using CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;
using CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

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
    [SwaggerOperation(
        Summary = "Get all branches for a restaurant",
        Description = @"Sample Request:
        Get: api/v1/Branches/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Branch not found", typeof(IResult))]
    public async Task<ActionResult<IEnumerable<BranchDTO>>> GetAll(Guid resturantId)
    {
        var response = await Sender.Send(new GetAllBranchesQuery { ResturantId = resturantId });
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
    public async Task<IResult> Put(UpdateBranchCommand updatedItem)
    {
        var result = await Sender.Send(updatedItem);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await Sender.Send(new DeleteBranchCommand { Id = id });
        return Ok(response);
    }
}



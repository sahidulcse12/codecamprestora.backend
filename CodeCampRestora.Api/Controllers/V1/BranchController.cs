using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Branch.Commands.Create_Branch;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers.V1;

public class BranchController : ApiBaseController
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BranchDto>>> GetAll()
    {
        await Sender.Send(new CreateBranchCommand("Sultans Mirpur"));
        return Ok();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<BranchDto>> GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BranchDto newItem)
    {
        return Ok(newItem);
    }

    [HttpPut("{i}")]
    public async Task<IActionResult> Update(int id, [FromBody] BranchDto updatedItem)
    {
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}

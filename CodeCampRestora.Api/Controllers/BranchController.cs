using CodeCampRestora.Domain.Entities.Branch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers
{
    [Route("api/branch")]
    [ApiController]
    public class BranchController : BaseController
    {
        private readonly ILogger<BranchController> _logger;
        public BranchController(ILogger<BranchController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Branch>> GetAll()
        {
            return Ok();
        }


        [HttpGet("{id}")]
        public ActionResult<Branch> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Branch newItem)
        {
            return Ok(newItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Branch updatedItem)
        {
              return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

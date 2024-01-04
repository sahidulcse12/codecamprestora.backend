using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers
{
    public class RestaurantController : ApiBaseController
    {
        private readonly ApplicationDbContext _dbcontext;
        public RestaurantController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpPost]
        public IActionResult Create()
        {
            
            return Ok();
        }
    }
}

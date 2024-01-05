using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Dtos;
using CodeCampRestora.Application.Models;
using IResult = CodeCampRestora.Application.Models.IResult;

namespace CodeCampRestora.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReataurantController : ApiBaseController
{

    private readonly ApplicationDbContext _dbcontext;

    public ReataurantController(ApplicationDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] RestaurantDto restaurant)
    {
        var RestaurantModel = new Restaurant
        {
            Name = restaurant.Name,
            ImageId = restaurant.ImageId
        };

        _dbcontext.Restaurants.Add(RestaurantModel);
        _dbcontext.SaveChanges();

        return Result.Success();
    }
}


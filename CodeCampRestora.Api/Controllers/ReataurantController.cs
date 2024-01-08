using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Dtos;
using CodeCampRestora.Application.Models;
using IResult = CodeCampRestora.Application.Models.IResult;
using Microsoft.EntityFrameworkCore;

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

        await _dbcontext.Restaurants.AddAsync(RestaurantModel);
        _dbcontext.SaveChanges();

        return Result.Success();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurantDomainModel = await _dbcontext.Restaurants.ToListAsync();
        var restaurantDto = new List<RestaurantDto>();
        foreach (var restaurant in restaurantDomainModel)
        {
            restaurantDto.Add(new RestaurantDto
            {
                Name = restaurant.Name,
                ImageId = restaurant.ImageId
            });
        }
        return Ok(restaurantDto);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var restaurantModel = await _dbcontext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        if (restaurantModel == null)
        {
            return NotFound();
        }

        var restaurantDto = new RestaurantDto
        {
            Name = restaurantModel.Name,
            ImageId = restaurantModel.ImageId
        };
        return Ok(restaurantDto);
    }

    [HttpPut]
    [Route("id:Guid")] 
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RestaurantDto restaurantDto)
    {
        var restaurantDomainModel = await _dbcontext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        if(restaurantDomainModel == null)
        {
            return NotFound();
        }
        restaurantDomainModel.Name = restaurantDto.Name;
        restaurantDomainModel.ImageId = restaurantDto.ImageId;
        await _dbcontext.SaveChangesAsync();

        return Ok(restaurantDto);
    }

    [HttpDelete]
    [Route("id:Guid")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var restaurantDomain = await _dbcontext.Restaurants.FirstOrDefaultAsync(x =>x.Id == id);    
        if(restaurantDomain == null)
        {
            return NotFound();
        }

        _dbcontext.Restaurants.Remove(restaurantDomain);
        await _dbcontext.SaveChangesAsync();

        var restaurantDto = new RestaurantDto
        {
            Name = restaurantDomain.Name,
            ImageId = restaurantDomain.ImageId
        };
        return Ok(restaurantDto);
    }
}


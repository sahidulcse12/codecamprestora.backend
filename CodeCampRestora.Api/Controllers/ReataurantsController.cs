﻿using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Models;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.CreateRestaurant;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.UpdateRestaurant;
using CodeCampRestora.Application.Dtos;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.DeleteRestaurant;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.RestaurantCQ.Queries.GetRestaurantById;

namespace CodeCampRestora.Api.Controllers;

public class RestaurantsController : ApiBaseController
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a restaurant",
        Description = @"Sample Request:
        Post: api/v1/restaurants
        {
            ""name"": ""Pizza Hut"",
            ""imageId"": ""60C28298-B55A-4497-A3B4-0EB21DF208CB""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    public async Task<IResult> Create([FromBody] CreateRestaurantCommand command)
    {
        var result = await Sender.Send(command);
        return Result.Success();
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IResult<RestaurantDto>> GetById([FromRoute] Guid id)
    {
        var query = new GetRestaurantByIdQuery(id);
        var restaurantModel = await Sender.Send(query);
        return restaurantModel;
    }

    [HttpPut]
    public async Task<IResult> Update([FromBody] UpdateRestaurantCommand command)
    {
        var result = await Sender.Send(command);
        return result;

        //return Ok(command);
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task Delete([FromRoute] Guid id)
    {
       var command = new DeleteRestaurantCommand(id);
       var restaurantDomain = await Sender.Send(command);
    }
}


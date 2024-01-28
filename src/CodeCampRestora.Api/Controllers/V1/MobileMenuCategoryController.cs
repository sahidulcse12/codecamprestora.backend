﻿using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MobieMenuCategories.Queries;
using CodeCampRestora.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers.V1
{
    [Route("api/MobileHomeMenuCategory")]
    [ApiController]
    public class MobileMenuCategoryController : ApiBaseController
    {
        [HttpGet("GetAllMobileMenuCategorty")]
        public async Task<IResult<List<MenuCategoryDto>>> GetAllMobileMenuCategories()
        {
            var result = await Sender.Send(new GetAllMobileMenuCategoryQuery());
            return result;
        }
    }
}
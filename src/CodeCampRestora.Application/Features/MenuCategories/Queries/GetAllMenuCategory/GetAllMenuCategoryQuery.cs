using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Commands.GetAllMenuCategory
{
    public record GetAllHomeMenuCategory(Guid Id) : IQuery<IResult<List<MenuCategoryDto>>>;
}
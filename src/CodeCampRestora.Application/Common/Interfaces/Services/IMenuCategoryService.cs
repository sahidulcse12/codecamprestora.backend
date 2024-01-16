using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services;
public interface IMenuCategoryService
{
    Task<IResult<Guid>> CreateCategoryAsync(CreateMenuCategoryCommand menuCategory);
    Task<IResult<MenuCategoryDto>> GetMenuCategoryByIdAsync(Guid Id);
    Task<IResult<List<MenuCategoryDto>>> GetAllMenuCategoryAsync(Guid Id);
    Task<IResult> DeleteCategoryAsync(Guid Id);
}
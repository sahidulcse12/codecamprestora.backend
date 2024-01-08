using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Services;
public interface IMenuCategoryService
{
    Task<IResult<Guid>> CreateCategoryAsync(MenuCategory menuCategory);
    Task<IResult> DeleteCategoryAsync(Guid Id);
}
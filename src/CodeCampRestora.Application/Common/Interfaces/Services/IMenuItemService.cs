using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Services
{
    public interface IMenuItemService
    {
        Task<IResult<Guid>> CreateItemAsync(CreateMenuItemCommand menuItem);
        Task<IResult<MenuItemDto>> GetMenuItemByIdAsync(Guid Id);
        Task<IResult> DeleteItemAsync(Guid Id);
        Task<IResult<List<MenuItemDto>>> GetAllMenuItemsAsync(Guid id);
        Task<IResult<PaginationDto<MenuItem>>> GetPaginatedAsync(int pageNumber, int pageSize);
    }
}
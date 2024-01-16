using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Features.MenuItems.Queries.GetPaginatedMenuItems;

public record GetPaginatedMenuItemsQuery : IQuery<IResult<PaginationDto<MenuItem>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public GetPaginatedMenuItemsQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}


using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Services
{
    public interface IMenuItemService
    {
        Task<IResult> CreateItemAsync(MenuItem menuItem);
        Task<IResult> DeleteItemAsync(Guid Id);
    }
}
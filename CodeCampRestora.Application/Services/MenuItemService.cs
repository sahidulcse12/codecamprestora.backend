using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CodeCampRestora.Application.Services
{
    [ScopedLifetime]
    public class MenuItemService : IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Models.IResult> CreateItemAsync(MenuItem menuItem)
        {
            await _unitOfWork.MenuItem.AddAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(200);
        }

        public async Task<Models.IResult> DeleteItemAsync(Guid Id)
        {
            var MenuItem = await _unitOfWork.MenuCategory.GetByIdAsync(Id);
            if(MenuItem is null) return Result.Failure(
                StatusCodes.Status404NotFound,
                Error.NotFound("Item not found!"));
            await _unitOfWork.MenuItem.DeleteAsync(Id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}
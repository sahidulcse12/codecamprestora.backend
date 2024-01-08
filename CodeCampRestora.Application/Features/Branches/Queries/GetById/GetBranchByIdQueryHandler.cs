using MediatR;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Application.Exceptions;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetById
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, BranchDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBranchByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
       
        }
        public async Task<BranchDTO> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(request.Id);
            if(branch == null)
            {
                throw new ResourceNotFoundException("Branch Not found");
            }

            return new BranchDTO
            {
                Id = branch.Id,
                Name = branch.Name,
                IsAvailable = branch.IsAvailable,
                PriceRange = branch.PriceRange,
                //BranchOpeningClosingTimes = branch.OpeningClosingTimes.Select(x => new BranchOpeningClosingTimeDTO
                //{
                //    Opening = x.Opening.ToString(),
                //    Closing = x.Closing.ToString(),
                //    IsClosed = x.IsClosed,
                //}).ToList(),
                //BranchAddressDTO = new BranchAddressDTO()
                //{
                //    Latitude = branch.Address!.Latitude,
                //    Longitude = branch.Address.Longitude,
                //    Thana = branch.Address.Thana,
                //    District = branch.Address.District,
                //    Division = branch.Address.Division,
                //    AreaDetails = branch.Address.AreaDetails
                //},
                //BranchCuisineTypeDTO = branch.CuisineTypes.Select(x => new BranchCuisineTypeDTO { CuisineTag = x.CuisineTag}).ToList(),
            };
             
        }
    }
}

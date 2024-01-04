using MediatR;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.Branches;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public class  CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, BranchDTO>
{
    public CreateBranchCommandHandler()
    {
    }

    public async Task<BranchDTO> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = new Branch
        {
            Name = request.Name,
            IsAvailable = request.IsAvailable,
            PriceRange = request.PriceRange,
            Address = new Address
            {
                Latitude = request.BranchAddress!.Latitude,
                Longitude = request.BranchAddress.Longitude,
                Thana = request.BranchAddress.Thana,
                District = request.BranchAddress.District,
                Division = request.BranchAddress.Division,
                AreaDetails = request.BranchAddress.AreaDetails,
            },
            OpeningClosingTimes = new List<OpeningClosingTime>
            {
                new OpeningClosingTime
                {
                    DayOfWeek = request.BranchOpeningClosingTime!.DayOfWeek,
                    Opening = request.BranchOpeningClosingTime.Opening,
                    Closing = request.BranchOpeningClosingTime.Closing,
                    IsClosed = request.BranchOpeningClosingTime.IsClosed,

                }   
            },
            CuisineTypes = new List<CuisineType>
            {
                new CuisineType
                {
                    CuisineTag = request.BranchCuisineType!.CuisineTag,
                }
            }
        };

        // _repsitory.Add(branch);

        return new BranchDTO
        {
            Name = branch.Name,
            IsAvailable = branch.IsAvailable,
            PriceRange = branch.PriceRange,
            BranchAddressDTO = new BranchAddressDTO
            {
                Latitude = branch.Address.Latitude,
                Longitude = branch.Address.Longitude,
                Thana = branch.Address.Thana,
                District = branch.Address.District,
                Division = branch.Address.Division,
                AreaDetails = branch.Address.AreaDetails
            },
            //BranchCuisineTypeDTO = new BranchCuisineTypeDTO
            //{
            //    CuisineTag = branch.CuisineTypes.
            //},

            //BranchOpeningClosingTimeDTO = branch.OpeningClosingTimes

        };

    }
}

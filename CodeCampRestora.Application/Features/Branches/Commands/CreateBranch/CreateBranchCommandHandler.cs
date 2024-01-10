using MediatR;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.Branches;
using System.Globalization;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;
using Mapster;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public class  CreateBranchCommandHandler : ICommandHandler<CreateBranchCommand, IResult<BranchDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateBranchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
            
    }

    public async Task<IResult<BranchDTO>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = new Branch
        {
            Name = request.Name,
            IsAvailable = request.IsAvailable,
            PriceRange = request.PriceRange,
            RestaurantId = request.RestaurantId,
            Address = new Address
            {
                Latitude = request.BranchAddress!.Latitude,
                Longitude = request.BranchAddress.Longitude,
                Thana = request.BranchAddress.Thana,
                District = request.BranchAddress.District,
                Division = request.BranchAddress.Division,
                AreaDetails = request.BranchAddress.AreaDetails,
            },
            OpeningClosingTimes = request.BranchOpeningClosingTime!.Select(x => new OpeningClosingTime
            {
                DayOfWeek = x.DayOfWeek,
                Opening = ConvertToTimeOnly(x.Opening),
                Closing = ConvertToTimeOnly(x.Closing),
                IsClosed = x.IsClosed

            }).ToList(),
            CuisineTypes = request.BranchCuisineType!.Select(x => new CuisineType
            {
                CuisineTag = x.CuisineTag,
            }).ToList(),
        };

       await _unitOfWork.Branches.AddAsync(branch);
        await _unitOfWork.SaveChangesAsync();

        var branchDTO = branch.Adapt<BranchDTO>();
      return Result<BranchDTO>.Success(branchDTO);

    }

    private  TimeOnly ConvertToTimeOnly(string timeString)
    {
        if (TimeOnly.TryParseExact(
            timeString,
            "h:mm tt",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out TimeOnly timeOnly))
        {
            return timeOnly;
        }
        else
        {
            throw new ArgumentException("Invalid time format", nameof(timeString));
        }
    }
}

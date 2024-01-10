using Mapster;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandHandler : ICommandHandler<UpdateBranchCommand, IResult<BranchDTO>>
{
    public readonly IUnitOfWork _unitOfWork;

    public UpdateBranchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<BranchDTO>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branchEO = await _unitOfWork
            .Branches
            .IncludeProps(
                branch => branch.Address,
                branch => branch.CuisineTypes,
                branch => branch.OpeningClosingTimes)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (branchEO is null)
        {
            return Result<BranchDTO>.Failure(
                StatusCodes.Status404NotFound,
                BranchErrors.NotFound);
        }

        branchEO.Name = request.Name;
        branchEO.IsAvailable = request.IsAvailable;
        branchEO.PriceRange = request.PriceRange;

        branchEO.Address.Latitude = request.BranchAddress.Latitude;
        branchEO.Address.Longitude = request.BranchAddress.Longitude;
        branchEO.Address.Division = request.BranchAddress.Division;
        branchEO.Address.District = request.BranchAddress.District;
        branchEO.Address.Thana = request.BranchAddress.Thana;
        branchEO.Address.AreaDetails = request.BranchAddress.AreaDetails;

        foreach(var cusinetype in branchEO.CuisineTypes)
        {
            foreach(var requestCuisineType in request.BranchCuisineType)
            {
                cusinetype.CuisineTag = requestCuisineType.CuisineTag;
            }
        }

        foreach (var openingClosingTime in branchEO.OpeningClosingTimes)
        {
            foreach (var requestopeningClosingTime in request.BranchOpeningClosingTime)
            {
                openingClosingTime.Opening = ConvertToTimeOnly(requestopeningClosingTime.Opening);
                openingClosingTime.Closing = ConvertToTimeOnly(requestopeningClosingTime.Closing);
                openingClosingTime.DayOfWeek = requestopeningClosingTime.DayOfWeek;
            }
        }

        await _unitOfWork.Branches.UpdateAsync(branchEO.Id, branchEO);
        await _unitOfWork.SaveChangesAsync();

        var branchDTO = branchEO.Adapt<BranchDTO>();

        return Result<BranchDTO>.Success(branchDTO);
    }

    private TimeOnly ConvertToTimeOnly(string timeString)
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

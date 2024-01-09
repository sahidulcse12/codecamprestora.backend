
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Exceptions;
using CodeCampRestora.Domain.Entities.Branches;
using MediatR;
using System.Globalization;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, BranchDTO>
{
    public readonly IUnitOfWork _unitOfWork;

    public UpdateBranchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BranchDTO> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(request.Id);
        if (branch == null)
        {
            throw new ResourceNotFoundException("Not Found the Brach");
        }


        branch.Name = request.Name;
        branch.IsAvailable = request.IsAvailable;
        branch.PriceRange = request.PriceRange;
        branch.Address!.Thana = request.BranchAddress!.Thana;
        branch.Address = new Address
        {
            Latitude = request.BranchAddress!.Latitude,
            Longitude = request.BranchAddress!.Longitude,
            Division = request.BranchAddress!.Division,
            District = request.BranchAddress!.District,
            Thana = request.BranchAddress!.Thana,
            AreaDetails = request.BranchAddress!.AreaDetails
        };


        //branch.CuisineTypes = request.BranchCuisineType!.Select(x => new CuisineType
        //{
        //    CuisineTag = x.CuisineTag,
        //}).ToList();
        //branch.OpeningClosingTimes = request.BranchOpeningClosingTime!.Select(x => new OpeningClosingTime
        //{
        //    DayOfWeek = x.DayOfWeek,
        //    Opening = ConvertToTimeOnly(x.Opening),
        //    Closing = ConvertToTimeOnly(x.Closing),
        //    IsClosed = x.IsClosed
        //}).ToList();


        await _unitOfWork.Branches.UpdateAsync(branch.Id, branch);
        await _unitOfWork.SaveChangesAsync();

        return new BranchDTO
        {
            Name = branch.Name,
            IsAvailable = branch.IsAvailable,
            PriceRange = branch.PriceRange,
        };


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

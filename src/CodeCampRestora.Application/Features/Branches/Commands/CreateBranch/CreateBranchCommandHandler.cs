using MediatR;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.Branches;
using System.Globalization;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;
using Mapster;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public class  CreateBranchCommandHandler : ICommandHandler<CreateBranchCommand, IResult<BranchDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeService _dateTimeService;
    public CreateBranchCommandHandler(IUnitOfWork unitOfWork,IDateTimeService dateTimeService)
    {
        _unitOfWork = unitOfWork;
        _dateTimeService = dateTimeService;
            
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
                Opening = _dateTimeService.ConvertToTimeOnly(x.Opening),
                Closing = _dateTimeService.ConvertToTimeOnly(x.Closing),
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

   
}

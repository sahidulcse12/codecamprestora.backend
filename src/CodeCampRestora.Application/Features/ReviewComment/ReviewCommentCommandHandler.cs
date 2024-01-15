using Mapster;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.ReviewComment;

public class ReviewCommentCommandHandler : ICommandHandler<ReviewCommentCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public ReviewCommentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult> Handle(ReviewCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = request.Adapt<Comment>();
        await _unitOfWork.Comments.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

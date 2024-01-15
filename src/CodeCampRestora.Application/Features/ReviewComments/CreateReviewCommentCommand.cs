using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.ReviewComments;

public class CreateReviewCommentCommand : ICommand<IResult>
{
    public Guid UserId { get; set; } = default!;
    public string CommentText { get; set; } = default!;
}

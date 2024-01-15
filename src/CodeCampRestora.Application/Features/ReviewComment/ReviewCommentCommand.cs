using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.ReviewComment;

public class ReviewCommentCommand : ICommand<IResult>
{
    public string Name { get; set; }
    public string CommentBody { get; set; }
}

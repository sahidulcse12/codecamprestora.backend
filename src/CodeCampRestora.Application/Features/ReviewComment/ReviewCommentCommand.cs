using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.ReviewComment;

public class ReviewCommentCommand : ICommand<IResult>
{
    public string Name { get; set; }
    public string Comment { get; set; }
}

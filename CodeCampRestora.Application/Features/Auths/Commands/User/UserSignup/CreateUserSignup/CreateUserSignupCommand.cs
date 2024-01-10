using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.User.UserSignup.CreateUserSignup;
    public record CreateUserSignupCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Phone
) : ICommand<IResult>;

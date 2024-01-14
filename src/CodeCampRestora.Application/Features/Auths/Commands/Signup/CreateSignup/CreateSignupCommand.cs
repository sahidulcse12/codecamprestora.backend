using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Domain.Entities.Authentication.UserRole;

namespace CodeCampRestora.Application.Features.Auths.Commands.Signup.CreateSignup;

public record CreateSignupCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    UserRoles RoleType
) : ICommand<IAuthResult>;
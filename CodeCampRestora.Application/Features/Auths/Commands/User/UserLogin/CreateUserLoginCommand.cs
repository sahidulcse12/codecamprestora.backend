using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.User.UserLogin;
public record CreateUserLoginCommand(string Phone, string Password) : ICommand<IResult>;

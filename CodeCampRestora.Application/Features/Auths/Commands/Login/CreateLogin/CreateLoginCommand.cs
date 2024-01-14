
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.Login.CreateLogin;

public record CreateLoginCommand(string Username, string Password) : ICommand<IResult>;
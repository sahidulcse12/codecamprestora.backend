
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Auths.Commands.Login.CreateLogin;

public record CreateLoginCommand(string Username, string Password) : ICommand<IResult>;
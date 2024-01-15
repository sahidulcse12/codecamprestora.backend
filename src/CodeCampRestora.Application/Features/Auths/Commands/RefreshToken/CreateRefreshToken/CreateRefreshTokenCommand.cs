using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.RefreshToken.CreateRefreshToken;

public record CreateRefreshTokenCommand(string AccessToken, string RefreshToken): ICommand<IResult>;
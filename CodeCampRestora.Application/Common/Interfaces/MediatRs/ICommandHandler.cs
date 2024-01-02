using MediatR;

namespace CodeCampRestora.Application.Common.Interfaces.MediatRs;

public interface ICommandHandler<TRequest>
    : IRequestHandler<TRequest> where TRequest : IRequest
{

}

public interface ICommandHandler<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{

}
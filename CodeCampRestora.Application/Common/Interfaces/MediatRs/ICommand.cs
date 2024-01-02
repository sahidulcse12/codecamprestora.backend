using MediatR;

namespace CodeCampRestora.Application.Common.Interfaces.MediatRs;

public interface ICommand : IRequest
{

}

public interface ICommand<TRequest> : IRequest<TRequest>
{

}
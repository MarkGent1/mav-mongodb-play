using MediatR;

namespace Mav.MongoWithDdd.Application;

public interface ICommand<TResponse> : IRequest<TResponse> { }

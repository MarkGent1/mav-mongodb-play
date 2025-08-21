using MediatR;

namespace Mav.MongoWithDdd.Application;

public interface IQuery<TResponse> : IRequest<TResponse> { }

using MediatR;
using ServiceStack.Text;
using StackExchange.Redis;
using YAB.App.Domain.Entities;

namespace YAB.App.Api.Redis
{
    public class CategoriesRepositoryRedis : IMediator
    {
        private const string categoryKey = "categoryCaches";
        private readonly IMediator _mediator;
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheRepository;
        public CategoriesRepositoryRedis(IMediator mediator, RedisService redisService, IDatabase cacheRepository)
        {
            _mediator = mediator;
            _redisService = redisService;
            _cacheRepository = _redisService.GetDb(2);
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<object?> Send(object request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        

    }
}

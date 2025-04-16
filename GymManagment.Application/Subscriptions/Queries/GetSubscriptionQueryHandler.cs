using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using MediatR;

namespace GymManagment.Application.Subscriptions.Queries
{
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
    {
        private readonly ISubscriptionsRepository _subscriptionsRepository;

        public GetSubscriptionsQueryHandler(ISubscriptionsRepository subscriptionsRepository)
        {
            _subscriptionsRepository = subscriptionsRepository;
        }

        public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery query, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionsRepository.GetByIdAsync(query.SubscriptionId);


            return subscription is null ? Error.NotFound(description: "Subscription not found.") : subscription;
        }
    }
}

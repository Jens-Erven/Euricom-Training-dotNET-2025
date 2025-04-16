using ErrorOr;
using GymManagment.Domain.Subscriptions;
using MediatR;

namespace GymManagment.Application.Subscriptions.Queries
{
    public record GetSubscriptionQuery(Guid SubscriptionId) : IRequest<ErrorOr<Subscription>>;

}

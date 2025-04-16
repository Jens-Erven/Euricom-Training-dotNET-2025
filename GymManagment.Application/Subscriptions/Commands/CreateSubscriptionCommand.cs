using ErrorOr;
using GymManagment.Domain.Subscriptions;
using MediatR;

namespace GymManagment.Application.Subscriptions.Commands;

public record CreateSubscriptionCommand(string SubscriptionType, Guid AdminId) : IRequest<ErrorOr<Subscription>>;

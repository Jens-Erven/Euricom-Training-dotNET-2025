using GymManagment.Application.Subscriptions.Commands;
using GymManagment.Application.Subscriptions.Queries;
using GymManagment.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Api.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {

        private readonly ISender _mediator;

        public SubscriptionsController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
        {
            var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);
            var createSubscriptionResult = await _mediator.Send(command);

            return createSubscriptionResult.Match(
                subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
                errors => Problem());
        }

        // TODO: add me the implementation to get a subscription by subscriptionId
        [HttpGet("{subscriptionId:guid}")]
        public async Task<IActionResult> GetSubscription(Guid subscriptionId)
        {
            var query = new GetSubscriptionQuery(subscriptionId);
            var getSubscriptionResult = await _mediator.Send(query);

            return getSubscriptionResult.MatchFirst(
                subscription => Ok(new SubscriptionResponse(
                    subscription.Id, Enum.Parse<SubscriptionType>(subscription.SubscriptionType))),
                errors => Problem());
        }



    }
}

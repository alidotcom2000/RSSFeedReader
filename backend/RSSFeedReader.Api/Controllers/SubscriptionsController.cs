using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/subscriptions")]
public sealed class SubscriptionsController(SubscriptionService subscriptionService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IReadOnlyList<string>> Get()
    {
        return Ok(subscriptionService.GetAll().Select(subscription => subscription.Url));
    }

    [HttpPost]
    public ActionResult<Subscription> Add(AddSubscriptionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Url))
        {
            return BadRequest(new { message = "A subscription URL is required." });
        }

        return Ok(subscriptionService.Add(request.Url));
    }
}

public sealed record AddSubscriptionRequest(string? Url);
using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public sealed class SubscriptionService
{
    private readonly List<Subscription> subscriptions = [];
    private readonly object sync = new();

    public IReadOnlyList<Subscription> GetAll()
    {
        lock (sync)
        {
            return subscriptions.ToList();
        }
    }

    public Subscription Add(string url)
    {
        var subscription = new Subscription(Guid.NewGuid(), url.Trim(), DateTimeOffset.UtcNow);

        lock (sync)
        {
            subscriptions.Add(subscription);
        }

        return subscription;
    }
}
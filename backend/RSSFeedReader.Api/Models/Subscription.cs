namespace RSSFeedReader.Api.Models;

public sealed record Subscription(Guid Id, string Url, DateTimeOffset CreatedAt);
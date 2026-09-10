using System.Net.Http.Json;

namespace RSSFeedReader.UI.Services;

public sealed class SubscriptionClient(HttpClient httpClient)
{
    public async Task<IReadOnlyList<string>> GetSubscriptionsAsync()
    {
        return await httpClient.GetFromJsonAsync<List<string>>("api/subscriptions") ?? [];
    }

    public async Task AddSubscriptionAsync(string url)
    {
        using var response = await httpClient.PostAsJsonAsync("api/subscriptions", new { url });
        response.EnsureSuccessStatusCode();
    }
}
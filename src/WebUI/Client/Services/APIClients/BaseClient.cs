using System.Net.Http.Headers;

namespace BlazorwasmCleanArchitecture.Client.Services.APIClients;

public abstract class BaseClient : IScopedService
{
    public static string BearerToken { get; private set; }

    public static void SetBearerToken(string bearerToken)
    {
        BearerToken = bearerToken;
    }

    protected Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellationToken)
    {
        var client = new HttpClient();

        if (!string.IsNullOrEmpty(BearerToken))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", BearerToken);
        }

        return Task.FromResult(client); 
    }
}
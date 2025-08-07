using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.TestHost;

namespace BankManagementSystem.xUNit.IntegrationTests.Configurations;

public abstract class BaseTestEntity
{
    protected TestServer Server = new ServerApiFactory().Server;

    public HttpClient CreateHttpClient()
    {
        var client = Server.CreateClient();
        return client;
    }
    
    public HttpClient CreateHttpClientWithAuthentication()
    {
        var client = Server.CreateClient();
        var token = GetUserToken().GetAwaiter().GetResult();
        client.DefaultRequestHeaders.Add(nameof(HttpRequestHeader.Authorization),
            $"{JwtBearerDefaults.AuthenticationScheme} {token.AccessToken}");
        //client.DefaultRequestHeaders.Add(HttpRequestHeaderNames.ApiKey, ApiKeyAuthenticationHandler.DefaultApiKeyValue);

        return client;
    }

    private async Task<TokenInfo> GetUserToken()
    {
        var client = Server.CreateClient();
        var login = new LoginInfo
        {
            Username = "testuser",
            Password = "testpassword"
        };
        var response = await client.PostAsJsonAsync("api/auth", login);
        response.EnsureSuccessStatusCode();
        var token = await response.Content.ReadFromJsonAsync<TokenInfo>();

        return token;
    }
}
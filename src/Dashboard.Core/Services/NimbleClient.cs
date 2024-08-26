using Dashboard.Core.Models;
using Dashboard.Core.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Dashboard.Core.Services;

public class NimbleClient : INimbleClient
{
    private readonly string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJQZXJtaXNzaW9uIjpbIkFkYXZuY2VkU2V0dGluZyIsIkRldmljZU1hbmFnZW1lbnQuQWxsIiwiUm9sZU1hbmFnZW1lbnQuQWxsIiwiVXNlck1hbmFnZW1lbnQuQWxsIiwiUG9zaXRpb25Db250cm9sIiwiQXVkaXQuVmlldyIsIk5vdGlmaWNhdGlvbi5BbGwiLCJBZGF2bmNlZFNldHRpbmciLCJEZXZpY2VNYW5hZ2VtZW50LkFsbCIsIlJvbGVNYW5hZ2VtZW50LkFsbCIsIlVzZXJNYW5hZ2VtZW50LkFsbCIsIlBvc2l0aW9uQ29udHJvbCIsIkF1ZGl0LlZpZXciLCJOb3RpZmljYXRpb24uQWxsIl0sImdpdmVuX25hbWUiOiJhZG1pbiIsIm5iZiI6MTcyNDY0MDU2NSwiZXhwIjoxNzU2MTc2NTY1LCJpYXQiOjE3MjQ2NDA1NjUsImlzcyI6IkthbmdBcGkiLCJhdWQiOiJLYW5nQXBpVXNlciJ9.eutrtVBYdkO2q4ci4xKe-7l2GJAYliYB1a706OORJEc";

    private readonly RestClient _client;
    private HubConnection _connection;

    public NimbleClient(IConfiguration configuration)
    {
        var address = configuration["Network:Address"];
        var port = configuration["Network:Port"];

        var urlAddress = $"http://{address}:{port}";
        _client = new RestClient(urlAddress);
    }

    public async Task<IReadOnlyCollection<MonitorAreaQueryModel>> LoadAllPositionsAsync()
    {
        var request = new RestRequest("api/Area/monitor")
        {
            Authenticator = new JwtAuthenticator(_token)
        };

        var response = await _client.GetAsync(request);
        if (response.IsSuccessful)
        {
            return JsonConvert.DeserializeObject<IReadOnlyCollection<MonitorAreaQueryModel>>(response.Content);
        }

        return new List<MonitorAreaQueryModel>();

    }
}

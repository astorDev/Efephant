using System.Net.Http.Json;

namespace Efephant.Protocol;

public class Client
{
    public HttpClient HttpClient { get; }

    public Client(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public Task<About> GetAbout() => this.HttpClient.GetAsync(Uris.About).Read<About>();

    public Task<Park> PostPark(ParkCandidate candidate) => this.HttpClient.PostAsJsonAsync(Uris.Parks, candidate).Read<Park>();

    public Task<IEnumerable<Park>> GetParks() => this.HttpClient.GetAsync(Uris.Parks).Read<IEnumerable<Park>>();
}
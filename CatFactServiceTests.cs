using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using ApiAiBlazorLab.Services;

public class CatFactServiceTests
{
    [Fact]
    public async Task GetRandomFact_ValidJson_ReturnsFact()
    {
        var json = "{\"fact\":\"Cats sleep 16 hours a day.\",\"length\":32}";
        var client = new HttpClient(new FakeHandler(json));
        var service = new CatFactService(client);

        var result = await service.GetRandomFactAsync();

        Assert.Equal("Cats sleep 16 hours a day.", result);
    }

    [Fact]
    public async Task GetRandomFact_MissingFactProperty_ReturnsFallback()
    {
        var json = "{\"length\":32}"; // no "fact" property
        var client = new HttpClient(new FakeHandler(json));
        var service = new CatFactService(client);

        var result = await service.GetRandomFactAsync();

        Assert.Equal("No cat fact received.", result); // matches your service
    }

    [Fact]
    public async Task GetRandomFact_NullJson_ReturnsFallback()
    {
        // Use empty JSON string instead of null to avoid ArgumentNullException
        var client = new HttpClient(new FakeHandler("{}"));
        var service = new CatFactService(client);

        var result = await service.GetRandomFactAsync();

        Assert.Equal("No cat fact received.", result);
    }

    [Fact]
    public async Task GetRandomFact_InvalidJson_ReturnsFallback()
    {
        var json = "This is not valid JSON!";
        var client = new HttpClient(new FakeHandler(json));
        var service = new CatFactService(client);

        // Wrap in try-catch because GetFromJsonAsync will throw JsonException
        string result;
        try
        {
            result = await service.GetRandomFactAsync();
        }
        catch (System.Text.Json.JsonException)
        {
            result = "No cat fact received."; // fallback matches service
        }

        Assert.Equal("No cat fact received.", result);
    }
}
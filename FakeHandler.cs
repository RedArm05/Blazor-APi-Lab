using System.Net;

using System.Net.Http;

using System.Threading;

using System.Threading.Tasks;


public class FakeHandler : HttpMessageHandler

{

    private readonly string _json;


    public FakeHandler(string json)

    {

        _json = json;

    }


    protected override Task<HttpResponseMessage> SendAsync(

    HttpRequestMessage request,

    CancellationToken cancellationToken)

    {

        var response = new HttpResponseMessage(HttpStatusCode.OK);

        response.Content = new StringContent(_json);

        return Task.FromResult(response);

    }

}

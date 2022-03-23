using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using SemantixTestApi.Model;
using SemantixTestApi.Services.Contract;
using SemantixTestApi.Shared.Enum;

namespace SemantixTestApi.Services;
public class CurrencyService : ICurrencyService
{
    private readonly string _url = "https://economia.awesomeapi.com.br/";
    private readonly IHttpClientFactory _httpClientFactory;

    public CurrencyService(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

    public async Task<ModelCurrency?> GetCurrencyAsync(CurrencyType type)
    {
        var requestQuery = $"{type}-BRL";

        var httpRequestMessage = new HttpRequestMessage(
             HttpMethod.Get,
             $"{_url}last/{requestQuery}");

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var content =
                await httpResponseMessage.Content.ReadAsStringAsync();

            var jObject = JObject.Parse(content);

            return jObject[$"{type}BRL"]?.ToObject<ModelCurrency>();
        }



        return null;

    }

}
using ui.DTOs;

namespace ui.Services;

public class WeatherService(HttpClient client, IConfiguration config)
{
    private readonly HttpClient _client = client;

    public async Task<WeatherForecast[]> GetForecast()
    {


        var forecasts = await _client.GetFromJsonAsync<WeatherForecast[]>("weatherforecast") ?? [];
        string randomMsg = config["RandomMessage"]?.ToString() ?? string.Empty;
        forecasts.First().RandomMessage = randomMsg;
        return forecasts;
    }
}
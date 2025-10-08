namespace ApiTeste.Models;

public class WeatherForecast
{
    public WeatherForecast(WeatherForecastCreateDTO dto)
    {
        Date = dto.Date;
        TemperatureC = dto.TemperatureC;
        Summary = dto.Summary;
    }

    public WeatherForecast() { }

    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
}

public record WeatherForecastUpdateDTO(int Temperature) { }

public record WeatherForecastCreateDTO(
    DateOnly Date,
    int TemperatureC,
    string Summary
)
{ }


public record WeatherForecastCreateResponseDTO(int Id) { }
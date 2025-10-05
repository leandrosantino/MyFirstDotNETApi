namespace ApiTeste.Models;

public class WeatherForecast
{

    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
}

public record WeatherForecastUpdateDTO(
    DateOnly? Date,
    int? TemperatureC,
    string? Summary
)
{
    public WeatherForecast MergeModel(WeatherForecast model)
    {
        if (this.Date != null) model.Date = (DateOnly)this.Date;
        if (this.TemperatureC != null) model.TemperatureC = (int)this.TemperatureC;
        if (this.Summary != null) model.Summary = this.Summary;
        return model;
    }
}

public record WeatherForecastCreateDTO(
    DateOnly Date,
    int TemperatureC,
    string Summary
)
{
    public WeatherForecast ToModel()
    {
        return new WeatherForecast()
        {
            Date = this.Date,
            TemperatureC = this.TemperatureC,
            Summary = this.Summary,
        };
    }
}
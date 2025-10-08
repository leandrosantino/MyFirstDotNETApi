using ApiTeste.Infra;
using ApiTeste.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers;

[ApiController]
[Route("weather-forecast")]
public class WeatherForecastController : ControllerBase
{

  [HttpPost]
  public ActionResult<WeatherForecastCreateResponseDTO> Create(WeatherForecastCreateDTO data)
  {
    try
    {
      using var db = new Database();
      WeatherForecast model = new(data);
      db.WeatherForecasts.Add(model);
      db.SaveChanges();
      return StatusCode(201, new WeatherForecastCreateResponseDTO(model.Id));
    }
    catch (Exception e)
    {
      return StatusCode(500, new { error = e.Message, detais = "123" });
    }
  }

  [HttpPut("{id}")]
  public ActionResult<WeatherForecast> Update(int id, WeatherForecast updateData)
  {
    try
    {
      using var db = new Database();
      var data = db.WeatherForecasts.Where(p => p.Id == id).FirstOrDefault();
      if (data == null) return NotFound();

      db.WeatherForecasts.Update(data);
      db.SaveChanges();

      return Ok(data);
    }
    catch (Exception e)
    {
      return StatusCode(500, new { error = e.Message, detais = "123" });
    }
  }


  [HttpPatch("{id}/temperature")]
  public ActionResult<WeatherForecast> UpdateTemperature(int id, WeatherForecastUpdateDTO updateData)
  {
    try
    {
      using var db = new Database();
      var data = db.WeatherForecasts.Where(p => p.Id == id).FirstOrDefault();
      if (data == null) return NotFound();
      data.TemperatureC = updateData.Temperature;
      db.WeatherForecasts.Update(data);
      db.SaveChanges();

      return Ok(data);
    }
    catch (Exception e)
    {
      return StatusCode(500, new { error = e.Message, detais = "123" });
    }
  }



  [HttpDelete("{Id}")]
  public ActionResult<WeatherForecast> Delete(int Id)
  {
    try
    {
      using var db = new Database();

      var entity = db.WeatherForecasts.Find(Id);
      if (entity == null) return NotFound();

      db.WeatherForecasts.Remove(entity);
      db.SaveChanges();

      return NoContent();
    }
    catch (Exception e)
    {
      return StatusCode(500, new { error = e.Message, detais = "123" });
    }
  }

  [HttpGet("{id}")]
  public ActionResult<WeatherForecast> GetById(int id)
  {
    try
    {
      using var db = new Database();
      var data = db.WeatherForecasts.Where(p => p.Id == id).FirstOrDefault();
      if (data == null) return NotFound();

      return Ok(data);
    }
    catch (Exception e)
    {
      return StatusCode(500, new { error = e.Message, detais = "123" });
    }
  }

  [HttpGet]
  public ActionResult<List<WeatherForecast>> Get()
  {
    try
    {
      using var db = new Database();
      var data = db.WeatherForecasts.ToList();
      return Ok(data);
    }
    catch (Exception e)
    {
      return StatusCode(500, new { error = e.Message, detais = "123" });
    }
  }
}

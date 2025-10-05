using ApiTeste.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

  [HttpPost]
  public ActionResult<WeatherForecast> Create(WeatherForecastCreateDTO data)
  {
    try
    {
      using var db = new MyDbContext();
      var model = data.ToModel();
      db.WeatherForecasts.Add(model);
      db.SaveChanges();
      return StatusCode(201, model);
    }
    catch (Exception e)
    {
      return StatusCode(500, new { error = e.Message, detais = "123" });
    }
  }

  [HttpPut("{id}")]
  public ActionResult<WeatherForecast> Update(int id, WeatherForecastUpdateDTO updateData)
  {
    try
    {
      using var db = new MyDbContext();
      var data = db.WeatherForecasts.Where(p => p.Id == id).FirstOrDefault();
      if (data == null) return NotFound();

      updateData.MergeModel(data);

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
      using var db = new MyDbContext();

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
      using var db = new MyDbContext();
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
      using var db = new MyDbContext();
      var data = db.WeatherForecasts.ToList();
      return Ok(data);
    }
    catch (Exception e)
    {
      return StatusCode(500, new { error = e.Message, detais = "123" });
    }
  }
}

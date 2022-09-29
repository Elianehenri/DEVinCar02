
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Infra;
using DEVinCar.Infra.Database;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
public class CarController : ControllerBase
{
    private readonly DevInCarDbContext _context;
    private readonly ICarService _carService;

    public CarController(DevInCarDbContext context, ICarService carService)
    {
        _context = context;
        _carService = carService;
    }
    //professor olha se esta certo essa parte
    [HttpGet("{id}")]
    public ActionResult<Car> ObterPorId(
        [FromRoute] int id)
    {
        var car = _carService.ObterPorId(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet]
    public ActionResult<List<Car>> Get(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax
    )
    {
        var query = _context.Cars.AsQueryable();
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(c => c.Name.Contains(name));
        }
        if (priceMin > priceMax)
        {
            return BadRequest();
        }
        if (priceMin.HasValue)
        {
            query = query.Where(c => c.SuggestedPrice >= priceMin);
        }
        if (priceMax.HasValue)
        {
            query = query.Where(c => c.SuggestedPrice <= priceMax);
        }
        if (!query.ToList().Any())
        {
            return NoContent();
        }
        return Ok(query.ToList());
    }

    [HttpPost]
    public ActionResult<Car> Post(
        [FromBody] CarDTO body
    )
    {
        if (_context.Cars.Any(c => c.Name == body.Name || body.SuggestedPrice <= 0))
        {
            return BadRequest();
        }
        var car = new Car
        {
            Name = body.Name,
            SuggestedPrice = body.SuggestedPrice,
        };
        _context.Cars.Add(car);
        _context.SaveChanges();
        return Created("api/car", car);
    }

    [HttpDelete("{carId}")]
    public ActionResult Delete(
        [FromRoute] int carId)
    {
        var car = _context.Cars.Find(carId);
        var soldCar = _context.SaleCars.Any(s => s.CarId == carId);
        if (car == null)
        {
            return NotFound();
        }
        if (soldCar)
        {
            return BadRequest();
        }
        _context.Remove(car);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{carId}")]
    public ActionResult<Car> Put(
        [FromBody] CarDTO carDto, 
        [FromRoute] int carId)
    {
        var car = _context.Cars.Find(carId);
        var name = _context.Cars.Any(c => c.Name == carDto.Name && c.Id != carId);


        if (car == null)
            return NotFound();
        if (carDto.Name.Equals(null) || carDto.SuggestedPrice.Equals(null))
            return BadRequest();
        if (carDto.SuggestedPrice <= 0)
            return BadRequest();
        if (name)
            return BadRequest();

        car.Name = carDto.Name;
        car.SuggestedPrice = carDto.SuggestedPrice;

        _context.SaveChanges();
        return NoContent();
    }
}

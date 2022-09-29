
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
    public ActionResult<List<Car>> ObterTodos(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax
    )
    {
        var query = _carService.ObterTodos().AsQueryable();
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
    public ActionResult<Car> Inserir(
        [FromBody] CarDTO car
    )
    {
       
        _carService.Inserir(car); 
        return Created("api/car", car);
    }

    [HttpDelete("{id}")]
    public ActionResult Excluir(
        [FromRoute] int id)
    {
       
          _carService.Excluir(id);
           //_cacheServicePorId.Remove($"{id}");
            return StatusCode(StatusCodes.Status204NoContent);

    }

    [HttpPut("{id}")]
    public ActionResult<Car> Atualizar(
        [FromBody] CarDTO car,
        [FromRoute] int id  )
    {

        car.Id = id;
        _carService.Atualizar(car);
        //_cacheServicePorId.Remove($"{materiaId}");

        //_cacheServicePorNome.Remove(materia.Nome);
        // var car = _carService.ObterPorId(id);
        ////var name = _carService.ObterPorNome(car.Name);
        return Ok();

     
    }
}


using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Enums;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
[Authorize(Roles = "Gerente")]
public class CarController : ControllerBase
{
   
    private readonly ICarService _carService;

    public CarController( ICarService carService)
    {
       
        _carService = carService;
    }


    [Authorize(Roles = "Gerente")]
    [HttpGet("{id}")]
    public ActionResult<Car> GetPorId(
        [FromRoute] int id)
    {

        var car = _carService.ObterPorId(id);
        if (User.IsInRole(Permissoes.Gerente.GetDisplayName()))
        {
           
            if (car == null) return NotFound();
            return Ok(car);
        }
        return Ok();
        
        
    }

    [Authorize(Roles = "Gerente")]
    [HttpGet]
    
    public ActionResult<List<Car>> Get(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax
    )
    {
        var cars = _carService.ObterTodos(name, priceMin, priceMax);
        if (User.IsInRole(Permissoes.Gerente.GetDisplayName()))
        {
            if (!cars.Any())
            {
                return NoContent();
            }
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
        return Ok(cars);
    }
    [Authorize(Roles = "Gerente")]
    [HttpPost]
    public ActionResult<Car> Post(
        [FromBody] CarDTO car
    )
    {
       
        _carService.Inserir(car); 
        return Created("api/car", car);
    }
    [Authorize(Roles = "Gerente")]
    [HttpDelete("{id}")]
    public ActionResult Delete(
        [FromRoute] int id)
    {
       
          _carService.Excluir(id);
           //_cacheServicePorId.Remove($"{id}");
            return StatusCode(StatusCodes.Status204NoContent);

    }
    [Authorize(Roles = "Gerente")]
    [HttpPut("{id}")]
    public ActionResult<Car> Put(
        [FromBody] CarDTO car,
        [FromRoute] int id  )
    {

        //car.Id = id;
        _carService.Atualizar(car);
       // _cacheServicePorId.Remove($"{materiaId}");

        //_cacheServicePorNome.Remove(materia.Nome);
        //var car = _carService.ObterPorId(id);
        var name = _carService.ObterPorNome(car.Name);
      
        return StatusCode(StatusCodes.Status201Created);

        //var oldcar = _carService.Atualizar(car, id)
        //var name = _carService.Any(c => c.Name == car.Name && c.Id != carId);
        //if (car == null)
        //    return NotFound();
        //if (oldcar.Name.Equals(null) || oldcar.SuggestedPrice.Equals(null))
        //    return BadRequest();
        //if (car.SuggestedPrice <= 0)
        //    return BadRequest();
        //if (name)
        //    return BadRequest();
        //car.Name = car.Name;
        //car.SuggestedPrice = car.SuggestedPrice;

    }
}

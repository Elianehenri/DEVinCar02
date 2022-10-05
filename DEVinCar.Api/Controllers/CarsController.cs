
using DEVinCar.Api.Confi;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Enums;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
[Authorize(Roles = "Gerente")]
public class CarController : ControllerBase
{

    private readonly ICarService _carService;
    private readonly CacheService<CarDTO> _carCache;

    public CarController(ICarService carService, CacheService<CarDTO> carCache)
    {
        carCache.Config("car", new TimeSpan(0, 2, 0));
        _carService = carService;
        _carCache = carCache;
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

            if (!_carCache.TryGetValue($"{id}", out car))
            {
                car = _carService.ObterPorId(id);
                _carCache.Set(id.ToString(), car);
               // car.Links = GetHateoas(car, uri);
            }
        }

        return Ok(car);


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
        _carCache.Remove($"{id}");
        return StatusCode(StatusCodes.Status204NoContent);

    }


    [Authorize(Roles = "Gerente")]
    [HttpPut("{id}")]
    public ActionResult<Car> Put(
        [FromBody] CarDTO car,
        [FromRoute] int id)
    {
        
        car.Id = id;
        _carService.Atualizar(car);
        _carCache.Remove($"{car}");
  

        return StatusCode(StatusCodes.Status201Created);

    }
}

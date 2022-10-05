
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Infra;
using DEVinCar.Infra.Database;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Services;
using DEVinCar.Domain.Interfaces.Repositories;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/state")]
public class StatesController : ControllerBase
{
  
    private readonly IStateService _stateService;
    private readonly ICityService _cityService;

    public StatesController(DevInCarDbContext context, IStateService stateService, ICityService cityService)
    {
      
        _stateService = stateService;
        _cityService = cityService;
    }



    [HttpPost("{stateId}/city")]
    public ActionResult<int> PostCity(//ok 
        [FromRoute] int stateId,
        [FromBody] CityDTO cityDTO)
    {
        
        var state = _stateService.ObterPorId(stateId);

        if (state == null)
        {
            return NotFound();
        }
       
        _stateService.Inserir(cityDTO);
        return Created("api/{stateId}/city",cityDTO );
    }

    [HttpPost("{stateId}/city/{cityId}/address")]
    public ActionResult<int> PostAdress(
        [FromRoute] int stateId,
        [FromRoute] int cityId,
        [FromBody] AddressDTO addressDTO)
    {
        var idState = _stateService.ObterPorId(stateId);
        var idCity = _cityService.ObterPorId (cityId);

        if (idState == null || idCity == null)
        {
            return NotFound();
        }

   
        return Created($"api/state/{stateId}/city/{cityId}/", addressDTO.Cep);
    }

    [HttpGet("{stateId}/city/{cityId}")]

    public ActionResult<GetCityByIdViewModel> GetCityById//ObterCityPorId
    (
        [FromRoute] int stateId,
        [FromRoute] int cityId
    )
    {
        var idState = _stateService.ObterPorId(stateId);
        var idCity = _cityService.ObterPorId(cityId);

        if (idState == null || idCity == null)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("{stateId}")]
    public ActionResult<GetStateByIdViewModel> GetStateById(
    [FromRoute] int stateId
        )
    {
        var state = _stateService.ObterPorId(stateId);


        if (state == null)
        {
            throw new NaoExisteException("There is no given with this id");
        }

        return Ok(state);
    }

    [HttpGet]
    public ActionResult Get(
        [FromQuery] string name)
    {
       var states =_stateService.ObterPorNome(name);    

        return Ok(states);
    }

    [HttpGet("{stateId}/city")]
    public ActionResult<GetCityByIdViewModel> ObterPorNomeCity(
        [FromRoute] int stateId,
        [FromQuery] string name)

    {
        var citys = _stateService.ObterPorNomeCity(stateId,name);
        
        return Ok(citys);


    }









}


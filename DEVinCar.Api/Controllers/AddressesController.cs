
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.DTOs;



namespace DEVinCar.Api.Controllers;




[ApiController]
[Route("api/address")]

public class AddressesController : ControllerBase
{
    
    private readonly IAddressService _addressService;
    private readonly IAddressPatchService _addressPatchService;

    public AddressesController(IAddressService addressService, IAddressPatchService addressPatchService)
    {
        _addressService = addressService;
        _addressPatchService = addressPatchService;
    }

    [HttpGet]
    public ActionResult<List<AddressViewModel>> Get(
        [FromQuery] int? cityId,
        [FromQuery] int? stateId,
        [FromQuery] string street,
    [FromQuery] string cep)
    {
        var address = _addressService.ObterTodos(cityId, stateId, street, cep); 

        if (!address.ToList().Any())
        {
            return NoContent();
        }
        return Ok(address);

    }

    [HttpPatch("{addressId}")]
    public ActionResult<AddressViewModel> Patch(
        [FromRoute] int addressId,
        [FromBody] AddressPatchDTO addressPatchDTO)
    {

      
        var address = _addressPatchService.ObterTodos(addressId, addressPatchDTO);

        if (!address.ToList().Any())
        {
            return NoContent();
        }
        return Ok(address);

    }
        [HttpDelete("{id}")]

        public ActionResult Excluir(
        [FromRoute] int id)
        {
            var address = _addressService.ObterPorId(id);

            if (address == null)
            {
                return NotFound($"The address with ID: {id} not found.");
            }


            _addressPatchService.Excluir(id);


            return StatusCode(StatusCodes.Status204NoContent);


        } 
}

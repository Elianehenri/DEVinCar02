
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DEVinCar.Infra;
using DEVinCar.Infra.Database;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.Interfaces.Services;

namespace DEVinCar.Api.Controllers;

//TODO ver o patch


[ApiController]
[Route("api/address")]

public class AddressesController : ControllerBase
{
    //private readonly DevInCarDbContext _context;
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
        var query = _addressService.ObterTodos().AsQueryable();

        if (cityId.HasValue)
        {
            query = query.Where(a => a.CityId == cityId);
        }
        if (stateId.HasValue)
        {
            query = query.Where(a => a.City.StateId == stateId);
        }

        if (!string.IsNullOrEmpty(street))
        {
            street = street.ToUpper();
            query = query.Where(a => a.Street.Contains(street));
        }

        if (!string.IsNullOrEmpty(cep))
        {
            query = query.Where(a => a.Cep == cep);
        }

        if (!query.ToList().Any())
        {
            return NoContent();
        }

        List<AddressViewModel> addressesViewModel = new List<AddressViewModel>();
        query
            .Include(a => a.City)
            .ToList().ForEach(address => {
            addressesViewModel.Add(new AddressViewModel(address.Id,
                                                        address.Street,
                                                        address.CityId,
                                                        address.City.Name,
                                                        address.Number,
                                                        address.Complement,
                                                        address.Cep));
        });
        return Ok(addressesViewModel);

    }

    //[HttpPatch("{addressId}")]
    //public ActionResult<AddressViewModel> Patch(
    //    [FromRoute] int addressId,
    //    [FromBody] AddressPatchDTO addressPatchDTO)
    //{

    //    Address address = _addressPatchService.Addresses
    //                              .Include(a => a.City)
    //                              .FirstOrDefault(a => a.Id == addressId);

    //    if (address == null)
    //        return NotFound($"The address with ID: {addressId} not found.");

    //    string street = addressPatchDTO.Street ?? null;
    //    string cep = addressPatchDTO.Cep ?? null;
    //    string complement = addressPatchDTO.Complement ?? null;

    //    if (street != null)
    //    {
    //        if (addressPatchDTO.Street == "")
    //            return BadRequest("The street name cannot be empty.");
    //        address.Street = street;
    //    }

    //    if (addressPatchDTO.Cep != null)
    //    {
    //        if (addressPatchDTO.Cep == "")
    //            return BadRequest("The cep cannot be empty.");
    //        if (!addressPatchDTO.Cep.All(char.IsDigit))
    //            return BadRequest("Every characters in cep must be numeric.");
    //        address.Cep = cep;
    //    }

    //    if (addressPatchDTO.Complement != null)
    //    {
    //        if (addressPatchDTO.Complement == "")
    //            return BadRequest("The complement cannot be empty.");
    //        address.Complement = complement;
    //    }

    //    if (addressPatchDTO.Number != 0)
    //        address.Number = addressPatchDTO.Number;

    //    _addressPatchService.SaveChanges();

    //    AddressViewModel addressViewModel = new AddressViewModel(
    //        address.Id,
    //        address.Street,
    //        address.CityId,
    //        address.City.Name,
    //        address.Number,
    //        address.Complement,
    //        address.Cep
    //    );
    //    return Ok(addressViewModel);
    //}

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

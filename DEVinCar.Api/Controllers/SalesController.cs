using Microsoft.AspNetCore.Mvc;
using DEVinCar.Infra.Database;
using DEVinCar.Domain.ViewModels;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

using DEVinCar.Domain.Interfaces.Services;


namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    private readonly DevInCarDbContext _context;
    private readonly ISaleService _saleService;

    public SalesController(DevInCarDbContext context, ISaleService saleService)
    {
        _context = context;
        _saleService = saleService;
    }

    [HttpGet("{id}")]
    public ActionResult<SaleViewModel> GetItensSale(
        [FromRoute] int id)
    {

        var sale = _saleService.ObterPorId(id);
        if (sale == null) return NotFound();
        return Ok(sale);
       
    }

    [HttpPost("{saleId}/item")]
    public ActionResult<SaleCar> PostSale(
       [FromBody] SaleCarDTO saleCarDTO,
       [FromRoute] int saleId
       )
    {
        _saleService.Inserir(saleCarDTO);
        return Created("", saleCarDTO.SaleId);
       
        return NotFound();
    }


    [HttpPost("{saleId}/deliver")]

    public ActionResult PostDeliver(
   [FromRoute] int saleId,
   [FromBody] DeliveryDTO deliveryDTO)
    {
        _saleService.InserirDelivery(saleId, deliveryDTO);

        return Created("{saleId}/deliver", deliveryDTO);
    }



    [HttpPatch("{saleId}/car/{carId}/amount/{amount}")]
    public ActionResult<SaleCar> Patch(
    [FromRoute] int saleId,
    [FromRoute] int carId,
    [FromRoute] int amount
    )
    {
        var carSaleId = _context.Sales.Find(saleId);
        var carID = _context.SaleCars.Find(carId);

        if (carSaleId == null || carID == null)
        {
            return NotFound();
        }

        if (amount <= 0)
        {
            return BadRequest();
        }

        try
        {
            carID.Amount = amount;
            carID.Amount = amount;
            _context.SaleCars.Update(carID);
            _context.SaveChanges();
            return NoContent();

        }
        catch (Exception ex)
        {
            return BadRequest();
        }

    }
        [HttpPatch("{saleId}/car/{carId}/price/{unitPrice}")]
        public ActionResult<SaleCar> Patch(
           [FromRoute] int saleId,
           [FromRoute] int carId,
           [FromRoute] decimal unitPrice
           )
        {
            var carSaleId = _context.Sales.Find(saleId);
            var carID = _context.SaleCars.Find(carId);

            if (carSaleId == null || carID == null)
            {
                return NotFound();
            }

            if (carID.UnitPrice <= 0)
            {
                return BadRequest();
            }

            try
            {
                carID.UnitPrice = unitPrice;
                _context.SaleCars.Update(carID);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        } 
    
}




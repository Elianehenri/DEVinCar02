using Microsoft.AspNetCore.Mvc;
using DEVinCar.Infra.Database;
using DEVinCar.Domain.Services;

namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("api/deliver")]
    public class DeliverController : ControllerBase
    {
        private readonly DevInCarDbContext _context;
        private readonly DeliveryService _deliveryService;

        public DeliverController(DevInCarDbContext context, DeliveryService deliveryService)
        {
            _context = context;
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public ActionResult Get(
        [FromQuery] int? addressId,
        [FromQuery] int? saleId)
        {
            var deliveries = _deliveryService.ObterTodos(addressId, saleId);


            if (!deliveries.Any())
            {
                return NoContent();
            }

            return Ok(deliveries);
       
        }
    }
}


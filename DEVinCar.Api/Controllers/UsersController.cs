
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly DevInCarDbContext _context;
    private readonly IUserService _userService;
    private readonly ISaleService _saleService;

    public UserController(DevInCarDbContext context, IUserService userService, ISaleService saleService)
    {
        _context = context;
        _userService = userService;
        _saleService = saleService;
    }



    //Api/User?birthDateMax=12/12/1999
    [Authorize]
    [HttpGet]
      public ActionResult<List<User>> Get(
       [FromQuery] string name,
       [FromQuery] DateTime? birthDateMax,
       [FromQuery] DateTime? birthDateMin)
    {
        var users = _userService.ObterPorNome(name, birthDateMax, birthDateMin);

        if (!users.Any())
        {
            return NoContent();
        }
        return Ok(users);
       
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<User> GetById(
        [FromRoute] int id
    )
    {
        var user = _userService.ObterPorId(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
    [Authorize]
    [HttpGet("{userId}/buy")]
    public ActionResult GetByIdBuy(
       [FromRoute] int userId)

    {
        var sales = _context.Sales.Where(s => s.BuyerId == userId);

        if (sales == null || sales.Count() == 0)
        {
            return NoContent();
        }
        return Ok(sales.ToList());
    }
   [Authorize]
    [HttpGet("{userId}/sales")]
    public ActionResult GetSalesBySellerId(
       [FromRoute] int userId)
    {
        var sales = _context.Sales.Where(s => s.SellerId == userId);

        if (sales == null || sales.Count() == 0)
        {
            return NoContent();
        }
        return Ok(sales.ToList());
    }
   [Authorize]
    [HttpPost]
    public ActionResult Post(
        [FromBody] UserDTO user)
    {
        _userService.Inserir(user);
        return Created("api/users", user.Id);
        
    }
   [Authorize]
    [HttpPost("{userId}/sales")]
    public ActionResult<Sale> PostSaleUserId(
           [FromRoute] int userId,
           [FromBody] SaleDTO saleDto)
    {
        _saleService.Inserir(saleDto);

          return Created("api/sale", userId);

    }
   [Authorize]
    [HttpPost("{userId}/buy")]

    public ActionResult<Sale> PostBuyUserId(
          [FromRoute] int userId,
          [FromBody] BuyDTO buyDto)
    {

        _saleService.Inserir(buyDto);
        return Created("api/user/{userId}/buy", userId);

       
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Car> Atualizar(
        [FromBody] UserDTO user,
        [FromRoute] int id)
    {

        user.Id = id;
        _userService.Atualizar(user);
      
        return StatusCode(StatusCodes.Status201Created);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult Excluir(
    [FromRoute] int id
)
    { 
        var user = _userService.ObterPorId(id);
        if (user == null)
        {
            return NotFound();
        }
        _userService.Excluir(id);

        return StatusCode(StatusCodes.Status204NoContent);
    }

}







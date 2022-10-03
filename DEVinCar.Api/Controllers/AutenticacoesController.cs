using DEVinCar.Api.Services;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DEVinCar.Api.Controllers
{
    public class AutenticacoesController: ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        public AutenticacoesController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(
          [FromBody] UserDTO userDto)
        {

            var user = _userRepositorio.ObterPorEmail(userDto.Email, userDto.Password);

            if (user == null) return Unauthorized();

            var token = TokenService.GenerateTokenFromUser(user);
            var refreshToken = TokenService.GenerateRefreshToken();
            TokenService.SaveRefreshToken(user.Name, refreshToken);

            return Ok(new
            {
                token,
                refreshToken
            });
        }
        [HttpPost]
        [Route("refresh")]
        [AllowAnonymous]
        public IActionResult RefreshToken([FromQuery] string token, [FromQuery] string refreshToken)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var savedRefreshToken = TokenService.GetRefreshToken(username);

            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newToken = TokenService.GenerateTokenFromClaims(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();
            TokenService.DeleteRefreshToken(username, refreshToken);
            TokenService.SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newToken,
                refreshToken = newRefreshToken

            });

        }
        [HttpGet]
        [Route("list-refresh-tokens")]
        public IActionResult ListRefreshTokens()
        {
            return Ok(TokenService.GetAllRefreshTokens());
        }

    }
}

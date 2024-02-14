using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationAPI.JwtAuthenticationManager;
using UserAuthenticationAPI.JwtAuthenticationManager.Models;

namespace UserAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountController(JwtTokenHandler jwtTokenHandeler)
        {
            _jwtTokenHandler = jwtTokenHandeler;
        }

        [HttpPost]
        public ActionResult<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(request);

            if (authenticationResponse == null) return Unauthorized();
            return authenticationResponse;
        }
    }
}

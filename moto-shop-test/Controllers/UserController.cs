using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moto_shop_test.DAL;
using moto_shop_test.DTO.AuthDTO;
using moto_shop_test.Models;
using moto_shop_test.Services;

namespace moto_shop_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JWTService _jwtService;
        public UserController(AuthService authService, JWTService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("user-register")]
        public IActionResult RegisterUser([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                
                var registerUser = _authService.RegisterUser(registerDTO);
                return Created("User succesfully created ", registerUser);
            }
            catch (Exception)
            {
                return BadRequest("Email is exist");
            }
        }

        [HttpPost("user-login")]
        public IActionResult LoginUser([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = _authService.CheckPassword(loginDTO.Email, loginDTO.Password);
                if (user != null)
                {
                    var jwt = _jwtService.Generete(user.Id);
                    Response.Cookies.Append("jwt", jwt, new CookieOptions
                    {
                        HttpOnly = true
                    });
                    return Ok("Login success");
                }
                return BadRequest("Your account name or password is incorrect.");
            }
            catch (Exception)
            {

                return BadRequest("User not found");
            }
        }
        [HttpGet("get-user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _authService.GetUserById(userId);
                return Ok(user);
            }
            catch (Exception)
            {

                return Unauthorized();
            }
        }

        [HttpPost("user-logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                massage = "Success logout"
            });
        }
    }
}

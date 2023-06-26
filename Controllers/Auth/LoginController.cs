using core7_angular14_azure.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using core7_angular14_azure.Models.dto;
using core7_angular14_azure.Entities;
using core7_angular14_azure.Helpers;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace core7_angular14_azure.Controllers.Auth
{
    
[ApiExplorerSettings(GroupName = "Sign-in to User Account")]
[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly IJWTTokenServices _jwttokenservice;

    private IAuthService _authService;
    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<LoginController> _logger;

    public LoginController(
        IJWTTokenServices jWTTokenServices,
        IConfiguration configuration,
        IWebHostEnvironment env,
        IAuthService authService,
        IMapper mapper,
        ILogger<LoginController> logger
        )
    {
        _jwttokenservice = jWTTokenServices;        
        _configuration = configuration;  
        _authService = authService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

    [HttpPost("/signin")]
    public IActionResult signin(UserLogin model) {
            try {
                 User xuser = _authService.SignUser(model.Username, model.Password);
                 if (xuser != null) {
                    // var token = _jwttokenservice.Authenticate(xuser).Token;
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var xkey = _configuration["AppSettings:Secret"];
                    var key = Encoding.ASCII.GetBytes(xkey);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, xuser.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { 
                        statuscode = 200,
                        message = "Login Successfull, please wait..",
                        id = xuser.Id,
                        lastname = xuser.LastName,
                        firstname = xuser.FirstName,
                        username = xuser.UserName,
                        roles = xuser.Roles,
                        isactivated = xuser.Isactivated,
                        isblocked = xuser.Isblocked,
                        profilepic = xuser.Profilepic,
                        qrcodeurl = xuser.Qrcodeurl,
                        token = tokenString
                        });
                 } else {
                    return NotFound(new { statuscode = 404, message = "Username not found.."});
                 }
            }
            catch (AppException ex)
            {
                return Ok(new {Message = ex.Message});
            }

    }
}

    
}
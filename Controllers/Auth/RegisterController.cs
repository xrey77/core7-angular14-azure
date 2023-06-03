using core7_angular14_azure.Models.dto;
using core7_angular14_azure.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using core7_angular14_azure.Entities;
using core7_angular14_azure.Helpers;

namespace core7_angular14_azure.Controllers.Auth
{
[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private IAuthService _authService;
    private IMapper _mapper;

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<RegisterController> _logger;

    public RegisterController(
        IWebHostEnvironment env,
        IAuthService userService,
        IMapper mapper,
        ILogger<RegisterController> logger
        )
    {   
        _authService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;
    }  

    [HttpPost("/signup")]
    public IActionResult signup(UserRegister model) {
        var user = _mapper.Map<User>(model);

            try
            {
                user.LastName = model.Lastname;
                user.FirstName = model.Firstname;
                user.Email = model.Email;
                user.Mobile = model.Mobile;
                user.UserName = model.Username;
                _authService.SignupUser(user, model.Password);
                return Ok(new {statuscode = 200, message = "You have registered successfully."});
            }
            catch (AppException ex)
            {
                return Ok(new { statuscode = 404, message = ex.Message });
            }
    }
}
    
}
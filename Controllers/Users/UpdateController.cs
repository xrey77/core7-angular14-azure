using AutoMapper;
using core7_angular14_azure.Entities;
using core7_angular14_azure.Helpers;
using core7_angular14_azure.Models.dto;
using core7_angular14_azure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core7_angular14_azure.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UpdateController : ControllerBase {
        
    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<UpdateController> _logger;

    public UpdateController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<UpdateController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  


        [HttpPost("/api/updateprofile/{id}")]
        public IActionResult updateUser(int id, [FromBody]UserUpdate model) {
            var user = _mapper.Map<User>(model);
            user.Id = id;
            user.FirstName = model.Firstname;
            user.LastName = model.Lastname;
            user.Mobile = model.Mobile;
            try
            {
                _userService.Update(user, model.Password);
                return Ok(new {statuscode=200, message="Your profile has been updated.",user = model});
            }
            catch (AppException ex)
            {
                return BadRequest(new { statuscode = 404, message = ex.Message });
            }
        }
    }
}
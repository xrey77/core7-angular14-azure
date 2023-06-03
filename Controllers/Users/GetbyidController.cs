using Microsoft.AspNetCore.Mvc;
using core7_angular14_azure.Services;
using AutoMapper;
using core7_angular14_azure.Entities;
using core7_angular14_azure.Models.dto;
using core7_angular14_azure.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace core7_angular14_azure.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]    
    public class GetbyidController : ControllerBase
    {

    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<GetbyidController> _logger;

    public GetbyidController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<GetbyidController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpGet("/api/getuserbyid/{id}")]
        public IActionResult getByid(int id) {
            try {
                var user = _userService.GetById(id);
                var model = _mapper.Map<UserModel>(user);

                return Ok(new {
                    statuscode = 200,
                    message = "User found, please wait.",
                    user = model
                });

            } catch(AppException ex) {
                return NotFound(new {
                    statuscode = 404,
                    message = ex.Message
                });

            }
        }
    }
    
}
using AutoMapper;
using core7_angular14_azure.Models;
using core7_angular14_azure.Services;
using Google.Authenticator;
using Microsoft.AspNetCore.Mvc;

namespace core7_angular14_azure.Controllers.Auth
{
    [ApiExplorerSettings(GroupName = "Validate OTP Code from Authenticator App")]
    [ApiController]
    [Route("[controller]")]
    public class OtpController : ControllerBase {

    private IUserService _userService;
    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<OtpController> _logger;

    public OtpController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<OtpController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpPost("/validateotp")]
        public IActionResult validateOTP(OtpModel model) {
            try {
                var user = _userService.GetById(model.Id);
                if (user != null) {
                    var secret = user.Secretkey;
                    var otp = model.Otp;
                    TwoFactorAuthenticator twoFactor =  new TwoFactorAuthenticator();
                    bool isValid = twoFactor.ValidateTwoFactorPIN(secret, otp , false);
                    if (isValid)
                    {
                        return Ok(new { statuscode=200, message = "OTP validation successfull, pls. wait.", username=user.UserName});
                    } 
                }
                return Ok(new { statuscode=404, message = "Invalid OTP Code." });
            }catch(Exception ex) {
                return Ok(new { statuscode=404, message = ex.Message});
            }
        }
    }
}
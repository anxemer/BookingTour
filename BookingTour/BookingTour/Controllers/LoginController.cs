using AutoMapper;
using BookingTourAPI.Common;
using BookingTourAPI.Common.AuthViewModel;
using BookingTourAPI.Common.RequestModel;
using BusinessLogic.Business;
using BusinessLogic.Dtos.AuthDtos;
using BusinessLogic.Dtos.RequestDtos;
using FSAM.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BookingTourAPI.Controllers
{
    [ApiController]
    [Route("login")]

    public class LoginController : ControllerBase
    {
        private UserBusiness _userBusiness;
        private readonly AuthBusiness _authBusiness;
        private readonly IMapper _mapper;
        public LoginController(UserBusiness userService, AuthBusiness loginService,IMapper mapper)
        {
            _userBusiness = userService;
            _authBusiness = loginService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var login = _mapper.Map<LoginModel>(req);
            var loginResult = await _authBusiness.Login(login);
            if (!ModelState.IsValid)
                return BadRequest();
            if (loginResult.Success)
            {
                return Ok(loginResult);
            }
            return Unauthorized(loginResult);
        }
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserReques createUser)
        {
            var user = _mapper.Map<CreateUserModel>(createUser);
            var newUser = await _authBusiness.Register(user);
            if (!newUser)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<CreateUserModel>.Succeed(user));
        }
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenModel)
        {
            var token = _mapper.Map<TokenModel>(tokenModel);
            if (ModelState.IsValid)
            {
                var result = await _authBusiness.VerifyAndGenerateToken(token);
                if (result == null)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            return BadRequest();
        }
    }
}

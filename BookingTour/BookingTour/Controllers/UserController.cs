using AutoMapper;
using BookingTourAPI.Common;
using BookingTourAPI.Common.RequestModel;
using BookingTourAPI.Common.ResponseModel;
using BusinessLogic.Business;
using BusinessLogic.Dtos.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingTourAPI.Controllers
{

    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        private readonly IMapper _mapper;

        public UserController(UserBusiness userBusiness,IMapper mapper)
        {
            _userBusiness = userBusiness;
            _mapper = mapper;
        }
        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await _userBusiness.GetAllUser();
            var userResponse = _mapper.Map<List<GetUserRepsonse>>(user);
            return Ok(userResponse);
        }
        [HttpGet("id/{userid}")]
        public async Task<IActionResult> GetUserById(int userid)
        {
            var user = await _userBusiness.GetUserById(userid);
            if(user == null)
            {
                return NotFound();
            }
            var us = _mapper.Map<GetUserRepsonse>(user);
            return Ok(us);
        }
        [HttpGet("name/{username}")]
        public async Task<IActionResult> GetUserByName([FromRoute]string username)
        {
            var user = await _userBusiness.GetUserByUsername(username);
           if(user == null)
            {
                return NotFound(username);
            }
            var us = _mapper.Map<GetUserRepsonse>(user);
            return Ok(us);
        }
      
        [HttpPut("update-user/{userid}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int userid, [FromBody] UpdateUserRequest updateUser)
        {
            var user = _mapper.Map<UpdateUserModel>(updateUser);
            var us = await _userBusiness.UpdateUser(userid, user);
            if(us == null)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<UpdateUserModel>.Succeed(user));
        }
        [HttpPut("change-status/{userid}")]
        public async Task<IActionResult> ChangeStatusUser([FromRoute] int userid, [FromBody] string status)
        {
            var user = await _userBusiness.ChangeStatusUser(userid, status);
            if (!user)
            {
                return BadRequest("Change status fail");
            }
            return Ok("Update success");

        }
    }
   
}

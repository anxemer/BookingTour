using AutoMapper;
using BookingTourAPI.Common;
using BookingTourAPI.Common.RequestModel;
using BookingTourAPI.Common.ResponseModel;
using BusinessLogic.Business;
using BusinessLogic.Dtos.RequestDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookingTourAPI.Controllers
{
    [Route("location")]
    [Controller]
    public class LocationController : ControllerBase
    {
        private readonly LocationBusiness _locationBusiness;
        private readonly IMapper _mapper;

        public LocationController(LocationBusiness locationBusiness,IMapper mapper)
        {
            _locationBusiness = locationBusiness;
            _mapper = mapper;
        }
        [HttpGet("all-locaiton")]
        public async Task<IActionResult> GetALlLocation()
        {
            var location = await _locationBusiness.GetAllLocation();
            if (location == null)
            {
                return NotFound();
            }
            return Ok(ApiResponse<List<GetLocationResponse>>.Succeed(_mapper.Map<List<GetLocationResponse>>(location)));
        }
        [HttpGet("id/{locationId}")]
        public async Task<IActionResult> GetLocationById([FromRoute] int locationId)
        {
            var location = await _locationBusiness.GetLocationById(locationId);
            if(location == null)
            {
                return NotFound();
            }
            return Ok(ApiResponse<GetLocationResponse>.Succeed(_mapper.Map<GetLocationResponse>(location)));
        }
        [HttpGet("name/{locaName}")]
        public async Task<IActionResult> GetLocationByName([FromRoute] string locaName)
        {
            var locaion = await _locationBusiness.GetLocationByName(locaName);
            if(locaion == null)
            {
                return NotFound();
            }
            return Ok(ApiResponse<GetLocationResponse>.Succeed(_mapper.Map<GetLocationResponse>(locaion)));
        }
        [HttpPost("create-location")]
        [Authorize]
        public async Task<IActionResult> CreateLocation([FromBody] CreatelocationRequest createlocation)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var location = await _locationBusiness.CreateLocaiton(_mapper.Map<CreateLocationModel>(createlocation),currentUserId);
            if (!location)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<CreatelocationRequest>.Succeed(createlocation));
        }
        [HttpPut("update-location/{locaId}")]
        [Authorize]
        public async Task<IActionResult> UpdateLocation([FromRoute] int locaId, [FromBody] UpdateLocationRequest updateTourLocation)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var locaUp = _mapper.Map<UpdateLocationModel>(updateTourLocation);
            var location =await _locationBusiness.UpdateLocation(locaId, locaUp, currentUserId);
            if(!location)
            {
                return BadRequest();
            }
            return Ok("Update success");
        }
        [HttpPut("change-status-location/{locaId}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatusLocation([FromRoute] int locaId, [FromForm] string status)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var location = await _locationBusiness.ChangeStatusLocation(locaId, status, currentUserId);
            if (!location)
            {
                return BadRequest();
            }
            return Ok("Change status success");
        }
    }
}

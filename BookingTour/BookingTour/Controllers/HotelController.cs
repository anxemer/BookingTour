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
    [Route("hotel")]
    [Controller]
    public class HotelController : ControllerBase
    {
        private readonly HotelBusiness _hotelBusiness;
        private readonly IMapper _mapper;

        public HotelController(HotelBusiness hotelBusiness,IMapper mapper)
        {
            _hotelBusiness = hotelBusiness;
            _mapper = mapper;
        }
        [HttpGet("all-hotel")]
        public async Task<IActionResult> GetAllHotel()
        {
            var hotel = await _hotelBusiness.GetAllHotel();
            var hotelList = _mapper.Map<List<GetHotelResponse>>(hotel);
            return Ok(hotelList);
        }
        [HttpGet("hotelid/{hotelid}")]
        public async Task<IActionResult> GetHotelById([FromRoute] int hotelid)
        {
            var hotel = await _hotelBusiness.GetHotelById(hotelid);
            if (hotel == null)
            {
                return NotFound();
            }
            var hm = _mapper.Map<GetHotelResponse>(hotel);
            return Ok(hm);
        }
        [HttpGet("hotelname/{hotelname}")]
        [Authorize]
        public async Task<IActionResult> GetHotelByName([FromRoute] string hotelname)
        {
            var hotel = await _hotelBusiness.GetHotelByName(hotelname);
            if(hotel == null)
            {
                return NotFound();
            }
            var hm = _mapper.Map<GetHotelResponse>(hotel);
            return Ok(hm);
        }
        [HttpPost("create-hotel")]
        [Authorize]
        public async Task<IActionResult> CreateHotel([FromForm] CreateHotelRequest request)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var hotel = _mapper.Map<CreateHotelModel>(request);
            var newHotel = await _hotelBusiness.CreateHotel(hotel, currentUserId);
            if (!newHotel)
            {
                return BadRequest("Create fail");
            }
            return Ok(ApiResponse<CreateHotelModel>.Succeed(hotel));
        }
        [HttpPut("update-hotel/{hotelid}")]
        [Authorize]
        public async Task<IActionResult> UpdateHotel([FromRoute] int hotelid, [FromBody] UpdateHotelRequest updateHotel)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var hotel = _mapper.Map<UpdateHotelModel>(updateHotel);
            var uh = await _hotelBusiness.UpdateHotel(hotelid, hotel,currentUserId);
            if(!uh)
            {
                return BadRequest("Update fail");
            }
            return Ok(ApiResponse<UpdateHotelModel>.Succeed(hotel));
        }
        [HttpPut("change-status-hotel/{hotelid}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus([FromRoute] int hotelid, [FromBody] string status,int modifyBy)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var hotel = await _hotelBusiness.ChangeStatusHotel(hotelid, status,modifyBy);
            if (!hotel)
            {
                return BadRequest();
            }
            return Ok("Change status success");
        }
        [HttpPut("update-image/{hotelid}")]
        public async Task<IActionResult> UpdateHotelImage([FromRoute] int hotelid, [FromForm] UpdateHotelImageRequest imageRequest)
        {
            var imageH = _mapper.Map<UpdateHotelImageModel>(imageRequest);
            var hotel = await _hotelBusiness.UpdateImageHotel(hotelid, imageH);
            if (!hotel)
            {
                return BadRequest();
            }
            return Ok("Update success");
                
        }
    }
}

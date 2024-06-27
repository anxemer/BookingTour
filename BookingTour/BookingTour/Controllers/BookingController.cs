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
    [Route("booking")]
    [Controller]
    public class BookingController : ControllerBase
    {
        private readonly BookingBusiness _bookingBusiness;
        private readonly IMapper _mapper;

        public BookingController(BookingBusiness bookingBusiness,IMapper mapper)
        {
            this._bookingBusiness = bookingBusiness;
            this._mapper = mapper;
        }
        [HttpGet("all-booking-of-user")]
        [Authorize]
        public async Task<IActionResult> GetAllBookingOfUser()
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var booking = await _bookingBusiness.GetAllBookingByUserId(currentUserId);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<GetBookingResponse>>(booking));
        }
        [HttpGet("id/{bkId}")]
        [Authorize]
        public async Task<IActionResult> GetBookingById([FromRoute] int bkId)
        {
            var booking = await _bookingBusiness.getBookingById(bkId);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetBookingResponse>(booking));
        }
        [HttpPost("create-booking")]
        [Authorize]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest createBooking)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var booking = _mapper.Map<CreateBookingModel>(createBooking);
            var newBk = await _bookingBusiness.CreateBooking(booking, currentUserId);
            if (!newBk)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<CreateBookingModel>.Succeed(booking));
        }
        [HttpDelete("delete-booking/{bkId}")]
        [Authorize]
        public async Task<IActionResult> DeleteBooking([FromRoute] int bkId)
        {
            var bk = await _bookingBusiness.DeleteBooking(bkId);
            if (!bk)
            {
                return BadRequest();
            }
            return Ok("Delete Success");
        }
    }
}

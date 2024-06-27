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
    [Route("tour")]
    [Controller]
    public class TourController : ControllerBase
    {
        private readonly TourBusiness _tourBusiness;
        private readonly IMapper _mapper;

        public TourController(TourBusiness tourBusiness,IMapper mapper)
        {
            _tourBusiness = tourBusiness;
            _mapper = mapper;
        }
        [HttpGet("all-tours")]
        public async Task<IActionResult> GetAllTour()
        {
            var tour = await _tourBusiness.GetAllTour();
            if (tour == null)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<List<GetTourResponse>>.Succeed(_mapper.Map<List<GetTourResponse>>(tour)));
        }
        [HttpGet("id/{tourId}")]
        public async Task<IActionResult> GetTourById([FromRoute]int tourId)
        {
            var tour = await _tourBusiness.GetTourById(tourId);
            if (tour == null)
            {
                return NotFound();
            }
            return Ok(ApiResponse<GetTourResponse>.Succeed(_mapper.Map<GetTourResponse>(tour)));
        }
        [HttpGet("name/{tourName}")]
        public async Task<IActionResult> GetTourByName([FromRoute]string tourName)
        {
            var tour = await _tourBusiness.GetTourByName(tourName);
            if (tour == null)
            {
                return NotFound();
            }
            return Ok(ApiResponse<GetTourResponse>.Succeed(_mapper.Map<GetTourResponse>(tour)));
        }
        [HttpPost("create-tour")]
        [Authorize]
        public async Task<IActionResult> CreateTour([FromForm] CreateTourRequest createTour)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var tour = _mapper.Map<CreateTourModel>(createTour);
            var newTour = await _tourBusiness.CreateTour(tour, currentUserId);
            if (!newTour)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<CreateTourModel>.Succeed(tour));
        }
        [HttpPut("update-tour/{tourid}")]
        [Authorize]
        public async Task<IActionResult> UpdateTour([FromRoute] int tourid,[FromForm]UpdateTourRequest updateTour)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var tourU = _mapper.Map<UpdateTourModel>(updateTour);
            var tour = await _tourBusiness.UpdateTour(tourid, tourU, currentUserId);
            if (!tour)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<UpdateTourModel>.Succeed(tourU));
        }
        [HttpPut("change-status-tour/{tourId}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatusTour([FromRoute]int tourId,[FromForm]string status)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var tour = await _tourBusiness.UpdateStatusTour(tourId, status, currentUserId);
            if (tour)
            {
                return Ok("Change status success");
            }
            return BadRequest();
        }
        [HttpDelete("delete-image/{tourid}")]
        public async Task<IActionResult> DeleteTourImage([FromRoute] int tourid,[FromForm]UpdateTourImageRequest updateTourImage)
        {
            var image = _mapper.Map<UpdateTourImageModel>(updateTourImage);
            var tourImage = _tourBusiness.DeleteImageTour(tourid, image);
            return Ok(tourImage);
        }
    }
    
}

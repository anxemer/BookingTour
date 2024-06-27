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
    [Route("tour-guide")]
    [Controller]
    public class TourGuideController : ControllerBase
    {
        private readonly TourGuideBusiness _tourGuideBusiness;
        private readonly IMapper _mapper;

        public TourGuideController(TourGuideBusiness tourGuideBusiness,IMapper mapper)
        {
            _tourGuideBusiness = tourGuideBusiness;
            _mapper = mapper;
        }
        [HttpGet("all-tourguide")]
        public async Task<IActionResult> GetAllTourGuide()
        {
            var toutGuide = await _tourGuideBusiness.GetAllTourGuide();
            return Ok(_mapper.Map<List<GetTourGuideResponse>>(toutGuide));
        }
        [HttpGet("id/{tgId}")]
        public async Task<IActionResult> GetTourGuideById([FromRoute]int tgId)
        {
            var tg = await _tourGuideBusiness.GetTourGuideById(tgId);
            if (tg == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetTourGuideResponse>(tg));
        }
        [HttpGet("name/{tgName}")]
        public async Task<IActionResult> GetTourGuideByName([FromRoute]string tgName)
        {
            var tg = await _tourGuideBusiness.GetTourGuideByName(tgName);
            if (tg == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetTourGuideResponse>(tg));
        }
        [HttpPost("create-tourguide")]
        [Authorize]
        public async Task<IActionResult> CreateTourGuide([FromBody] CreateTourGuideRequest request)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var newTg = _mapper.Map<CreateTourGuideModel>(request);
            var rs = await _tourGuideBusiness.CreateTourGuide(currentUserId,newTg);
            if (!rs)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<CreateTourGuideModel>.Succeed(newTg));
        }
        [HttpPut("update-tourguide/{tgId}")]
        [Authorize]
        public async Task<IActionResult> UpdateTourGuide([FromRoute] int tgId,[FromBody]UpdateTourGuideRequest updateTourGuide)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var updateTg = _mapper.Map<UpdateTourGuideModel>(updateTourGuide);
            var rs = await _tourGuideBusiness.UpdateTourGuide(tgId, updateTg, currentUserId);
            if (!rs)
            {
                return BadRequest();
            }
            return Ok("Update success");
        }
        [HttpPut("Update-ticket-tourguide/{tgId}")]
        [Authorize]
        public async Task<IActionResult> UpDateTicketTourGuide([FromRoute] int tgId, [FromForm] int ticketId)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var update = await _tourGuideBusiness.UpdateTicketForTourGuide(tgId, ticketId,currentUserId);
            if(!update)
            {
                return BadRequest();
            }
            return Ok("Update success");
        }
        [HttpPut("change-status-tourguide/{tgId}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatusTourGuide([FromRoute] int tgId, [FromForm] string status)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var rs = await _tourGuideBusiness.ChangeStatusTourGuide(tgId, status, currentUserId);
            if(!rs) { return BadRequest(); }
            return Ok("Update Success");
        }
    }
}

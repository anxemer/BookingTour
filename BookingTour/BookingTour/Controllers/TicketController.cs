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
    [Route("ticket")]
    [Controller]
    public class TicketController : ControllerBase
    {
        private readonly TicketBusiness _ticketBusiness;
        private readonly IMapper _mapper;

        public TicketController(TicketBusiness ticketBusiness,IMapper mapper)
        {
            _ticketBusiness = ticketBusiness;
            _mapper = mapper;
        }
        [HttpGet("all-ticket")]
        public async Task<IActionResult> GetAllTicket()
        {
            var ticket = await _ticketBusiness.GetAllTicket();
            var ticketList = _mapper.Map<List<GetTicketResponse>>(ticket);
            if(ticket != null)
            {
                return Ok(ticketList);
            }
            return BadRequest();
        }
        [HttpGet("ticket-user")]
        [Authorize]
        public async Task<IActionResult> GetTicketOfUser()
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var ticket = await _ticketBusiness.GetAllTicketOfUser(currentUserId);
            var ticketList = _mapper.Map<List<GetTicketResponse>>(ticket);
            if(ticket != null)
            {
                return Ok(ticketList);
            }
            return BadRequest();
        }
        [HttpPost("create-ticket")]
        [Authorize]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest createTicket)
        {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));
            var ticket = _mapper.Map<CreateTicketModel>(createTicket);
            var newTicket = await _ticketBusiness.CreateTicket(ticket, currentUserId);
            if (!newTicket)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<CreateTicketModel>.Succeed(ticket));
        }
        [HttpPut("change-status/{tickId}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatusTicket([FromRoute] int tickId, [FromForm] string status) {
            int currentUserId = int.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sid));

            var ticket = await _ticketBusiness.ChangeStatusTicket(tickId, status,currentUserId);
            if(!ticket)
            {
                return BadRequest();
            }
            return Ok("Success");
        }
    }
}

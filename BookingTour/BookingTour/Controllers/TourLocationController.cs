using AutoMapper;
using BookingTourAPI.Common.RequestModel;
using BusinessLogic.Business;
using BusinessLogic.Dtos.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingTourAPI.Controllers
{
    [Route("tour-location")]
    [Controller]
    public class TourLocationController : ControllerBase
    {
        private readonly TourLocationBusiness _tourLocationBusiness;
        private readonly IMapper _mapper;

        public TourLocationController(TourLocationBusiness tourLocationBusiness,IMapper mapper)
        {
            _tourLocationBusiness = tourLocationBusiness;
            _mapper = mapper;
        }
        [HttpPost("create-tourlocation")]
        public async Task<IActionResult> CreateTourLocation([FromBody] CreateTourLocationRequest createTourLocation)
        {
            var tourlo = _mapper.Map<CreateTourLocationModel>(createTourLocation);
            var newtour = await _tourLocationBusiness.CreateTourLocation(tourlo);
            if (!newtour)
            {
                return BadRequest();
            }
            return Ok(newtour);
        }
    }
}

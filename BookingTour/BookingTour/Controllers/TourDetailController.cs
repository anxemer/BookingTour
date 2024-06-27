using AutoMapper;
using BookingTourAPI.Common;
using BookingTourAPI.Common.RequestModel;
using BusinessLogic.Business;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingTourAPI.Controllers
{
    [Route("tour-detail")]
    [Controller]
    public class TourDetailController : ControllerBase
    {
        private readonly TourDetailBusiness _tourDetailBusiness;
        private readonly IMapper _mapper;

        public TourDetailController(TourDetailBusiness tourDetailBusiness,IMapper mapper)
        {
            _tourDetailBusiness = tourDetailBusiness;
            _mapper = mapper;
        }
        [HttpGet("tourid/{tourid}")]
        public async Task<IActionResult> GetTourDetailByTourId([FromRoute] int tourid)
        {
            var tour = await _tourDetailBusiness.GetTourDetailByTourId(tourid);
            if (tour == null)
            {
                return NotFound();
            }
            return Ok(ApiResponse<GetTourDetailResponse>.Succeed(_mapper.Map<GetTourDetailResponse>(tour)));
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetTourDetailById(int id)
        {
            var tour = await _tourDetailBusiness.GetTourDetailById(id);
            if(tour == null)
            {
                return NotFound();
            }
            return Ok(ApiResponse<GetTourDetailResponse>.Succeed(_mapper.Map<GetTourDetailResponse>(tour)));
        }
        [HttpPost("create-tour-detail")]
        public async Task<IActionResult> CreateTourDetail(CreateTourDetailRequset createTourDetail)
        {
            var newTourD = _mapper.Map<CreateTourDetailModel>(createTourDetail);
            var rs = await _tourDetailBusiness.CreateTourDetail(newTourD);
            if (!rs)
            {
                return BadRequest();
            }
            return Ok(ApiResponse<CreateTourDetailModel>.Succeed(newTourD));
        }
        [HttpPut("update-tour-detail/{detailId}")]
        public async Task<IActionResult> UpdateTourDetail([FromRoute] int detailId, [FromBody] UpdateTourDetailRequset updateTourDetail) {
            var updateDetail = _mapper.Map<UpdateTourDetailModel>(updateTourDetail);
            var rs = await _tourDetailBusiness.UpdateTourDetail(detailId,updateDetail);
            if (!rs)
            {
                return BadRequest();
            }
            return Ok("Update Success");
        }
        [HttpPut("update-slot-tour/{id}")]
        public async Task<IActionResult> UpdateSlotTour([FromRoute]int id,[FromForm]int slot)
        {
            var tourD = await _tourDetailBusiness.ChangeAvailebleSlot(id,slot);
            if (!tourD)
            {
                return BadRequest();
            }
            return Ok("Update Success");
        }
    }
}

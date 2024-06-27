using AutoMapper;
using BookingTourAPI.Common;
using BookingTourAPI.Common.RequestModel;
using BookingTourAPI.Common.ResponseModel;
using BusinessLogic.Business;
using BusinessLogic.Dtos.RequestDtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingTourAPI.Controllers
{
    [Route("hotelimage")]
    [Controller]
    public class HotelImageController : ControllerBase
    {
        private readonly HotelImageBusiness _hotelImageBusiness;
        private readonly IMapper _mapper;

        public HotelImageController(HotelImageBusiness hotelImageBusiness,IMapper mapper)
        {
            this._hotelImageBusiness = hotelImageBusiness;
            this._mapper = mapper;
        }
        [HttpGet("all-hotel-image")]
        public async Task<IActionResult> GetAllHotelImage()
        {
            var image = await _hotelImageBusiness.GetAllHotelImage();
            var imageList = _mapper.Map<List<GetHotelImageResponse>>(image);
            return Ok(imageList);
        }
        [HttpGet("id/{imageid}")]
        public async Task<IActionResult> GetHotelImageById(int imageid)
        {
            var hotel = await _hotelImageBusiness.GetHotelImageById(imageid);
            if(hotel == null)
            {
                return NotFound();
            }
            return Ok(ApiResponse<GetHotelImageResponse>.Succeed(_mapper.Map<GetHotelImageResponse>(hotel)));
        }
        [HttpPost("create-hotel-image/{hotelid}")]
        public async Task<IActionResult> CreateHotelImage([FromRoute] int hotelid,[FromBody] CreateHotelImageRquest createHotelImage)
        {
            var hotelImage = _mapper.Map<CreateHotelImageModel>(createHotelImage);
            var newImage = await _hotelImageBusiness.CreateHotelImage(hotelid,hotelImage);
            if (!newImage)
            {
                return BadRequest();
            }
            return Ok("Create success");
        }
        [HttpDelete("delete/{imageid}")]
        public async Task<IActionResult> DeleteHotelImage([FromRoute] int imageid)
        {
            var imageh = await _hotelImageBusiness.DeleteHotelImage(imageid);
            if (!imageh)
            {
                return BadRequest();
            }
            return Ok("Delete success");
        }
    }
}

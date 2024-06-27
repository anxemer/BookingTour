using Microsoft.AspNetCore.Http;

namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateHotelImageRequest
    {
        public List<IFormFile> Url { get; set; }

    }
}

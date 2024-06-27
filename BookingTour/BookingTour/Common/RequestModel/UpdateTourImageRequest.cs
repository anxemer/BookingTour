namespace BookingTourAPI.Common.RequestModel
{
    public class UpdateTourImageRequest
    {
        public int ImageId { get; set; }
        public IFormFile Url { get; set; }

    }
}

namespace BookingTourAPI.Common
{
    public record ApiResponse<T>
    {
        public String Success { get; set; }
        public T? Result { get; set; }

        public static ApiResponse<T> Succeed(T? result)
        {
            return new ApiResponse<T> { Success = "Successful", Result = result };
        }

        public static ApiResponse<T> Error(T? result)
        {
            return new ApiResponse<T> { Success = "Successful", Result = result };
        }

        public static ApiResponse<object> Fail(Exception ex)
        {
            return new ApiResponse<object>
            {
                Success = "Fail",
                Result = new
                {
                    ex.Message,
                }
            };
        }
    }
}

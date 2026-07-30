namespace Sales.Api.utils
{
    public class ApiResponse<T> where T : class
    {

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }

        private ApiResponse(){}

        public static ApiResponse<T> SuccessFul(int statusCode, T data, string message = "Ok")
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = true,
                StatusCode = statusCode,
                Message = message
            };
        }

        public static ApiResponse<T> Failure(string message = "Error", int statusCode = 500)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                StatusCode = statusCode,
                Message = message
            };
        }
    }
}

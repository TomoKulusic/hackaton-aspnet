namespace SmartHousing.API.ResponseWrapper
{
    public class ApiResponse<T> : ApiBaseResponse
    {
        public T Data { get; set; }

        public ApiResponse(T data)
        {
            StatusCode = 200;
            Success = true;
            Data = data;
        }
    }
}

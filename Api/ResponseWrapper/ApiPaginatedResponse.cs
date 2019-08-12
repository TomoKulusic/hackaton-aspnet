using SmartHousing.API.ResponseWrapper;

public class ApiPaginatedResponse<T> : ApiResponse<T>
   {
       public long Count { get; set; }
       public ApiPaginatedResponse(T data, long count) : base(data)
       {
           Count = count;
       }
   }

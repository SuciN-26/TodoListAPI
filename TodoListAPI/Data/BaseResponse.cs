namespace TodoListAPI.Data
{
    public class BaseResponse
    {
        public int Code { get; set; }
        public string? Message { get; set; }
    }

    public class DataResponse<T> : BaseResponse
    {
        public T? Data { get; set; }
    }

    public class TokenResponse : BaseResponse
    {
        public string? Token { get; set; }
    }

}

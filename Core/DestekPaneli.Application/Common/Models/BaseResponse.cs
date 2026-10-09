namespace DestekPaneli.Application.Common.Models
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = default!;
        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public static BaseResponse<T> Success(T data, string message = "İşlem Başarılı", int statusCode = 200)
        {
            return new BaseResponse<T> { IsSuccess = true, Message = message, StatusCode = statusCode, Data = data };
        }
        public static BaseResponse<T> Fail(string message, int statusCode = 400)
        {
            return new BaseResponse<T> { IsSuccess = false, Message = message, StatusCode = statusCode, Data = default };
        }
    }
}

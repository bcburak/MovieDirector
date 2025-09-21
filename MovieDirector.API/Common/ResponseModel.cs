namespace MovieDirector.API.Common
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }

        public static ResponseModel<T> SuccessResponse(T data, string message) =>
            new() { Success = true, Data = data, Message = message };

        public static ResponseModel<T> Failure(string message) =>
            new() { Success = false, Data = default, Message = message };
    }
}

namespace iTemo.Core.Model
{
    public class ResponseResult<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string[] ErrorMessages { get; set; }

        public ResponseResult(T data, bool isSuccess, params string[] errorMessages)
        {
            Data = data;
            IsSuccess = isSuccess;
            ErrorMessages = errorMessages;
        }
    }

    public class ResponseResult
    {
        public bool IsSuccess { get; set; }
        public string[] ErrorMessages { get; set; }

        public ResponseResult(bool isSuccess, params string[] errorMessages)
        {
            IsSuccess = isSuccess;
            ErrorMessages = errorMessages;
        }
    }

    public class ResponseResultId
    {
        public bool IsSuccess { get; set; }
        public string Id { get; set; }
        public string[] ErrorMessages { get; set; }

        public ResponseResultId(bool isSuccess, string id, params string[] errorMessages)
        {
            IsSuccess = isSuccess;
            ErrorMessages = errorMessages;
            Id = id;
        }
    }
}

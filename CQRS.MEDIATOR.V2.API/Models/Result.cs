namespace CQRS.MEDIATOR.V2.API.Models
{
    public class Result<Type>
    {
        public bool IsSuccess { get; set; }
        public Type? Data { get; set; }
        public string? Message { get; set; }
        public static Result<Type> Success(Type data)
        {
            return new Result<Type>
            {
                IsSuccess = true,
                Data = data,
                Message = string.Empty
            };
        }
        public static Result<bool> Failure(string? message)
        {
            return new Result<bool>
            {
                IsSuccess = false,
                Data = default,
                Message = message
            };
        }

        public static Result<Type> Failure(Type data, string? message)
        {
            return new Result<Type>
            {
                IsSuccess = false,
                Data = data,
                Message = message
            };
        }
    }
}

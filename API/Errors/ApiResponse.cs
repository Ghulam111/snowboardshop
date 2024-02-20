
namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode , string messsage = null)
        {
            StatusCode = statusCode;
            Message = messsage ?? ReturnMessageWithRespectToErrorCode(statusCode);
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        private string ReturnMessageWithRespectToErrorCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a bad request",
                401 => "You are not authorized",
                404 => "Resource was not found",
                500 => "Errors are path to dark side",
                _ => null
            };
        }
    }
}
namespace API.Errors
{
    public class ApiExceptions : ApiResponse
    {
        public ApiExceptions(int statusCode, string messsage = null, string details = null) : base(statusCode, messsage)
        {
            Details = details;
        }

        public string Details { get; set; }

    }
}
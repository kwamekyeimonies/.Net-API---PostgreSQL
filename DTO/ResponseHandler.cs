namespace PostgresSQL.API.Handler
{
    public class Responsehandler
    {
        public static ApiResponse GetExceptionResponse(Exception ex)
        {
            ApiResponse response = new ApiResponse();
            response.Code = "1";
            response.ResponseData = ex.Message;
            return response;
        }

        public static ApiResponse GetAppResponse(ResponseType type, object? contract)
        {
            ApiResponse response;

            response = new ApiResponse { ResponseData = contract };

            switch (type)
            {
                case ResponseType.Success:
                    response.Code = "200";
                    response.Message = "Success";
                    break;

                case ResponseType.NotFound:
                    response.Code = "404";
                    response.Message = "Record does not exist";
                    break;
            }

            return response;
        }
    }
}
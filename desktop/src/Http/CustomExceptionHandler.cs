using EmbedIO;
using System;
using System.Threading.Tasks;

namespace LocalWebServer.Http
{
    public static class CustomExceptionHandler
    {
        public static Task ResponseForUnhandledException(IHttpContext context, Exception exception)
        {
            throw new HttpException(500, "Erro interno");
        }

        public static Task ResponseForHttpException(IHttpContext context, IHttpException httpException)
        {
            context.Response.StatusCode = httpException.StatusCode;
            object data = new { message = httpException.Message };
            return ResponseSerializer.Json(context, data);
        }
    }
}

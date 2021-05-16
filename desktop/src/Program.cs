using System;
using System.Configuration;
using EmbedIO;
using EmbedIO.WebApi;
using LocalWebServer.Http.Controllers;
using LocalWebServer.Http;

namespace LocalWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = string.Format("http://127.0.0.1:{0}", ConfigurationManager.AppSettings["port"]);

            using (var server = CreateWebServer(url))
            {
                server.RunAsync();
                Console.ReadKey(true);
            }
        }

        private static WebServer CreateWebServer(string url)
        {
            // Opções do servidor
            var options = new WebServerOptions();
            options.WithUrlPrefix(url);

            // Criação do servidor
            var server = new WebServer(options);
            server.WithCors(ConfigurationManager.AppSettings["origin"]);
            server.HandleUnhandledException(CustomExceptionHandler.ResponseForUnhandledException);
            server.HandleHttpException(CustomExceptionHandler.ResponseForHttpException);

            // Criação do módulo de API
            var module = new WebApiModule("/");
            module.WithController<SatController>();
            server.WithModule(module);

            return server;
        }
    }
}

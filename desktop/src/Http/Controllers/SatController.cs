using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using LocalWebServer.Core.Sat;
using System;

namespace LocalWebServer.Http.Controllers
{
    public sealed class SatController : WebApiController
    {
        [Route(HttpVerbs.Get, "/sat/consultar/{deviceName}")]
        public string consultar(string deviceName)
        {
            DeviceFactory deviceFactory = new DeviceFactory();
            Device device;

            try
            {
                device = deviceFactory.create(deviceName);
            } catch (NotImplementedException)
            {
                throw HttpException.BadRequest("Dispositivo não implementado");
            }

            return device.consultar();
        }
    }
}

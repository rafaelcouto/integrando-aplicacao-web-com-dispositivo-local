using LocalWebServer.Core.Sat.Devices;
using System;

namespace LocalWebServer.Core.Sat
{
    class DeviceFactory
    {
        public Device create(string deviceName)
        {
            switch(deviceName)
            {
                case "emulator":
                    return new Emulator();
            }

            throw new NotImplementedException();
        }
    }
}

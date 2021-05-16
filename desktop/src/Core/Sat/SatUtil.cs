using System;

namespace LocalWebServer.Core.Sat
{
    class SatUtil
    {
        public static int generateNumeroSessao()
        {
            return (new Random()).Next(100000, 999999);
        }
    }
}

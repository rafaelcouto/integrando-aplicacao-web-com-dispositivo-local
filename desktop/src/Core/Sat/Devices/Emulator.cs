using System;
using System.Runtime.InteropServices;

namespace LocalWebServer.Core.Sat.Devices
{
    class Emulator : Device
    {
        [DllImport("SAT.dll", CallingConvention = CallingConvention.Cdecl)] 
        public static extern IntPtr ConsultarSAT(int numeroSessao);

        public string consultar()
        {
            var response = ConsultarSAT(SatUtil.generateNumeroSessao());
            return Marshal.PtrToStringAnsi(response);
        }

    }
}

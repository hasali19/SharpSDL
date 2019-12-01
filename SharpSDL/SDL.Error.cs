using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetError();

        public static string GetErrorString()
        {
            return GetString(GetError());
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearError();
    }
}

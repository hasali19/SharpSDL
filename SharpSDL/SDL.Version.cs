using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_version
        {
            public const int SizeInBytes = 3;
            public byte major;
            public byte minor;
            public byte patch;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void SDL_GetVersion(SDL_version* version);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetRevision();
        public static unsafe string SDL_GetRevisionString()
        {
            return GetString(SDL_GetRevision());
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRevisionNumber();
    }
}

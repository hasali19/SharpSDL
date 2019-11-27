using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_version
        {
            public const int SizeInBytes = 3;
            public byte major;
            public byte minor;
            public byte patch;
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetVersion(SDL_version* version);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GetRevision();

        public static string SDL_GetRevisionString()
        {
            return GetString(SDL_GetRevision());
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRevisionNumber();
    }
}

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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetVersion_d(SDL_version* version);

        private static SDL_GetVersion_d SDL_GetVersion_f;

        public static void SDL_GetVersion(SDL_version* version) => SDL_GetVersion_f(version);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetRevision_d();

        private static SDL_GetRevision_d SDL_GetRevision_f;

        public static byte* SDL_GetRevision() => SDL_GetRevision_f();

        public static unsafe string SDL_GetRevisionString()
        {
            return GetString(SDL_GetRevision());
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetRevisionNumber_d();

        private static SDL_GetRevisionNumber_d SDL_GetRevisionNumber_f;

        public static int SDL_GetRevisionNumber() => SDL_GetRevisionNumber_f();
    }
}

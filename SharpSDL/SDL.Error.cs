using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetError_d();

        private static SDL_GetError_d SDL_GetError_f;

        public static byte* SDL_GetError() => SDL_GetError_f();

        public static unsafe string SDL_GetErrorString()
        {
            return GetString(SDL_GetError());
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_ClearError_d();

        private static SDL_ClearError_d SDL_ClearError_f;

        public static void SDL_ClearError() => SDL_ClearError_f();
    }
}

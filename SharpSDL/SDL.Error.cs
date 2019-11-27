using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GetError();

        public static string SDL_GetErrorString()
        {
            return GetString(SDL_GetError());
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearError();
    }
}

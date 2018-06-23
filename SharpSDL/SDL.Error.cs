using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
    {
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetError();
        public static unsafe string SDL_GetErrorString()
        {
            return GetString(SDL_GetError());
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearError();
    }
}

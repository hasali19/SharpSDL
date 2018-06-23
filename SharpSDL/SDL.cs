using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpSDL
{
    public static partial class SDL
    {
        private const string DllName = "SDL2";

        [Flags]
        public enum SDL_InitFlags : uint
        {
            SDL_INIT_NONE = 0,
            SDL_INIT_TIMER = 0x00000001u,
            SDL_INIT_AUDIO = 0x00000010u,
            SDL_INIT_VIDEO = 0x00000020u,
            SDL_INIT_JOYSTICK = 0x00000200u,
            SDL_INIT_HAPTIC = 0x00001000u,
            SDL_INIT_GAMECONTROLLER = 0x00002000u,
            SDL_INIT_EVENTS = 0x00004000u,
            SDL_INIT_NOPARACHUTE = 0x00100000u,
            SDL_INIT_EVERYTHING = SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO | SDL_INIT_EVENTS
                | SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC | SDL_INIT_GAMECONTROLLER
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(SDL_InitFlags flags);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_InitSubSystem(SDL_InitFlags flags);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_QuitSubSystem(SDL_InitFlags flags);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_InitFlags SDL_WasInit(SDL_InitFlags flags);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();

        private static unsafe string GetString(byte* ptr)
        {
            int count = 0;
            while (*(ptr + count) != 0)
            {
                count += 1;
            }

            return Encoding.UTF8.GetString(ptr, count);
        }
    }
}

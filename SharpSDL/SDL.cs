using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_Init_d(SDL_InitFlags flags);

        private static SDL_Init_d SDL_Init_f;

        public static int SDL_Init(SDL_InitFlags flags) => SDL_Init_f(flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_InitSubSystem_d(SDL_InitFlags flags);

        private static SDL_InitSubSystem_d SDL_InitSubSystem_f;

        public static int SDL_InitSubSystem(SDL_InitFlags flags) => SDL_InitSubSystem_f(flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_QuitSubSystem_d(SDL_InitFlags flags);

        private static SDL_QuitSubSystem_d SDL_QuitSubSystem_f;

        public static void SDL_QuitSubSystem(SDL_InitFlags flags) => SDL_QuitSubSystem_f(flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_InitFlags SDL_WasInit_d(SDL_InitFlags flags);

        private static SDL_WasInit_d SDL_WasInit_f;

        public static SDL_InitFlags SDL_WasInit(SDL_InitFlags flags) => SDL_WasInit_f(flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_Quit_d();

        private static SDL_Quit_d SDL_Quit_f;

        public static void SDL_Quit() => SDL_Quit_f();

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

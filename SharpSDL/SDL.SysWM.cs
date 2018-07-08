using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public enum SDL_SYSWM_TYPE
        {
            SDL_SYSWM_UNKNOWN,
            SDL_SYSWM_WINDOWS,
            SDL_SYSWM_X11,
            SDL_SYSWM_DIRECTFB,
            SDL_SYSWM_COCOA,
            SDL_SYSWM_UIKIT,
            SDL_SYSWM_WAYLAND,
            SDL_SYSWM_MIR,
            SDL_SYSWM_WINRT,
            SDL_SYSWM_ANDROID,
            SDL_SYSWM_VIVANTE,
            SDL_SYSWM_OS2
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_SysWMinfo
        {
            public SDL_version version;
            public SDL_SYSWM_TYPE subsystem;
            public SDL_SysWMinfoUnion info;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct SDL_SysWMinfoUnion
        {
            [FieldOffset(0)]
            public SDL_SysWMinfoWin win;
            [FieldOffset(0)]
            public SDL_SysWMinfoX11 x11;
            [FieldOffset(0)]
            public SDL_SysWMinfoCocoa cocoa;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_SysWMinfoWin
        {
            public IntPtr window;
            public IntPtr hdc;
            public IntPtr hinstance;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_SysWMinfoCocoa
        {
            public IntPtr window;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_SysWMinfoX11
        {
            public IntPtr display;
            public IntPtr window;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_GetWindowWMInfo_d(SDL_Window window, SDL_SysWMinfo* info);

        private static SDL_GetWindowWMInfo_d SDL_GetWindowWMInfo_f;

        public static bool SDL_GetWindowWMInfo(SDL_Window window, SDL_SysWMinfo* info) => SDL_GetWindowWMInfo_f(window, info);
    }
}

using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetClipboardText_d();

        private static SDL_GetClipboardText_d SDL_GetClipboardText_f;

        public static byte* SDL_GetClipboardText() => SDL_GetClipboardText_f();

        public static string SDL_GetClipboardTextString()
        {
            return GetString(SDL_GetClipboardText());
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_HasClipboardText_d();

        private static SDL_HasClipboardText_d SDL_HasClipboardText_f;

        public static bool SDL_HasClipboardText() => SDL_HasClipboardText_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetClipboardText_d(string text);

        private static SDL_SetClipboardText_d SDL_SetClipboardText_f;

        public static int SDL_SetClipboardText(string text) => SDL_SetClipboardText_f(text);
    }
}

using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
    {
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetClipboardText();
        public static unsafe string SDL_GetClipboardTextString()
        {
            return GetString(SDL_GetClipboardText());
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_HasClipboardText();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetClipboardText(string text);
    }
}

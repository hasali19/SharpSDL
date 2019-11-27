using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GetClipboardText();

        public static string SDL_GetClipboardTextString()
        {
            return GetString(SDL_GetClipboardText());
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_HasClipboardText();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetClipboardText(string text);
    }
}

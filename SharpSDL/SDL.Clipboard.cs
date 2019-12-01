using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetClipboardText();

        public static string GetClipboardTextString()
        {
            return GetString(GetClipboardText());
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasClipboardText();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetClipboardText(string text);
    }
}

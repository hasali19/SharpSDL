using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Keysym
        {
            public Scancode Scancode;
            public Keycode Sym;
            public KeyModifier Mod;
            public uint Unused;
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Keycode GetKeyFromName(string name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Keycode GetKeyFromScancode(Scancode scancode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetKeyName(Keycode key);

        public static string GetKeyNameString(Keycode key)
        {
            return GetString(GetKeyName(key));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Window GetKeyboardFocus();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetKeyboardState(int* numKeys);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern KeyModifier GetModState();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Scancode GetScancodeFromKey(Keycode key);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Scancode GetScancodeFromName(string name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetScancodeName(Scancode scancode);

        public static string GetScancodeNameString(Scancode scancode)
        {
            return GetString(GetScancodeName(scancode));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool HasScreenKeyboardSupport();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsScreenKeyboardShown(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsTextInputActive();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModState(KeyModifier modstate);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextInputRect(Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StartTextInput();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopTextInput();
    }
}

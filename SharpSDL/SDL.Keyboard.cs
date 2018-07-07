using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Keysym
        {
            public SDL_Scancode scancode;
            public SDL_Keycode sym;
            public SDL_Keymod mod;
            public uint unused;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Keycode SDL_GetKeyFromName(string name);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetKeyName(SDL_Keycode key);
        public static unsafe string SDL_GetKeyNameString(SDL_Keycode key)
        {
            return GetString(SDL_GetKeyName(key));
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Window SDL_GetKeyboardFocus();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetKeyboardState(int* numKeys);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Keymod SDL_GetModState();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode key);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Scancode SDL_GetScancodeFromName(string name);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetScancodeName(SDL_Scancode scancode);
        public static unsafe string SDL_GetScancodeNameString(SDL_Scancode scancode)
        {
            return GetString(SDL_GetScancodeName(scancode));
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_HasScreenKeyboardSupport();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_IsScreenKeyboardShown(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_IsTextInputActive();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetModState(SDL_Keymod modstate);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void SDL_SetTextInputRect(SDL_Rect* rect);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StartTextInput();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StopTextInput();
    }
}

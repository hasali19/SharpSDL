using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Keysym
        {
            public SDL_Scancode scancode;
            public SDL_Keycode sym;
            public SDL_Keymod mod;
            public uint unused;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Keycode SDL_GetKeyFromName_d(string name);

        private static SDL_GetKeyFromName_d SDL_GetKeyFromName_f;

        public static SDL_Keycode SDL_GetKeyFromName(string name) => SDL_GetKeyFromName_f(name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Keycode SDL_GetKeyFromScancode_d(SDL_Scancode scancode);

        private static SDL_GetKeyFromScancode_d SDL_GetKeyFromScancode_f;

        public static SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode) => SDL_GetKeyFromScancode_f(scancode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetKeyName_d(SDL_Keycode key);

        private static SDL_GetKeyName_d SDL_GetKeyName_f;

        public static byte* SDL_GetKeyName(SDL_Keycode key) => SDL_GetKeyName_f(key);

        public static unsafe string SDL_GetKeyNameString(SDL_Keycode key)
        {
            return GetString(SDL_GetKeyName(key));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_GetKeyboardFocus_d();

        private static SDL_GetKeyboardFocus_d SDL_GetKeyboardFocus_f;

        public static SDL_Window SDL_GetKeyboardFocus() => SDL_GetKeyboardFocus_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetKeyboardState_d(int* numKeys);

        private static SDL_GetKeyboardState_d SDL_GetKeyboardState_f;

        public static byte* SDL_GetKeyboardState(int* numKeys) => SDL_GetKeyboardState_f(numKeys);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Keymod SDL_GetModState_d();

        private static SDL_GetModState_d SDL_GetModState_f;

        public static SDL_Keymod SDL_GetModState() => SDL_GetModState_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Scancode SDL_GetScancodeFromKey_d(SDL_Keycode key);

        private static SDL_GetScancodeFromKey_d SDL_GetScancodeFromKey_f;

        public static SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode key) => SDL_GetScancodeFromKey_f(key);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Scancode SDL_GetScancodeFromName_d(string name);

        private static SDL_GetScancodeFromName_d SDL_GetScancodeFromName_f;

        public static SDL_Scancode SDL_GetScancodeFromName(string name) => SDL_GetScancodeFromName_f(name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetScancodeName_d(SDL_Scancode scancode);

        private static SDL_GetScancodeName_d SDL_GetScancodeName_f;

        public static byte* SDL_GetScancodeName(SDL_Scancode scancode) => SDL_GetScancodeName_f(scancode);

        public static unsafe string SDL_GetScancodeNameString(SDL_Scancode scancode)
        {
            return GetString(SDL_GetScancodeName(scancode));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_HasScreenKeyboardSupport_d();

        private static SDL_HasScreenKeyboardSupport_d SDL_HasScreenKeyboardSupport_f;

        public static bool SDL_HasScreenKeyboardSupport() => SDL_HasScreenKeyboardSupport_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_IsScreenKeyboardShown_d(SDL_Window window);

        private static SDL_IsScreenKeyboardShown_d SDL_IsScreenKeyboardShown_f;

        public static bool SDL_IsScreenKeyboardShown(SDL_Window window) => SDL_IsScreenKeyboardShown_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_IsTextInputActive_d();

        private static SDL_IsTextInputActive_d SDL_IsTextInputActive_f;

        public static bool SDL_IsTextInputActive() => SDL_IsTextInputActive_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetModState_d(SDL_Keymod modstate);

        private static SDL_SetModState_d SDL_SetModState_f;

        public static void SDL_SetModState(SDL_Keymod modstate) => SDL_SetModState_f(modstate);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetTextInputRect_d(SDL_Rect* rect);

        private static SDL_SetTextInputRect_d SDL_SetTextInputRect_f;

        public static void SDL_SetTextInputRect(SDL_Rect* rect) => SDL_SetTextInputRect_f(rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_StartTextInput_d();

        private static SDL_StartTextInput_d SDL_StartTextInput_f;

        public static void SDL_StartTextInput() => SDL_StartTextInput_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_StopTextInput_d();

        private static SDL_StopTextInput_d SDL_StopTextInput_f;

        public static void SDL_StopTextInput() => SDL_StopTextInput_f();
    }
}

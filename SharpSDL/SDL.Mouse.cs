using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public enum SDL_SystemCursor
        {
            SDL_SYSTEM_CURSOR_ARROW,
            SDL_SYSTEM_CURSOR_IBEAM,
            SDL_SYSTEM_CURSOR_WAIT,
            SDL_SYSTEM_CURSOR_CROSSHAIR,
            SDL_SYSTEM_CURSOR_WAITARROW,
            SDL_SYSTEM_CURSOR_SIZENWSE,
            SDL_SYSTEM_CURSOR_SIZENESW,
            SDL_SYSTEM_CURSOR_SIZEWE,
            SDL_SYSTEM_CURSOR_SIZENS,
            SDL_SYSTEM_CURSOR_SIZEALL,
            SDL_SYSTEM_CURSOR_NO,
            SDL_SYSTEM_CURSOR_HAND,
            SDL_NUM_SYSTEM_CURSORS
        }

        public enum SDL_MouseWheelDirection : uint
        {
            SDL_MOUSEWHEEL_NORMAL,
            SDL_MOUSEWHEEL_FLIPPED
        }

        public enum SDL_Button : uint
        {
            SDL_BUTTON_LEFT = 1,
            SDL_BUTTON_MIDDLE = 2,
            SDL_BUTTON_RIGHT = 3,
            SDL_BUTTON_X1 = 4,
            SDL_BUTTON_X2 = 5,
        }

        [Flags]
        public enum SDL_ButtonMask : uint
        {
            SDL_BUTTON_LMASK = 1 << ((int)SDL_Button.SDL_BUTTON_LEFT - 1),
            SDL_BUTTON_MMASK = 1 << ((int)SDL_Button.SDL_BUTTON_MIDDLE - 1),
            SDL_BUTTON_RMASK = 1 << ((int)SDL_Button.SDL_BUTTON_RIGHT - 1),
            SDL_BUTTON_X1MASK = 1 << ((int)SDL_Button.SDL_BUTTON_X1 - 1),
            SDL_BUTTON_X2MASK = 1 << ((int)SDL_Button.SDL_BUTTON_X2 - 1)
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Cursor
        {
            private IntPtr ptr;

            public SDL_Cursor(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(SDL_Cursor cursor)
            {
                return cursor.ptr;
            }
        }

        public static uint SDL_MOUSE(uint x)
        {
            return (uint)(1 << ((int)x - 1));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_CaptureMouse_d(bool enabled);

        private static SDL_CaptureMouse_d SDL_CaptureMouse_f;

        public static int SDL_CaptureMouse(bool enabled) => SDL_CaptureMouse_f(enabled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Cursor SDL_CreateCursor_d(byte* data, byte* mask, int w, int h, int hotX, int hotY);

        private static SDL_CreateCursor_d SDL_CreateCursor_f;

        public static SDL_Cursor SDL_CreateCursor(byte* data, byte* mask, int w, int h, int hotX, int hotY) => SDL_CreateCursor_f(data, mask, w, h, hotX, hotY);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Cursor SDL_CreateSystemCursor_d(SDL_SystemCursor id);

        private static SDL_CreateSystemCursor_d SDL_CreateSystemCursor_f;

        public static SDL_Cursor SDL_CreateSystemCursor(SDL_SystemCursor id) => SDL_CreateSystemCursor_f(id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FreeCursor_d(SDL_Cursor cursor);

        private static SDL_FreeCursor_d SDL_FreeCursor_f;

        public static void SDL_FreeCursor(SDL_Cursor cursor) => SDL_FreeCursor_f(cursor);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Cursor SDL_GetCursor_d();

        private static SDL_GetCursor_d SDL_GetCursor_f;

        public static SDL_Cursor SDL_GetCursor() => SDL_GetCursor_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Cursor SDL_GetDefaultCursor_d();

        private static SDL_GetDefaultCursor_d SDL_GetDefaultCursor_f;

        public static SDL_Cursor SDL_GetDefaultCursor() => SDL_GetDefaultCursor_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_ButtonMask SDL_GetGlobalMouseState_d(int* x, int* y);

        private static SDL_GetGlobalMouseState_d SDL_GetGlobalMouseState_f;

        public static SDL_ButtonMask SDL_GetGlobalMouseState(int* x, int* y) => SDL_GetGlobalMouseState_f(x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_GetMouseFocus_d();

        private static SDL_GetMouseFocus_d SDL_GetMouseFocus_f;

        public static SDL_Window SDL_GetMouseFocus() => SDL_GetMouseFocus_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_ButtonMask SDL_GetMouseState_d(int* x, int* y);

        private static SDL_GetMouseState_d SDL_GetMouseState_f;

        public static SDL_ButtonMask SDL_GetMouseState(int* x, int* y) => SDL_GetMouseState_f(x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_GetRelativeMouseMode_d();

        private static SDL_GetRelativeMouseMode_d SDL_GetRelativeMouseMode_f;

        public static bool SDL_GetRelativeMouseMode() => SDL_GetRelativeMouseMode_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_ButtonMask SDL_GetRelativeMouseState_d(int* x, int* y);

        private static SDL_GetRelativeMouseState_d SDL_GetRelativeMouseState_f;

        public static SDL_ButtonMask SDL_GetRelativeMouseState(int* x, int* y) => SDL_GetRelativeMouseState_f(x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetCursor_d(SDL_Cursor cursor);

        private static SDL_SetCursor_d SDL_SetCursor_f;

        public static void SDL_SetCursor(SDL_Cursor cursor) => SDL_SetCursor_f(cursor);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetRelativeMouseMode_d(bool enabled);

        private static SDL_SetRelativeMouseMode_d SDL_SetRelativeMouseMode_f;

        public static int SDL_SetRelativeMouseMode(bool enabled) => SDL_SetRelativeMouseMode_f(enabled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_ShowCursor_d(int toggle);

        private static SDL_ShowCursor_d SDL_ShowCursor_f;

        public static int SDL_ShowCursor(int toggle) => SDL_ShowCursor_f(toggle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_WarpMouseGlobal_d(int x, int y);

        private static SDL_WarpMouseGlobal_d SDL_WarpMouseGlobal_f;

        public static int SDL_WarpMouseGlobal(int x, int y) => SDL_WarpMouseGlobal_f(x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_WarpMouseInWindow_d(SDL_Window window, int x, int y);

        private static SDL_WarpMouseInWindow_d SDL_WarpMouseInWindow_f;

        public static void SDL_WarpMouseInWindow(SDL_Window window, int x, int y) => SDL_WarpMouseInWindow_f(window, x, y);
    }
}

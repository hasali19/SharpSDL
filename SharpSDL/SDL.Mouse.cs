using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
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

        public enum SDL_MouseWheelDirection
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

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CaptureMouse(bool enabled);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe SDL_Cursor SDL_CreateCursor(byte* data, byte* mask, int w, int h, int hotX, int hotY);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Cursor SDL_CreateSystemCursor(SDL_SystemCursor id);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeCursor(SDL_Cursor cursor);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Cursor SDL_GetCursor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Cursor SDL_GetDefaultCursor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe SDL_ButtonMask SDL_GetGlobalMouseState(int* x, int* y);
        
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Window SDL_GetMouseFocus();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe SDL_ButtonMask SDL_GetMouseState(int* x, int* y);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_GetRelativeMouseMode();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe SDL_ButtonMask SDL_GetRelativeMouseState(int* x, int* y);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetCursor(SDL_Cursor cursor);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRelativeMouseMode(bool enabled);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ShowCursor(int toggle);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WarpMouseGlobal(int x, int y);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_WarpMouseInWindow(SDL_Window window, int x, int y);
    }
}

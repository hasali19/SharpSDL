using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public enum SystemCursor
        {
            Arrow,
            IBeam,
            Wait,
            Crosshair,
            WaitArrow,
            SizeNWSE,
            SizeNESW,
            SizeWE,
            SizeNS,
            SizeALL,
            NO,
            Hand
        }

        public enum MouseWheelDirection : uint
        {
            Normal,
            Flipped
        }

        public enum Button : uint
        {
            Left = 1,
            Middle = 2,
            Right = 3,
            X1 = 4,
            X2 = 5,
        }

        [Flags]
        public enum ButtonMask : uint
        {
            Left = 1 << ((int)Button.Left - 1),
            Middle = 1 << ((int)Button.Middle - 1),
            Right = 1 << ((int)Button.Right - 1),
            X1 = 1 << ((int)Button.X1 - 1),
            X2 = 1 << ((int)Button.X2 - 1)
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Cursor
        {
            private readonly IntPtr ptr;

            public Cursor(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(Cursor cursor)
            {
                return cursor.ptr;
            }

            public static implicit operator Cursor(IntPtr ptr)
            {
                return new Cursor(ptr);
            }
        }

        public static uint MOUSE(uint x)
        {
            return (uint)(1 << ((int)x - 1));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CaptureMouse(bool enabled);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Cursor CreateCursor(byte* data, byte* mask, int w, int h, int hotX, int hotY);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Cursor CreateSystemCursor(SystemCursor id);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreeCursor(Cursor cursor);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Cursor GetCursor();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Cursor GetDefaultCursor();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ButtonMask GetGlobalMouseState(int* x, int* y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Window GetMouseFocus();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ButtonMask GetMouseState(int* x, int* y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetRelativeMouseMode();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ButtonMask GetRelativeMouseState(int* x, int* y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCursor(Cursor cursor);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRelativeMouseMode(bool enabled);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ShowCursor(int toggle);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WarpMouseGlobal(int x, int y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void WarpMouseInWindow(Window window, int x, int y);
    }
}

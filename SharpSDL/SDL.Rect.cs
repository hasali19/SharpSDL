using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int X;
            public int Y;
        }
    }
}

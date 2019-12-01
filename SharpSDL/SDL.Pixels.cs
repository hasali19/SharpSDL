using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Color
        {
            public byte R;
            public byte G;
            public byte B;
            public byte A;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Palette
        {
            public int NumColors;
            public Color* Colors;
            public uint Version;
            public int RefCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PixelFormat
        {
            public uint Format;
            public Palette* Palette;
            public byte BitsPerPixel;
            public byte BytesPerPixel;
            public fixed byte Padding[2];
            public uint RMask;
            public uint GMask;
            public uint BMask;
            public uint AMask;
            public byte RLoss;
            public byte GLoss;
            public byte BLoss;
            public byte ALoss;
            public byte RShift;
            public byte GShift;
            public byte BShift;
            public byte AShift;
            public int RefCount;
            public PixelFormat* Next;
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern PixelFormat* AllocFormat(uint pixel_format);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Palette* AllocPalette(int ncolors);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CalculateGammaRamp(float gamma, ushort* ramp);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreeFormat(PixelFormat* format);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreePalette(Palette* palette);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetPixelFormatName(uint format);

        public static string GetPixelFormatNameString(uint format) => GetString(GetPixelFormatName(format));

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetRGB(uint pixel, PixelFormat* format, byte* r, byte* g, byte* b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetRGBA(uint pixel, PixelFormat* format, byte* r, byte* g, byte* b, byte* a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint MapRGB(PixelFormat* format, byte r, byte g, byte b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint MapRGBA(PixelFormat* format, byte r, byte g, byte b, byte a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint MasksToPixelFormatEnum(int bpp, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool PixelFormatEnumToMasks(uint format, int* bpp, uint* Rmask, uint* Gmask, uint* Bmask, uint* Amask);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPaletteColors(Palette* palette, Color* colors, int firstcolor, int ncolors);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPixelFormatPalette(PixelFormat* format, Palette* palette);
    }
}

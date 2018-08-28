using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Color
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Palette
        {
            public int ncolors;
            public SDL_Color* colors;
            public uint version;
            public int refcount;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_PixelFormat
        {
            public uint format;
            public SDL_Palette* palette;
            public byte BitsPerPixel;
            public byte BytesPerPixel;
            public fixed byte padding[2];
            public uint Rmask;
            public uint Gmask;
            public uint Bmask;
            public uint Amask;
            public byte Rloss;
            public byte Gloss;
            public byte Bloss;
            public byte Aloss;
            public byte Rshift;
            public byte Gshift;
            public byte Bshift;
            public byte Ashift;
            public int refcount;
            public SDL_PixelFormat* next;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_PixelFormat* SDL_AllocFormat_d(uint pixel_format);

        private static SDL_AllocFormat_d SDL_AllocFormat_f;

        public static SDL_PixelFormat* SDL_AllocFormat(uint pixel_format) => SDL_AllocFormat_f(pixel_format);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Palette* SDL_AllocPalette_d(int ncolors);

        private static SDL_AllocPalette_d SDL_AllocPalette_f;

        public static SDL_Palette* SDL_AllocPalette(int ncolors) => SDL_AllocPalette_f(ncolors);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_CalculateGammaRamp_d(float gamma, ushort* ramp);

        private static SDL_CalculateGammaRamp_d SDL_CalculateGammaRamp_f;

        public static void SDL_CalculateGammaRamp(float gamma, ushort* ramp) => SDL_CalculateGammaRamp_f(gamma, ramp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FreeFormat_d(SDL_PixelFormat* format);

        private static SDL_FreeFormat_d SDL_FreeFormat_f;

        public static void SDL_FreeFormat(SDL_PixelFormat* format) => SDL_FreeFormat_f(format);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FreePalette_d(SDL_Palette* palette);

        private static SDL_FreePalette_d SDL_FreePalette_f;

        public static void SDL_FreePalette(SDL_Palette* palette) => SDL_FreePalette_f(palette);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetPixelFormatName_d(uint format);

        private static SDL_GetPixelFormatName_d SDL_GetPixelFormatName_f;

        public static byte* SDL_GetPixelFormatName(uint format) => SDL_GetPixelFormatName_f(format);

        public static string SDL_GetPixelFormatNameString(uint format) => GetString(SDL_GetPixelFormatName(format));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetRGB_d(uint pixel, SDL_PixelFormat* format, byte* r, byte* g, byte* b);

        private static SDL_GetRGB_d SDL_GetRGB_f;

        public static void SDL_GetRGB(uint pixel, SDL_PixelFormat* format, byte* r, byte* g, byte* b) => SDL_GetRGB_f(pixel, format, r, g, b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetRGBA_d(uint pixel, SDL_PixelFormat* format, byte* r, byte* g, byte* b, byte* a);

        private static SDL_GetRGBA_d SDL_GetRGBA_f;

        public static void SDL_GetRGBA(uint pixel, SDL_PixelFormat* format, byte* r, byte* g, byte* b, byte* a) => SDL_GetRGBA_f(pixel, format, r, g, b, a);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_MapRGB_d(SDL_PixelFormat* format, byte r, byte g, byte b);

        private static SDL_MapRGB_d SDL_MapRGB_f;

        public static uint SDL_MapRGB(SDL_PixelFormat* format, byte r, byte g, byte b) => SDL_MapRGB_f(format, r, g, b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_MapRGBA_d(SDL_PixelFormat* format, byte r, byte g, byte b, byte a);

        private static SDL_MapRGBA_d SDL_MapRGBA_f;

        public static uint SDL_MapRGBA(SDL_PixelFormat* format, byte r, byte g, byte b, byte a) => SDL_MapRGBA_f(format, r, g, b, a);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_MasksToPixelFormatEnum_d(int bpp, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        private static SDL_MasksToPixelFormatEnum_d SDL_MasksToPixelFormatEnum_f;

        public static uint SDL_MasksToPixelFormatEnum(int bpp, uint Rmask, uint Gmask, uint Bmask, uint Amask) => SDL_MasksToPixelFormatEnum_f(bpp, Rmask, Gmask, Bmask, Amask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_PixelFormatEnumToMasks_d(uint format, int* bpp, uint* Rmask, uint* Gmask, uint* Bmask, uint* Amask);

        private static SDL_PixelFormatEnumToMasks_d SDL_PixelFormatEnumToMasks_f;

        public static bool SDL_PixelFormatEnumToMasks(uint format, int* bpp, uint* Rmask, uint* Gmask, uint* Bmask, uint* Amask) => SDL_PixelFormatEnumToMasks_f(format, bpp, Rmask, Gmask, Bmask, Amask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetPaletteColors_d(SDL_Palette* palette, SDL_Color* colors, int firstcolor, int ncolors);

        private static SDL_SetPaletteColors_d SDL_SetPaletteColors_f;

        public static int SDL_SetPaletteColors(SDL_Palette* palette, SDL_Color* colors, int firstcolor, int ncolors) => SDL_SetPaletteColors_f(palette, colors, firstcolor, ncolors);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetPixelFormatPalette_d(SDL_PixelFormat* format, SDL_Palette* palette);

        private static SDL_SetPixelFormatPalette_d SDL_SetPixelFormatPalette_f;

        public static int SDL_SetPixelFormatPalette(SDL_PixelFormat* format, SDL_Palette* palette) => SDL_SetPixelFormatPalette_f(format, palette);
    }
}

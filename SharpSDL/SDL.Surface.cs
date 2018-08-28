using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public const uint SDL_SWSURFACE = 0;
        public const uint SDL_PREALLOC = 0x00000001;
        public const uint SDL_RLEACCEL = 0x00000002;
        public const uint SDL_DONTFREE = 0x00000004;

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Surface
        {
            public uint flags;
            public SDL_PixelFormat* format;
            public int w;
            public int h;
            public int pitch;
            public void* pixels;
            public void* userdata;
            public int locked;
            public void* lock_data;
            public SDL_Rect clip_rect;
            public IntPtr map;
            public int refcount;
        }

        public static int SDL_BlitScaled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_UpperBlitScaled_f(src, srcrect, dst, dstrect);

        public static int SDL_BlitSurface(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_UpperBlit(src, srcrect, dst, dstrect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_ConvertPixels_d(int width, int height, uint src_format, void* src, int src_pitch, uint dst_format, void* dst, int dst_pitch);

        private static SDL_ConvertPixels_d SDL_ConvertPixels_f;

        public static int SDL_ConvertPixels(int width, int height, uint src_format, void* src, int src_pitch, uint dst_format, void* dst, int dst_pitch) => SDL_ConvertPixels_f(width, height, src_format, src, src_pitch, dst_format, dst, dst_pitch);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Surface* SDL_ConvertSurface_d(SDL_Surface* src, SDL_PixelFormat* fmt, uint flags);

        private static SDL_ConvertSurface_d SDL_ConvertSurface_f;

        public static SDL_Surface* SDL_ConvertSurface(SDL_Surface* src, SDL_PixelFormat* fmt, uint flags) => SDL_ConvertSurface_f(src, fmt, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Surface* SDL_ConvertSurfaceFormat_d(SDL_Surface* src, uint pixel_format, uint flags);

        private static SDL_ConvertSurfaceFormat_d SDL_ConvertSurfaceFormat_f;

        public static SDL_Surface* SDL_ConvertSurfaceFormat(SDL_Surface* src, uint pixel_format, uint flags) => SDL_ConvertSurfaceFormat_f(src, pixel_format, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Surface* SDL_CreateRGBSurface_d(uint flags, int width, int height, int depth, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        private static SDL_CreateRGBSurface_d SDL_CreateRGBSurface_f;

        public static SDL_Surface* SDL_CreateRGBSurface(uint flags, int width, int height, int depth, uint Rmask, uint Gmask, uint Bmask, uint Amask) => SDL_CreateRGBSurface_f(flags, width, height, depth, Rmask, Gmask, Bmask, Amask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Surface* SDL_CreateRGBSurfaceFrom_d(void* pixels, int width, int height, int depth, int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        private static SDL_CreateRGBSurfaceFrom_d SDL_CreateRGBSurfaceFrom_f;

        public static SDL_Surface* SDL_CreateRGBSurfaceFrom(void* pixels, int width, int height, int depth, int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask) => SDL_CreateRGBSurfaceFrom_f(pixels, width, height, depth, pitch, Rmask, Gmask, Bmask, Amask);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Surface* SDL_CreateRGBSurfaceWithFormat_d(uint flags, int width, int height, int depth, uint format);

        private static SDL_CreateRGBSurfaceWithFormat_d SDL_CreateRGBSurfaceWithFormat_f;

        public static SDL_Surface* SDL_CreateRGBSurfaceWithFormat(uint flags, int width, int height, int depth, uint format) => SDL_CreateRGBSurfaceWithFormat_f(flags, width, height, depth, format);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Surface* SDL_CreateRGBSurfaceWithFormatFrom_d(void* pixels, int width, int height, int depth, int pitch, uint format);

        private static SDL_CreateRGBSurfaceWithFormatFrom_d SDL_CreateRGBSurfaceWithFormatFrom_f;

        public static SDL_Surface* SDL_CreateRGBSurfaceWithFormatFrom(void* pixels, int width, int height, int depth, int pitch, uint format) => SDL_CreateRGBSurfaceWithFormatFrom_f(pixels, width, height, depth, pitch, format);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_FillRect_d(SDL_Surface* dst, SDL_Rect* rect, uint color);

        private static SDL_FillRect_d SDL_FillRect_f;

        public static int SDL_FillRect(SDL_Surface* dst, SDL_Rect* rect, uint color) => SDL_FillRect_f(dst, rect, color);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_FillRects_d(SDL_Surface* dst, SDL_Rect* rects, int count, uint color);

        private static SDL_FillRects_d SDL_FillRects_f;

        public static int SDL_FillRects(SDL_Surface* dst, SDL_Rect* rects, int count, uint color) => SDL_FillRects_f(dst, rects, count, color);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FreeSurface_d(SDL_Surface* surface);

        private static SDL_FreeSurface_d SDL_FreeSurface_f;

        public static void SDL_FreeSurface(SDL_Surface* surface) => SDL_FreeSurface_f(surface);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetClipRect_d(SDL_Surface* surface, SDL_Rect* rect);

        private static SDL_GetClipRect_d SDL_GetClipRect_f;

        public static void SDL_GetClipRect(SDL_Surface* surface, SDL_Rect* rect) => SDL_GetClipRect_f(surface, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetColorKey_d(SDL_Surface* surface, uint* key);

        private static SDL_GetColorKey_d SDL_GetColorKey_f;

        public static int SDL_GetColorKey(SDL_Surface* surface, uint* key) => SDL_GetColorKey_f(surface, key);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetSurfaceAlphaMod_d(SDL_Surface* surface, byte* alpha);

        private static SDL_GetSurfaceAlphaMod_d SDL_GetSurfaceAlphaMod_f;

        public static int SDL_GetSurfaceAlphaMod(SDL_Surface* surface, byte* alpha) => SDL_GetSurfaceAlphaMod_f(surface, alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetSurfaceBlendMode_d(SDL_Surface* surface, SDL_BlendMode* blendMode);

        private static SDL_GetSurfaceBlendMode_d SDL_GetSurfaceBlendMode_f;

        public static int SDL_GetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode* blendMode) => SDL_GetSurfaceBlendMode_f(surface, blendMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetSurfaceColorMod_d(SDL_Surface* surface, byte* r, byte* g, byte* b);

        private static SDL_GetSurfaceColorMod_d SDL_GetSurfaceColorMod_f;

        public static int SDL_GetSurfaceColorMod(SDL_Surface* surface, byte* r, byte* g, byte* b) => SDL_GetSurfaceColorMod_f(surface, r, g, b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_LockSurface_d(SDL_Surface* surface);

        private static SDL_LockSurface_d SDL_LockSurface_f;

        public static int SDL_LockSurface(SDL_Surface* surface) => SDL_LockSurface_f(surface);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_LowerBlit_d(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        private static SDL_LowerBlit_d SDL_LowerBlit_f;

        public static int SDL_LowerBlit(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_LowerBlit_f(src, srcrect, dst, dstrect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_LowerBlitScaled_d(SDL_Surface* surface, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        private static SDL_LowerBlitScaled_d SDL_LowerBlitScaled_f;

        public static int SDL_LowerBlitScaled(SDL_Surface* surface, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_LowerBlitScaled_f(surface, srcrect, dst, dstrect);

        public static bool SDL_MUSTLOCK(SDL_Surface* s) => (s->flags & 0x00000002) != 0;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_SetClipRect_d(SDL_Surface* surface, SDL_Rect* rect);

        private static SDL_SetClipRect_d SDL_SetClipRect_f;

        public static bool SDL_SetClipRect(SDL_Surface* surface, SDL_Rect* rect) => SDL_SetClipRect_f(surface, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetColorKey_d(SDL_Surface* surface, bool flag, uint key);

        private static SDL_SetColorKey_d SDL_SetColorKey_f;

        public static int SDL_SetColorKey(SDL_Surface* surface, bool flag, uint key) => SDL_SetColorKey_f(surface, flag, key);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetSurfaceAlphaMod_d(SDL_Surface* surface, byte alpha);

        private static SDL_SetSurfaceAlphaMod_d SDL_SetSurfaceAlphaMod_f;

        public static int SDL_SetSurfaceAlphaMod(SDL_Surface* surface, byte alpha) => SDL_SetSurfaceAlphaMod_f(surface, alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetSurfaceBlendMode_d(SDL_Surface* surface, SDL_BlendMode blendMode);

        private static SDL_SetSurfaceBlendMode_d SDL_SetSurfaceBlendMode_f;

        public static int SDL_SetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode blendMode) => SDL_SetSurfaceBlendMode_f(surface, blendMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetSurfaceColorMod_d(SDL_Surface* surface, byte r, byte g, byte b);

        private static SDL_SetSurfaceColorMod_d SDL_SetSurfaceColorMod_f;

        public static int SDL_SetSurfaceColorMod(SDL_Surface* surface, byte r, byte g, byte b) => SDL_SetSurfaceColorMod_f(surface, r, g, b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetSurfacePalette_d(SDL_Surface* surface, SDL_Palette* palette);

        private static SDL_SetSurfacePalette_d SDL_SetSurfacePalette_f;

        public static int SDL_SetSurfacePalette(SDL_Surface* surface, SDL_Palette* palette) => SDL_SetSurfacePalette_f(surface, palette);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetSurfaceRLE_d(SDL_Surface* surface, int flag);

        private static SDL_SetSurfaceRLE_d SDL_SetSurfaceRLE_f;

        public static int SDL_SetSurfaceRLE(SDL_Surface* surface, int flag) => SDL_SetSurfaceRLE_f(surface, flag);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_UnlockSurface_d(SDL_Surface* surface);

        private static SDL_UnlockSurface_d SDL_UnlockSurface_f;

        public static void SDL_UnlockSurface(SDL_Surface* surface) => SDL_UnlockSurface_f(surface);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_UpperBlit_d(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        private static SDL_UpperBlit_d SDL_UpperBlit_f;

        public static int SDL_UpperBlit(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_UpperBlit_f(src, srcrect, dst, dstrect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_UpperBlitScaled_d(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        private static SDL_UpperBlitScaled_d SDL_UpperBlitScaled_f;

        public static int SDL_UpperBlitScaled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_UpperBlitScaled_f(src, srcrect, dst, dstrect);
    }
}

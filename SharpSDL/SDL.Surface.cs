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

        public static int SDL_BlitScaled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_UpperBlitScaled(src, srcrect, dst, dstrect);

        public static int SDL_BlitSurface(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect) => SDL_UpperBlit(src, srcrect, dst, dstrect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ConvertPixels(int width, int height, uint src_format, void* src, int src_pitch, uint dst_format, void* dst, int dst_pitch);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Surface* SDL_ConvertSurface(SDL_Surface* src, SDL_PixelFormat* fmt, uint flags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Surface* SDL_ConvertSurfaceFormat(SDL_Surface* src, uint pixel_format, uint flags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Surface* SDL_CreateRGBSurface(uint flags, int width, int height, int depth, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Surface* SDL_CreateRGBSurfaceFrom(void* pixels, int width, int height, int depth, int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Surface* SDL_CreateRGBSurfaceWithFormat(uint flags, int width, int height, int depth, uint format);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Surface* SDL_CreateRGBSurfaceWithFormatFrom(void* pixels, int width, int height, int depth, int pitch, uint format);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(SDL_Surface* dst, SDL_Rect* rect, uint color);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRects(SDL_Surface* dst, SDL_Rect* rects, int count, uint color);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeSurface(SDL_Surface* surface);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetClipRect(SDL_Surface* surface, SDL_Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetColorKey(SDL_Surface* surface, uint* key);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceAlphaMod(SDL_Surface* surface, byte* alpha);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode* blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceColorMod(SDL_Surface* surface, byte* r, byte* g, byte* b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockSurface(SDL_Surface* surface);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlit(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlitScaled(SDL_Surface* surface, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        public static bool SDL_MUSTLOCK(SDL_Surface* s) => (s->flags & 0x00000002) != 0;

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_SetClipRect(SDL_Surface* surface, SDL_Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetColorKey(SDL_Surface* surface, bool flag, uint key);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceAlphaMod(SDL_Surface* surface, byte alpha);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceBlendMode(SDL_Surface* surface, SDL_BlendMode blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceColorMod(SDL_Surface* surface, byte r, byte g, byte b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfacePalette(SDL_Surface* surface, SDL_Palette* palette);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceRLE(SDL_Surface* surface, int flag);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockSurface(SDL_Surface* surface);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlit(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlitScaled(SDL_Surface* src, SDL_Rect* srcrect, SDL_Surface* dst, SDL_Rect* dstrect);
    }
}

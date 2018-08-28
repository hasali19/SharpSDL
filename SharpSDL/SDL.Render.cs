using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [Flags]
        public enum SDL_RendererFlags : uint
        {
            SDL_RENDERER_SOFTWARE = 0x00000001,
            SDL_RENDERER_ACCELERATED = 0x00000002,
            SDL_RENDERER_PRESENTVSYNC = 0x00000004,
            SDL_RENDERER_TARGETTEXTURE = 0x00000008
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_RendererInfo
        {
            public byte* name;
            public SDL_RendererFlags flags;
            public uint num_texture_formats;
            public fixed uint texture_formats[16];
            public int max_texture_width;
            public int max_texture_height;
        }

        public enum SDL_TextureAccess
        {
            SDL_TEXTUREACCESS_STATIC,
            SDL_TEXTUREACCESS_STREAMING,
            SDL_TEXTUREACCESS_TARGET
        }

        [Flags]
        public enum SDL_TextureModulate : uint
        {
            SDL_TEXTUREMODULATE_NONE = 0x00000000,
            SDL_TEXTUREMODULATE_COLOR = 0x00000001,
            SDL_TEXTUREMODULATE_ALPHA = 0x00000002
        }

        [Flags]
        public enum SDL_RendererFlip : uint
        {
            SDL_FLIP_NONE = 0x00000000,
            SDL_FLIP_HORIZONTAL = 0x00000001,
            SDL_FLIP_VERTICAL = 0x00000002
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Renderer
        {
            private IntPtr ptr;

            public SDL_Renderer(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(SDL_Renderer renderer)
            {
                return renderer.ptr;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Texture
        {
            private IntPtr ptr;

            public SDL_Texture(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(SDL_Texture texture)
            {
                return texture.ptr;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Renderer SDL_CreateRenderer_d(SDL_Window window, int index, SDL_RendererFlags flags);

        private static SDL_CreateRenderer_d SDL_CreateRenderer_f;

        public static SDL_Renderer SDL_CreateRenderer(SDL_Window window, int index, SDL_RendererFlags flags) => SDL_CreateRenderer_f(window, index, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Renderer SDL_CreateSoftwareRenderer_d(SDL_Surface* surface);

        private static SDL_CreateSoftwareRenderer_d SDL_CreateSoftwareRenderer_f;

        public static SDL_Renderer SDL_CreateSoftwareRenderer(SDL_Surface* surface) => SDL_CreateSoftwareRenderer_f(surface);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Texture SDL_CreateTexture_d(SDL_Renderer renderer, uint format, SDL_TextureAccess access, int w, int h);

        private static SDL_CreateTexture_d SDL_CreateTexture_f;

        public static SDL_Texture SDL_CreateTexture(SDL_Renderer renderer, uint format, SDL_TextureAccess access, int w, int h) => SDL_CreateTexture_f(renderer, format, access, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Texture SDL_CreateTextureFromSurface_d(SDL_Renderer renderer, SDL_Surface* surface);

        private static SDL_CreateTextureFromSurface_d SDL_CreateTextureFromSurface_f;

        public static SDL_Texture SDL_CreateTextureFromSurface(SDL_Renderer renderer, SDL_Surface* surface) => SDL_CreateTextureFromSurface_f(renderer, surface);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_CreateWindowAndRenderer_d(int width, int height, SDL_WindowFlags window_flags, SDL_Window* window, SDL_Renderer* renderer);

        private static SDL_CreateWindowAndRenderer_d SDL_CreateWindowAndRenderer_f;

        public static int SDL_CreateWindowAndRenderer(int width, int height, SDL_WindowFlags window_flags, SDL_Window* window, SDL_Renderer* renderer) => SDL_CreateWindowAndRenderer_f(width, height, window_flags, window, renderer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DestroyRenderer_d(SDL_Renderer renderer);

        private static SDL_DestroyRenderer_d SDL_DestroyRenderer_f;

        public static void SDL_DestroyRenderer(SDL_Renderer renderer) => SDL_DestroyRenderer_f(renderer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DestroyTexture_d(SDL_Texture texture);

        private static SDL_DestroyTexture_d SDL_DestroyTexture_f;

        public static void SDL_DestroyTexture(SDL_Texture texture) => SDL_DestroyTexture_f(texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetNumRenderDrivers_d();

        private static SDL_GetNumRenderDrivers_d SDL_GetNumRenderDrivers_f;

        public static int SDL_GetNumRenderDrivers() => SDL_GetNumRenderDrivers_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetRenderDrawBlendMode_d(SDL_Renderer renderer, SDL_BlendMode* blendMode);

        private static SDL_GetRenderDrawBlendMode_d SDL_GetRenderDrawBlendMode_f;

        public static int SDL_GetRenderDrawBlendMode(SDL_Renderer renderer, SDL_BlendMode* blendMode) => SDL_GetRenderDrawBlendMode_f(renderer, blendMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetRenderDrawColor_d(SDL_Renderer renderer, byte* r, byte* g, byte* b, byte* a);

        private static SDL_GetRenderDrawColor_d SDL_GetRenderDrawColor_f;

        public static int SDL_GetRenderDrawColor(SDL_Renderer renderer, byte* r, byte* g, byte* b, byte* a) => SDL_GetRenderDrawColor_f(renderer, r, g, b, a);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetRenderDriverInfo_d(int index, SDL_RendererInfo* info);

        private static SDL_GetRenderDriverInfo_d SDL_GetRenderDriverInfo_f;

        public static int SDL_GetRenderDriverInfo(int index, SDL_RendererInfo* info) => SDL_GetRenderDriverInfo_f(index, info);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Texture SDL_GetRenderTarget_d(SDL_Renderer* renderer);

        private static SDL_GetRenderTarget_d SDL_GetRenderTarget_f;

        public static SDL_Texture SDL_GetRenderTarget(SDL_Renderer* renderer) => SDL_GetRenderTarget_f(renderer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Renderer* SDL_GetRenderer_d(SDL_Window window);

        private static SDL_GetRenderer_d SDL_GetRenderer_f;

        public static SDL_Renderer* SDL_GetRenderer(SDL_Window window) => SDL_GetRenderer_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetRendererInfo_d(SDL_Renderer renderer, SDL_RendererInfo* info);

        private static SDL_GetRendererInfo_d SDL_GetRendererInfo_f;

        public static int SDL_GetRendererInfo(SDL_Renderer renderer, SDL_RendererInfo* info) => SDL_GetRendererInfo_f(renderer, info);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetRendererOutputSize_d(SDL_Renderer renderer, int* w, int* h);

        private static SDL_GetRendererOutputSize_d SDL_GetRendererOutputSize_f;

        public static int SDL_GetRendererOutputSize(SDL_Renderer renderer, int* w, int* h) => SDL_GetRendererOutputSize_f(renderer, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetTextureAlphaMod_d(SDL_Texture texture, byte* alpha);

        private static SDL_GetTextureAlphaMod_d SDL_GetTextureAlphaMod_f;

        public static int SDL_GetTextureAlphaMod(SDL_Texture texture, byte* alpha) => SDL_GetTextureAlphaMod_f(texture, alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetTextureBlendMode_d(SDL_Texture texture, SDL_BlendMode* blendMode);

        private static SDL_GetTextureBlendMode_d SDL_GetTextureBlendMode_f;

        public static int SDL_GetTextureBlendMode(SDL_Texture texture, SDL_BlendMode* blendMode) => SDL_GetTextureBlendMode_f(texture, blendMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetTextureColorMod_d(SDL_Texture texture, byte* r, byte* g, byte* b);

        private static SDL_GetTextureColorMod_d SDL_GetTextureColorMod_f;

        public static int SDL_GetTextureColorMod(SDL_Texture texture, byte* r, byte* g, byte* b) => SDL_GetTextureColorMod_f(texture, r, g, b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_LockTexture_d(SDL_Texture texture, SDL_Rect* rect, void** pixels, int* pitch);

        private static SDL_LockTexture_d SDL_LockTexture_f;

        public static int SDL_LockTexture(SDL_Texture texture, SDL_Rect* rect, void** pixels, int* pitch) => SDL_LockTexture_f(texture, rect, pixels, pitch);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_QueryTexture_d(SDL_Texture texture, uint* format, SDL_TextureAccess* access, int* w, int* h);

        private static SDL_QueryTexture_d SDL_QueryTexture_f;

        public static int SDL_QueryTexture(SDL_Texture texture, uint* format, SDL_TextureAccess* access, int* w, int* h) => SDL_QueryTexture_f(texture, format, access, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderClear_d(SDL_Renderer renderer);

        private static SDL_RenderClear_d SDL_RenderClear_f;

        public static int SDL_RenderClear(SDL_Renderer renderer) => SDL_RenderClear_f(renderer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderCopy_d(SDL_Renderer renderer, SDL_Texture texture, SDL_Rect* srcrect, SDL_Rect* dstrect);

        private static SDL_RenderCopy_d SDL_RenderCopy_f;

        public static int SDL_RenderCopy(SDL_Renderer renderer, SDL_Texture texture, SDL_Rect* srcrect, SDL_Rect* dstrect) => SDL_RenderCopy_f(renderer, texture, srcrect, dstrect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderCopyEx_d(SDL_Renderer renderer, SDL_Texture texture, SDL_Rect* srcrect, SDL_Rect* dstrect, double angle, SDL_Point* center, SDL_RendererFlip flip);

        private static SDL_RenderCopyEx_d SDL_RenderCopyEx_f;

        public static int SDL_RenderCopyEx(SDL_Renderer renderer, SDL_Texture texture, SDL_Rect* srcrect, SDL_Rect* dstrect, double angle, SDL_Point* center, SDL_RendererFlip flip) => SDL_RenderCopyEx_f(renderer, texture, srcrect, dstrect, angle, center, flip);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderDrawLine_d(SDL_Renderer renderer, int x1, int y1, int x2, int y2);

        private static SDL_RenderDrawLine_d SDL_RenderDrawLine_f;

        public static int SDL_RenderDrawLine(SDL_Renderer renderer, int x1, int y1, int x2, int y2) => SDL_RenderDrawLine_f(renderer, x1, y1, x2, y2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderDrawLines_d(SDL_Renderer renderer, SDL_Point* points, int count);

        private static SDL_RenderDrawLines_d SDL_RenderDrawLines_f;

        public static int SDL_RenderDrawLines(SDL_Renderer renderer, SDL_Point* points, int count) => SDL_RenderDrawLines_f(renderer, points, count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderDrawPoint_d(SDL_Renderer renderer, int x, int y);

        private static SDL_RenderDrawPoint_d SDL_RenderDrawPoint_f;

        public static int SDL_RenderDrawPoint(SDL_Renderer renderer, int x, int y) => SDL_RenderDrawPoint_f(renderer, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderDrawPoints_d(SDL_Renderer renderer, SDL_Point* points, int count);

        private static SDL_RenderDrawPoints_d SDL_RenderDrawPoints_f;

        public static int SDL_RenderDrawPoints(SDL_Renderer renderer, SDL_Point* points, int count) => SDL_RenderDrawPoints_f(renderer, points, count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderDrawRect_d(SDL_Renderer renderer, SDL_Rect* rect);

        private static SDL_RenderDrawRect_d SDL_RenderDrawRect_f;

        public static int SDL_RenderDrawRect(SDL_Renderer renderer, SDL_Rect* rect) => SDL_RenderDrawRect_f(renderer, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderDrawRects_d(SDL_Renderer renderer, SDL_Rect* rects, int count);

        private static SDL_RenderDrawRects_d SDL_RenderDrawRects_f;

        public static int SDL_RenderDrawRects(SDL_Renderer renderer, SDL_Rect* rects, int count) => SDL_RenderDrawRects_f(renderer, rects, count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderFillRect_d(SDL_Renderer renderer, SDL_Rect* rect);

        private static SDL_RenderFillRect_d SDL_RenderFillRect_f;

        public static int SDL_RenderFillRect(SDL_Renderer renderer, SDL_Rect* rect) => SDL_RenderFillRect_f(renderer, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderFillRects_d(SDL_Renderer renderer, SDL_Rect* rects, int count);

        private static SDL_RenderFillRects_d SDL_RenderFillRects_f;

        public static int SDL_RenderFillRects(SDL_Renderer renderer, SDL_Rect* rects, int count) => SDL_RenderFillRects_f(renderer, rects, count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_RenderGetClipRect_d(SDL_Renderer renderer, SDL_Rect* rect);

        private static SDL_RenderGetClipRect_d SDL_RenderGetClipRect_f;

        public static void SDL_RenderGetClipRect(SDL_Renderer renderer, SDL_Rect* rect) => SDL_RenderGetClipRect_f(renderer, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_RenderGetIntegerScale_d(SDL_Renderer renderer);

        private static SDL_RenderGetIntegerScale_d SDL_RenderGetIntegerScale_f;

        public static bool SDL_RenderGetIntegerScale(SDL_Renderer renderer) => SDL_RenderGetIntegerScale_f(renderer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_RenderGetLogicalSize_d(SDL_Renderer renderer, int* w, int* h);

        private static SDL_RenderGetLogicalSize_d SDL_RenderGetLogicalSize_f;

        public static void SDL_RenderGetLogicalSize(SDL_Renderer renderer, int* w, int* h) => SDL_RenderGetLogicalSize_f(renderer, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_RenderGetScale_d(SDL_Renderer renderer, float* scaleX, float* scaleY);

        private static SDL_RenderGetScale_d SDL_RenderGetScale_f;

        public static void SDL_RenderGetScale(SDL_Renderer renderer, float* scaleX, float* scaleY) => SDL_RenderGetScale_f(renderer, scaleX, scaleY);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_RenderGetViewport_d(SDL_Renderer renderer, SDL_Rect* rect);

        private static SDL_RenderGetViewport_d SDL_RenderGetViewport_f;

        public static void SDL_RenderGetViewport(SDL_Renderer renderer, SDL_Rect* rect) => SDL_RenderGetViewport_f(renderer, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_RenderIsClipEnabled_d(SDL_Renderer renderer);

        private static SDL_RenderIsClipEnabled_d SDL_RenderIsClipEnabled_f;

        public static bool SDL_RenderIsClipEnabled(SDL_Renderer renderer) => SDL_RenderIsClipEnabled_f(renderer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_RenderPresent_d(SDL_Renderer renderer);

        private static SDL_RenderPresent_d SDL_RenderPresent_f;

        public static void SDL_RenderPresent(SDL_Renderer renderer) => SDL_RenderPresent_f(renderer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderReadPixels_d(SDL_Renderer renderer, SDL_Rect* rect, uint format, void* pixels, int pitch);

        private static SDL_RenderReadPixels_d SDL_RenderReadPixels_f;

        public static int SDL_RenderReadPixels(SDL_Renderer renderer, SDL_Rect* rect, uint format, void* pixels, int pitch) => SDL_RenderReadPixels_f(renderer, rect, format, pixels, pitch);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderSetClipRect_d(SDL_Renderer renderer, SDL_Rect* rect);

        private static SDL_RenderSetClipRect_d SDL_RenderSetClipRect_f;

        public static int SDL_RenderSetClipRect(SDL_Renderer renderer, SDL_Rect* rect) => SDL_RenderSetClipRect_f(renderer, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderSetIntegerScale_d(SDL_Renderer renderer, bool enable);

        private static SDL_RenderSetIntegerScale_d SDL_RenderSetIntegerScale_f;

        public static int SDL_RenderSetIntegerScale(SDL_Renderer renderer, bool enable) => SDL_RenderSetIntegerScale_f(renderer, enable);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderSetLogicalSize_d(SDL_Renderer renderer, int w, int h);

        private static SDL_RenderSetLogicalSize_d SDL_RenderSetLogicalSize_f;

        public static int SDL_RenderSetLogicalSize(SDL_Renderer renderer, int w, int h) => SDL_RenderSetLogicalSize_f(renderer, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderSetScale_d(SDL_Renderer renderer, float scaleX, float scaleY);

        private static SDL_RenderSetScale_d SDL_RenderSetScale_f;

        public static int SDL_RenderSetScale(SDL_Renderer renderer, float scaleX, float scaleY) => SDL_RenderSetScale_f(renderer, scaleX, scaleY);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_RenderSetViewport_d(SDL_Renderer renderer, SDL_Rect* rect);

        private static SDL_RenderSetViewport_d SDL_RenderSetViewport_f;

        public static int SDL_RenderSetViewport(SDL_Renderer renderer, SDL_Rect* rect) => SDL_RenderSetViewport_f(renderer, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_RenderTargetSupported_d(SDL_Renderer renderer);

        private static SDL_RenderTargetSupported_d SDL_RenderTargetSupported_f;

        public static bool SDL_RenderTargetSupported(SDL_Renderer renderer) => SDL_RenderTargetSupported_f(renderer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetRenderDrawBlendMode_d(SDL_Renderer renderer, SDL_BlendMode blendMode);

        private static SDL_SetRenderDrawBlendMode_d SDL_SetRenderDrawBlendMode_f;

        public static int SDL_SetRenderDrawBlendMode(SDL_Renderer renderer, SDL_BlendMode blendMode) => SDL_SetRenderDrawBlendMode_f(renderer, blendMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetRenderDrawColor_d(SDL_Renderer renderer, byte r, byte g, byte b, byte a);

        private static SDL_SetRenderDrawColor_d SDL_SetRenderDrawColor_f;

        public static int SDL_SetRenderDrawColor(SDL_Renderer renderer, byte r, byte g, byte b, byte a) => SDL_SetRenderDrawColor_f(renderer, r, g, b, a);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetRenderTarget_d(SDL_Renderer renderer, SDL_Texture texture);

        private static SDL_SetRenderTarget_d SDL_SetRenderTarget_f;

        public static int SDL_SetRenderTarget(SDL_Renderer renderer, SDL_Texture texture) => SDL_SetRenderTarget_f(renderer, texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetTextureAlphaMod_d(SDL_Texture texture, byte alpha);

        private static SDL_SetTextureAlphaMod_d SDL_SetTextureAlphaMod_f;

        public static int SDL_SetTextureAlphaMod(SDL_Texture texture, byte alpha) => SDL_SetTextureAlphaMod_f(texture, alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetTextureBlendMode_d(SDL_Texture texture, SDL_BlendMode blendMode);

        private static SDL_SetTextureBlendMode_d SDL_SetTextureBlendMode_f;

        public static int SDL_SetTextureBlendMode(SDL_Texture texture, SDL_BlendMode blendMode) => SDL_SetTextureBlendMode_f(texture, blendMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetTextureColorMod_d(SDL_Texture texture, byte r, byte g, byte b);

        private static SDL_SetTextureColorMod_d SDL_SetTextureColorMod_f;

        public static int SDL_SetTextureColorMod(SDL_Texture texture, byte r, byte g, byte b) => SDL_SetTextureColorMod_f(texture, r, g, b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_UnlockTexture_d(SDL_Texture texture);

        private static SDL_UnlockTexture_d SDL_UnlockTexture_f;

        public static void SDL_UnlockTexture(SDL_Texture texture) => SDL_UnlockTexture_f(texture);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_UpdateTexture_d(SDL_Texture texture, SDL_Rect* rect, void* pixels, int pitch);

        private static SDL_UpdateTexture_d SDL_UpdateTexture_f;

        public static int SDL_UpdateTexture(SDL_Texture texture, SDL_Rect* rect, void* pixels, int pitch) => SDL_UpdateTexture_f(texture, rect, pixels, pitch);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_UpdateYUVTexture_d(SDL_Texture texture, SDL_Rect* rect, byte* Yplane, int Ypitch, byte* Uplane, int Upitch, byte* Vplane, int Vpitch);

        private static SDL_UpdateYUVTexture_d SDL_UpdateYUVTexture_f;

        public static int SDL_UpdateYUVTexture(SDL_Texture texture, SDL_Rect* rect, byte* Yplane, int Ypitch, byte* Uplane, int Upitch, byte* Vplane, int Vpitch) => SDL_UpdateYUVTexture_f(texture, rect, Yplane, Ypitch, Uplane, Upitch, Vplane, Vpitch);
    }
}

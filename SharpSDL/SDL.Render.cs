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

            public static implicit operator SDL_Renderer(IntPtr ptr)
            {
                return new SDL_Renderer(ptr);
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

            public static implicit operator SDL_Texture(IntPtr ptr)
            {
                return new SDL_Texture(ptr);
            }
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Renderer SDL_CreateRenderer(SDL_Window window, int index, SDL_RendererFlags flags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Renderer SDL_CreateSoftwareRenderer(SDL_Surface* surface);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Texture SDL_CreateTexture(SDL_Renderer renderer, uint format, SDL_TextureAccess access, int w, int h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Texture SDL_CreateTextureFromSurface(SDL_Renderer renderer, SDL_Surface* surface);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CreateWindowAndRenderer(int width, int height, SDL_WindowFlags window_flags, SDL_Window* window, SDL_Renderer* renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyRenderer(SDL_Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyTexture(SDL_Texture texture);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumRenderDrivers();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawBlendMode(SDL_Renderer renderer, SDL_BlendMode* blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawColor(SDL_Renderer renderer, byte* r, byte* g, byte* b, byte* a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDriverInfo(int index, SDL_RendererInfo* info);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Texture SDL_GetRenderTarget(SDL_Renderer* renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Renderer* SDL_GetRenderer(SDL_Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererInfo(SDL_Renderer renderer, SDL_RendererInfo* info);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererOutputSize(SDL_Renderer renderer, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureAlphaMod(SDL_Texture texture, byte* alpha);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureBlendMode(SDL_Texture texture, SDL_BlendMode* blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureColorMod(SDL_Texture texture, byte* r, byte* g, byte* b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(SDL_Texture texture, SDL_Rect* rect, void** pixels, int* pitch);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueryTexture(SDL_Texture texture, uint* format, SDL_TextureAccess* access, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderClear(SDL_Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(SDL_Renderer renderer, SDL_Texture texture, SDL_Rect* srcrect, SDL_Rect* dstrect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(SDL_Renderer renderer, SDL_Texture texture, SDL_Rect* srcrect, SDL_Rect* dstrect, double angle, SDL_Point* center, SDL_RendererFlip flip);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLine(SDL_Renderer renderer, int x1, int y1, int x2, int y2);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLines(SDL_Renderer renderer, SDL_Point* points, int count);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoint(SDL_Renderer renderer, int x, int y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoints(SDL_Renderer renderer, SDL_Point* points, int count);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(SDL_Renderer renderer, SDL_Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRects(SDL_Renderer renderer, SDL_Rect* rects, int count);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(SDL_Renderer renderer, SDL_Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRects(SDL_Renderer renderer, SDL_Rect* rects, int count);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetClipRect(SDL_Renderer renderer, SDL_Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_RenderGetIntegerScale(SDL_Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetLogicalSize(SDL_Renderer renderer, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetScale(SDL_Renderer renderer, float* scaleX, float* scaleY);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetViewport(SDL_Renderer renderer, SDL_Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_RenderIsClipEnabled(SDL_Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderPresent(SDL_Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderReadPixels(SDL_Renderer renderer, SDL_Rect* rect, uint format, void* pixels, int pitch);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(SDL_Renderer renderer, SDL_Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetIntegerScale(SDL_Renderer renderer, bool enable);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetLogicalSize(SDL_Renderer renderer, int w, int h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetScale(SDL_Renderer renderer, float scaleX, float scaleY);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetViewport(SDL_Renderer renderer, SDL_Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_RenderTargetSupported(SDL_Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawBlendMode(SDL_Renderer renderer, SDL_BlendMode blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawColor(SDL_Renderer renderer, byte r, byte g, byte b, byte a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderTarget(SDL_Renderer renderer, SDL_Texture texture);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureAlphaMod(SDL_Texture texture, byte alpha);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureBlendMode(SDL_Texture texture, SDL_BlendMode blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureColorMod(SDL_Texture texture, byte r, byte g, byte b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockTexture(SDL_Texture texture);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(SDL_Texture texture, SDL_Rect* rect, void* pixels, int pitch);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateYUVTexture(SDL_Texture texture, SDL_Rect* rect, byte* Yplane, int Ypitch, byte* Uplane, int Upitch, byte* Vplane, int Vpitch);
    }
}

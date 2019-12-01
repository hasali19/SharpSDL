using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [Flags]
        public enum RendererFlags : uint
        {
            Software = 0x00000001,
            Accelerated = 0x00000002,
            PresentVsync = 0x00000004,
            TargetTexture = 0x00000008
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RendererInfo
        {
            public byte* Name;
            public RendererFlags Flags;
            public uint NumTextureFormats;
            public fixed uint TextureFormats[16];
            public int MaxTextureWidth;
            public int MaxTextureHeight;
        }

        public enum TextureAccess
        {
            Static,
            Streaming,
            Target
        }

        [Flags]
        public enum TextureModulate : uint
        {
            None = 0x00000000,
            Color = 0x00000001,
            Alpha = 0x00000002
        }

        [Flags]
        public enum RendererFlip : uint
        {
            None = 0x00000000,
            Horizontal = 0x00000001,
            Vertical = 0x00000002
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Renderer
        {
            private readonly IntPtr ptr;

            public Renderer(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(Renderer renderer)
            {
                return renderer.ptr;
            }

            public static implicit operator Renderer(IntPtr ptr)
            {
                return new Renderer(ptr);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Texture
        {
            private readonly IntPtr ptr;

            public Texture(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(Texture texture)
            {
                return texture.ptr;
            }

            public static implicit operator Texture(IntPtr ptr)
            {
                return new Texture(ptr);
            }
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Renderer CreateRenderer(Window window, int index, RendererFlags flags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Renderer CreateSoftwareRenderer(Surface* surface);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture CreateTexture(Renderer renderer, uint format, TextureAccess access, int w, int h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture CreateTextureFromSurface(Renderer renderer, Surface* surface);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CreateWindowAndRenderer(int width, int height, WindowFlags window_flags, Window* window, Renderer* renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyRenderer(Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyTexture(Texture texture);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumRenderDrivers();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderDrawBlendMode(Renderer renderer, BlendMode* blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderDrawColor(Renderer renderer, byte* r, byte* g, byte* b, byte* a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRenderDriverInfo(int index, RendererInfo* info);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Texture GetRenderTarget(Renderer* renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Renderer* GetRenderer(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRendererInfo(Renderer renderer, RendererInfo* info);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetRendererOutputSize(Renderer renderer, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTextureAlphaMod(Texture texture, byte* alpha);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTextureBlendMode(Texture texture, BlendMode* blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetTextureColorMod(Texture texture, byte* r, byte* g, byte* b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LockTexture(Texture texture, Rect* rect, void** pixels, int* pitch);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTexture(Texture texture, uint* format, TextureAccess* access, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderClear(Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderCopy(Renderer renderer, Texture texture, Rect* srcrect, Rect* dstrect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderCopyEx(Renderer renderer, Texture texture, Rect* srcrect, Rect* dstrect, double angle, Point* center, RendererFlip flip);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderDrawLine(Renderer renderer, int x1, int y1, int x2, int y2);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderDrawLines(Renderer renderer, Point* points, int count);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderDrawPoint(Renderer renderer, int x, int y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderDrawPoints(Renderer renderer, Point* points, int count);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderDrawRect(Renderer renderer, Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderDrawRects(Renderer renderer, Rect* rects, int count);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderFillRect(Renderer renderer, Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderFillRects(Renderer renderer, Rect* rects, int count);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RenderGetClipRect(Renderer renderer, Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderGetIntegerScale(Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RenderGetLogicalSize(Renderer renderer, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RenderGetScale(Renderer renderer, float* scaleX, float* scaleY);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RenderGetViewport(Renderer renderer, Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderIsClipEnabled(Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RenderPresent(Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderReadPixels(Renderer renderer, Rect* rect, uint format, void* pixels, int pitch);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderSetClipRect(Renderer renderer, Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderSetIntegerScale(Renderer renderer, bool enable);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderSetLogicalSize(Renderer renderer, int w, int h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderSetScale(Renderer renderer, float scaleX, float scaleY);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int RenderSetViewport(Renderer renderer, Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool RenderTargetSupported(Renderer renderer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRenderDrawBlendMode(Renderer renderer, BlendMode blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRenderDrawColor(Renderer renderer, byte r, byte g, byte b, byte a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetRenderTarget(Renderer renderer, Texture texture);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetTextureAlphaMod(Texture texture, byte alpha);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetTextureBlendMode(Texture texture, BlendMode blendMode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetTextureColorMod(Texture texture, byte r, byte g, byte b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnlockTexture(Texture texture);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTexture(Texture texture, Rect* rect, void* pixels, int pitch);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateYUVTexture(Texture texture, Rect* rect, byte* Yplane, int Ypitch, byte* Uplane, int Upitch, byte* Vplane, int Vpitch);
    }
}

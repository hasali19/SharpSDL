using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_GLContext
        {
            private IntPtr ptr;

            public SDL_GLContext(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(SDL_GLContext context)
            {
                return context.ptr;
            }
        }

        public enum SDL_GLattr
        {
            SDL_GL_RED_SIZE,
            SDL_GL_GREEN_SIZE,
            SDL_GL_BLUE_SIZE,
            SDL_GL_ALPHA_SIZE,
            SDL_GL_BUFFER_SIZE,
            SDL_GL_DOUBLEBUFFER,
            SDL_GL_DEPTH_SIZE,
            SDL_GL_STENCIL_SIZE,
            SDL_GL_ACCUM_RED_SIZE,
            SDL_GL_ACCUM_GREEN_SIZE,
            SDL_GL_ACCUM_BLUE_SIZE,
            SDL_GL_ACCUM_ALPHA_SIZE,
            SDL_GL_STEREO,
            SDL_GL_MULTISAMPLEBUFFERS,
            SDL_GL_MULTISAMPLESAMPLES,
            SDL_GL_ACCELERATED_VISUAL,
            SDL_GL_RETAINED_BACKING,
            SDL_GL_CONTEXT_MAJOR_VERSION,
            SDL_GL_CONTEXT_MINOR_VERSION,
            SDL_GL_CONTEXT_EGL,
            SDL_GL_CONTEXT_FLAGS,
            SDL_GL_CONTEXT_PROFILE_MASK,
            SDL_GL_SHARE_WITH_CURRENT_CONTEXT,
            SDL_GL_FRAMEBUFFER_SRGB_CAPABLE,
            SDL_GL_CONTEXT_RELEASE_BEHAVIOR,
            SDL_GL_CONTEXT_RESET_NOTIFICATION,
            SDL_GL_CONTEXT_NO_ERROR
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GLContext SDL_GL_CreateContext(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_DeleteContext(SDL_GLContext context);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_GL_ExtensionSupported(string extension);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetAttribute(SDL_GLattr attr, out int value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GLContext SDL_GL_GetCurrentContext();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Window SDL_GL_GetCurrentWindow();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void SDL_GL_GetDrawableSize(SDL_Window window, int* width, int* height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetProcAddress(string proc);
        public static T SDL_GL_GetProcDelegate<T>(string proc) where T : class
        {
            return Marshal.GetDelegateForFunctionPointer<T>(SDL_GL_GetProcAddress(proc));
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetSwapInterval();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_LoadLibrary(string path);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_MakeCurrent(SDL_Window window, SDL_GLContext context);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_ResetAttributes();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetAttribute(SDL_GLattr attr, int value);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetSwapInterval(int interval);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_SwapWindow(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_UnloadLibrary();
    }
}

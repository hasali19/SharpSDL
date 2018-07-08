using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_GLContext SDL_GL_CreateContext_d(SDL_Window window);

        private static SDL_GL_CreateContext_d SDL_GL_CreateContext_f;

        public static SDL_GLContext SDL_GL_CreateContext(SDL_Window window) => SDL_GL_CreateContext_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GL_DeleteContext_d(SDL_GLContext context);

        private static SDL_GL_DeleteContext_d SDL_GL_DeleteContext_f;

        public static void SDL_GL_DeleteContext(SDL_GLContext context) => SDL_GL_DeleteContext_f(context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_GL_ExtensionSupported_d(string extension);

        private static SDL_GL_ExtensionSupported_d SDL_GL_ExtensionSupported_f;

        public static bool SDL_GL_ExtensionSupported(string extension) => SDL_GL_ExtensionSupported_f(extension);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_GetAttribute_d(SDL_GLattr attr, int* value);

        private static SDL_GL_GetAttribute_d SDL_GL_GetAttribute_f;

        public static int SDL_GL_GetAttribute(SDL_GLattr attr, int* value) => SDL_GL_GetAttribute_f(attr, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_GLContext SDL_GL_GetCurrentContext_d();

        private static SDL_GL_GetCurrentContext_d SDL_GL_GetCurrentContext_f;

        public static SDL_GLContext SDL_GL_GetCurrentContext() => SDL_GL_GetCurrentContext_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_GL_GetCurrentWindow_d();

        private static SDL_GL_GetCurrentWindow_d SDL_GL_GetCurrentWindow_f;

        public static SDL_Window SDL_GL_GetCurrentWindow() => SDL_GL_GetCurrentWindow_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GL_GetDrawableSize_d(SDL_Window window, int* width, int* height);

        private static SDL_GL_GetDrawableSize_d SDL_GL_GetDrawableSize_f;

        public static void SDL_GL_GetDrawableSize(SDL_Window window, int* width, int* height) => SDL_GL_GetDrawableSize_f(window, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr SDL_GL_GetProcAddress_d(string proc);

        private static SDL_GL_GetProcAddress_d SDL_GL_GetProcAddress_f;

        public static IntPtr SDL_GL_GetProcAddress(string proc) => SDL_GL_GetProcAddress_f(proc);

        public static T SDL_GL_GetProcDelegate<T>(string proc) where T : class
        {
            return Marshal.GetDelegateForFunctionPointer<T>(SDL_GL_GetProcAddress(proc));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_GetSwapInterval_d();

        private static SDL_GL_GetSwapInterval_d SDL_GL_GetSwapInterval_f;

        public static int SDL_GL_GetSwapInterval() => SDL_GL_GetSwapInterval_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_LoadLibrary_d(string path);

        private static SDL_GL_LoadLibrary_d SDL_GL_LoadLibrary_f;

        public static int SDL_GL_LoadLibrary(string path) => SDL_GL_LoadLibrary_f(path);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_MakeCurrent_d(SDL_Window window, SDL_GLContext context);

        private static SDL_GL_MakeCurrent_d SDL_GL_MakeCurrent_f;

        public static int SDL_GL_MakeCurrent(SDL_Window window, SDL_GLContext context) => SDL_GL_MakeCurrent_f(window, context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GL_ResetAttributes_d();

        private static SDL_GL_ResetAttributes_d SDL_GL_ResetAttributes_f;

        public static void SDL_GL_ResetAttributes() => SDL_GL_ResetAttributes_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_SetAttribute_d(SDL_GLattr attr, int value);

        private static SDL_GL_SetAttribute_d SDL_GL_SetAttribute_f;

        public static int SDL_GL_SetAttribute(SDL_GLattr attr, int value) => SDL_GL_SetAttribute_f(attr, value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GL_SetSwapInterval_d(int interval);

        private static SDL_GL_SetSwapInterval_d SDL_GL_SetSwapInterval_f;

        public static int SDL_GL_SetSwapInterval(int interval) => SDL_GL_SetSwapInterval_f(interval);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GL_SwapWindow_d(SDL_Window window);

        private static SDL_GL_SwapWindow_d SDL_GL_SwapWindow_f;

        public static void SDL_GL_SwapWindow(SDL_Window window) => SDL_GL_SwapWindow_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GL_UnloadLibrary_d();

        private static SDL_GL_UnloadLibrary_d SDL_GL_UnloadLibrary_f;

        public static void SDL_GL_UnloadLibrary() => SDL_GL_UnloadLibrary_f();
    }
}

using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct GLContext
        {
            private readonly IntPtr ptr;

            public GLContext(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(GLContext context)
            {
                return context.ptr;
            }

            public static implicit operator GLContext(IntPtr ptr)
            {
                return new GLContext(ptr);
            }
        }

        public enum GLAttr
        {
            RedSize,
            GreenSize,
            BlueSize,
            AlphaSize,
            BufferSize,
            DoubleBuffer,
            DepthSize,
            StencilSize,
            AccumRedSize,
            AccumGreenSize,
            AccumBlueSize,
            AccumAlphaSize,
            Stereo,
            MultiSampleBuffers,
            MultiSampleSamples,
            AcceleratedVisual,
            RetainedBacking,
            ContextMajorVersion,
            ContextMinorVersion,
            ContextEGL,
            ContextFlags,
            ContextProfileMask,
            ShareWithCurrentContext,
            FramebufferSRGBCapable,
            ContextReleaseBehaviour,
            ContextResetNotification,
            ContextNoError
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GL_BindTexture(Texture texture, float* texw, float* texh);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GLContext GL_CreateContext(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GL_DeleteContext(GLContext context);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GL_ExtensionSupported(string extension);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GL_GetAttribute(GLAttr attr, int* value);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern GLContext GL_GetCurrentContext();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Window GL_GetCurrentWindow();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GL_GetDrawableSize(Window window, int* width, int* height);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GL_GetProcAddress(string proc);

        public static T GL_GetProcDelegate<T>(string proc) where T : class
        {
            return Marshal.GetDelegateForFunctionPointer<T>(GL_GetProcAddress(proc));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GL_GetSwapInterval();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GL_LoadLibrary(string path);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GL_MakeCurrent(Window window, GLContext context);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GL_ResetAttributes();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GL_SetAttribute(GLAttr attr, int value);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GL_SetSwapInterval(int interval);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GL_SwapWindow(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GL_UnbindTexture(Texture texture);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GL_UnloadLibrary();
    }
}

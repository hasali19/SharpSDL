using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
    {
        public const int SDL_WINDOWPOS_UNDEFINED = 0x1FFF0000;
        public const int SDL_WINDOWPOS_CENTERED = 0x2FFF0000;

        [Flags]
        public enum SDL_WindowFlags : uint
        {
            SDL_WINDOW_FULLSCREEN = 0x00000001,
            SDL_WINDOW_OPENGL = 0x00000002,
            SDL_WINDOW_SHOWN = 0x00000004,
            SDL_WINDOW_HIDDEN = 0x00000008,
            SDL_WINDOW_BORDERLESS = 0x00000010,
            SDL_WINDOW_RESIZABLE = 0x00000020,
            SDL_WINDOW_MINIMIZED = 0x00000040,
            SDL_WINDOW_MAXIMIZED = 0x00000080,
            SDL_WINDOW_INPUT_GRABBED = 0x00000100,
            SDL_WINDOW_INPUT_FOCUS = 0x00000200,
            SDL_WINDOW_MOUSE_FOCUS = 0x00000400,
            SDL_WINDOW_FULLSCREEN_DESKTOP = (SDL_WINDOW_FULLSCREEN | 0x00001000),
            SDL_WINDOW_FOREIGN = 0x00000800,
            SDL_WINDOW_ALLOW_HIGHDPI = 0x00002000,
            SDL_WINDOW_MOUSE_CAPTURE = 0x00004000,
            SDL_WINDOW_ALWAYS_ON_TOP = 0x00008000,
            SDL_WINDOW_SKIP_TASKBAR = 0x00010000,
            SDL_WINDOW_UTILITY = 0x00020000,
            SDL_WINDOW_TOOLTIP = 0x00040000,
            SDL_WINDOW_POPUP_MENU = 0x00080000,
            SDL_WINDOW_VULKAN = 0x10000000
        }

        public enum SDL_HitTestResult
        {
            SDL_HITTEST_NORMAL,
            SDL_HITTEST_DRAGGABLE,
            SDL_HITTEST_RESIZE_TOPLEFT,
            SDL_HITTEST_RESIZE_TOP,
            SDL_HITTEST_RESIZE_TOPRIGHT,
            SDL_HITTEST_RESIZE_RIGHT,
            SDL_HITTEST_RESIZE_BOTTOMRIGHT,
            SDL_HITTEST_RESIZE_BOTTOM,
            SDL_HITTEST_RESIZE_BOTTOMLEFT,
            SDL_HITTEST_RESIZE_LEFT
        }

        public enum SDL_WindowEventID
        {
            SDL_WINDOWEVENT_NONE,
            SDL_WINDOWEVENT_SHOWN,
            SDL_WINDOWEVENT_HIDDEN,
            SDL_WINDOWEVENT_EXPOSED,
            SDL_WINDOWEVENT_MOVED,
            SDL_WINDOWEVENT_RESIZED,
            SDL_WINDOWEVENT_SIZE_CHANGED,
            SDL_WINDOWEVENT_MINIMIZED,
            SDL_WINDOWEVENT_MAXIMIZED,
            SDL_WINDOWEVENT_RESTORED,
            SDL_WINDOWEVENT_ENTER,
            SDL_WINDOWEVENT_LEAVE,
            SDL_WINDOWEVENT_FOCUS_GAINED,
            SDL_WINDOWEVENT_FOCUS_LOST,
            SDL_WINDOWEVENT_CLOSE,
            SDL_WINDOWEVENT_TAKE_FOCUS,
            SDL_WINDOWEVENT_HIT_TEST
        }

        public enum SDL_GLprofile
        {
            SDL_GL_CONTEXT_PROFILE_CORE = 0x0001,
            SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = 0x0002,
            SDL_GL_CONTEXT_PROFILE_ES = 0x0004 /**< GLX_CONTEXT_ES2_PROFILE_BIT_EXT */
        }

        public enum SDL_GLcontextFlag
        {
            SDL_GL_CONTEXT_DEBUG_FLAG = 0x0001,
            SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 0x0002,
            SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = 0x0004,
            SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = 0x0008
        }

        public enum SDL_GLcontextReleaseBehaviour
        {
            SDL_GL_CONTEXT_RELEASE_BEHAVIOR_NONE = 0x0000,
            SDL_GL_CONTEXT_RELEASE_BEHAVIOR_FLUSH = 0x0001
        }

        public enum SDL_GLContextResetNotification
        {
            SDL_GL_CONTEXT_RESET_NO_NOTIFICATION = 0x0000,
            SDL_GL_CONTEXT_RESET_LOSE_CONTEXT = 0x0001
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Window
        {
            private IntPtr ptr;

            public SDL_Window(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(SDL_Window window)
            {
                return window.ptr;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_DisplayMode
        {
            public uint format;
            public int w;
            public int h;
            public int refreshrate;
            public IntPtr driverdata;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate SDL_HitTestResult SDL_HitTest(SDL_Window window, SDL_Point* area, void* data);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Window SDL_CreateWindow(
            string title, int x, int y, int width, int height, SDL_WindowFlags flags);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Window SDL_CreateWindowFrom(IntPtr nativeWindow);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Window SDL_DestroyWindow(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DisableScreenSaver();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_EnableScreenSaver();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe SDL_DisplayMode* SDL_GetClosestDisplayMode(
            int displayIndex, SDL_DisplayMode* mode, SDL_DisplayMode* closest);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetCurrentDisplayMode(int displayIndex,
            SDL_DisplayMode* mode);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetCurrentVideoDriver();
        public static unsafe string SDL_GetCurrentVideoDriverString()
        {
            return GetString(SDL_GetCurrentVideoDriver());
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetDesktopDisplayMode(int displayIndex,
            SDL_DisplayMode* mode);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetDisplayBounds(int displayIndex,
            SDL_Rect* rect);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetDisplayDPI(int displayIndex,
            float* ddpi, float* hdpi, float* vdpi);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetDisplayMode(int displayIndex,
            int modeIndex, SDL_DisplayMode* mode);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetDisplayName(int displayIndex);
        public static unsafe string SDL_GetDisplayNameString(int displayIndex)
        {
            return GetString(SDL_GetDisplayName(displayIndex));
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetDisplayUsableBounds(int displayIndex,
            SDL_Rect* rect);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Window SDL_GetGrabbedWindow();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumDisplayModes(int displayIndex);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDisplays();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDrivers();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetVideoDriver(int index);
        public static unsafe string SDL_GetVideoDriverString(int index)
        {
            return GetString(SDL_GetVideoDriver(index));
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetWindowBordersSize(SDL_Window window,
            int* top, int* left, int* bottom, int* right);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GetWindowBrightness(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void* SDL_GetWindowData(SDL_Window window,
            string name);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayIndex(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetWindowDisplayMode(SDL_Window window,
            SDL_DisplayMode* mode);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_WindowFlags SDL_GetWindowFlags(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Window SDL_GetWindowFromID(uint id);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void SDL_GetWindowMaximumSize(SDL_Window window,
            int* w, int* h);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void SDL_GetWindowMinimumSize(SDL_Window window,
            int* w, int* h);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_GetWindowOpacity(SDL_Window window,
            float* opacity);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowPixelFormat(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void SDL_GetWindowPosition(SDL_Window window, int* x, int* y);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void SDL_GetWindowSize(SDL_Window window, int* w, int* h);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe byte* SDL_GetWindowTitle(SDL_Window window);
        public static unsafe string SDL_GetWindowTitleString(SDL_Window window)
        {
            return GetString(SDL_GetWindowTitle(window));
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HideWindow(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_IsScreenSaverEnabled();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MaximizeWindow(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MinimizeWindow(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RaiseWindow(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RestoreWindow(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowBordered(SDL_Window window, bool bordered);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowBrightness(SDL_Window window, float brightness);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe void* SDL_SetWindowData(SDL_Window window, string name, void* userdata);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_SetWindowDisplayMode(SDL_Window window, SDL_DisplayMode* mode);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowFullscreen(SDL_Window window, SDL_WindowFlags flags);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_SetWindowGammaRamp(SDL_Window window, ushort* red, ushort* green, ushort* blue);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowGrab(SDL_Window window, bool grabbed);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int SDL_SetWindowHitTest(SDL_Window window, SDL_HitTest callback, void* data);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowInputFocus(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMaximumSize(SDL_Window window, int maxWidth, int maxHeight);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMinimumSize(SDL_Window window, int minWidth, int minHeight);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowModalFor(SDL_Window modalWindow, SDL_Window parentWindow);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowOpacity(SDL_Window window, float opacity);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowPosition(SDL_Window window, int x, int y);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowResizable(SDL_Window window, bool resizable);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowSize(SDL_Window window, int width, int height);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowTitle(SDL_Window window, string title);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ShowWindow(SDL_Window window);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_VideoInit(string driverName);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_VideoQuit();
    }
}

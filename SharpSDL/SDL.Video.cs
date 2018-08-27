using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
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

        public enum SDL_WindowEventID : byte
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
        public delegate SDL_HitTestResult SDL_HitTest(SDL_Window window, SDL_Point* area, void* data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_CreateWindow_d(
                    string title, int x, int y, int width, int height, SDL_WindowFlags flags);

        private static SDL_CreateWindow_d SDL_CreateWindow_f;

        public static SDL_Window SDL_CreateWindow(string title, int x, int y, int width, int height, SDL_WindowFlags flags) => SDL_CreateWindow_f(title, x, y, width, height, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_CreateWindowFrom_d(IntPtr nativeWindow);

        private static SDL_CreateWindowFrom_d SDL_CreateWindowFrom_f;

        public static SDL_Window SDL_CreateWindowFrom(IntPtr nativeWindow) => SDL_CreateWindowFrom_f(nativeWindow);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_DestroyWindow_d(SDL_Window window);

        private static SDL_DestroyWindow_d SDL_DestroyWindow_f;

        public static SDL_Window SDL_DestroyWindow(SDL_Window window) => SDL_DestroyWindow_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DisableScreenSaver_d();

        private static SDL_DisableScreenSaver_d SDL_DisableScreenSaver_f;

        public static void SDL_DisableScreenSaver() => SDL_DisableScreenSaver_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_EnableScreenSaver_d();

        private static SDL_EnableScreenSaver_d SDL_EnableScreenSaver_f;

        public static void SDL_EnableScreenSaver() => SDL_EnableScreenSaver_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_DisplayMode* SDL_GetClosestDisplayMode_d(int displayIndex, SDL_DisplayMode* mode, SDL_DisplayMode* closest);

        private static SDL_GetClosestDisplayMode_d SDL_GetClosestDisplayMode_f;

        public static SDL_DisplayMode* SDL_GetClosestDisplayMode(int displayIndex, SDL_DisplayMode* mode, SDL_DisplayMode* closest) => SDL_GetClosestDisplayMode_f(displayIndex, mode, closest);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetCurrentDisplayMode_d(int displayIndex, SDL_DisplayMode* mode);

        private static SDL_GetCurrentDisplayMode_d SDL_GetCurrentDisplayMode_f;

        public static int SDL_GetCurrentDisplayMode(int displayIndex, SDL_DisplayMode* mode) => SDL_GetCurrentDisplayMode_f(displayIndex, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetCurrentVideoDriver_d();

        private static SDL_GetCurrentVideoDriver_d SDL_GetCurrentVideoDriver_f;

        public static byte* SDL_GetCurrentVideoDriver() => SDL_GetCurrentVideoDriver_f();

        public static string SDL_GetCurrentVideoDriverString()
        {
            return GetString(SDL_GetCurrentVideoDriver());
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetDesktopDisplayMode_d(int displayIndex, SDL_DisplayMode* mode);

        private static SDL_GetDesktopDisplayMode_d SDL_GetDesktopDisplayMode_f;

        public static int SDL_GetDesktopDisplayMode(int displayIndex, SDL_DisplayMode* mode) => SDL_GetDesktopDisplayMode_f(displayIndex, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetDisplayBounds_d(int displayIndex, SDL_Rect* rect);

        private static SDL_GetDisplayBounds_d SDL_GetDisplayBounds_f;

        public static int SDL_GetDisplayBounds(int displayIndex, SDL_Rect* rect) => SDL_GetDisplayBounds_f(displayIndex, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetDisplayDPI_d(int displayIndex, float* ddpi, float* hdpi, float* vdpi);

        private static SDL_GetDisplayDPI_d SDL_GetDisplayDPI_f;

        public static int SDL_GetDisplayDPI(int displayIndex, float* ddpi, float* hdpi, float* vdpi) => SDL_GetDisplayDPI_f(displayIndex, ddpi, hdpi, vdpi);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetDisplayMode_d(int displayIndex, int modeIndex, SDL_DisplayMode* mode);

        private static SDL_GetDisplayMode_d SDL_GetDisplayMode_f;

        public static int SDL_GetDisplayMode(int displayIndex, int modeIndex, SDL_DisplayMode* mode) => SDL_GetDisplayMode_f(displayIndex, modeIndex, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetDisplayName_d(int displayIndex);

        private static SDL_GetDisplayName_d SDL_GetDisplayName_f;

        public static byte* SDL_GetDisplayName(int displayIndex) => SDL_GetDisplayName_f(displayIndex);

        public static string SDL_GetDisplayNameString(int displayIndex)
        {
            return GetString(SDL_GetDisplayName(displayIndex));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetDisplayUsableBounds_d(int displayIndex,
                    SDL_Rect* rect);

        private static SDL_GetDisplayUsableBounds_d SDL_GetDisplayUsableBounds_f;

        public static int SDL_GetDisplayUsableBounds(int displayIndex, SDL_Rect* rect) => SDL_GetDisplayUsableBounds_f(displayIndex, rect);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_GetGrabbedWindow_d();

        private static SDL_GetGrabbedWindow_d SDL_GetGrabbedWindow_f;

        public static SDL_Window SDL_GetGrabbedWindow() => SDL_GetGrabbedWindow_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetNumDisplayModes_d(int displayIndex);

        private static SDL_GetNumDisplayModes_d SDL_GetNumDisplayModes_f;

        public static int SDL_GetNumDisplayModes(int displayIndex) => SDL_GetNumDisplayModes_f(displayIndex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetNumVideoDisplays_d();

        private static SDL_GetNumVideoDisplays_d SDL_GetNumVideoDisplays_f;

        public static int SDL_GetNumVideoDisplays() => SDL_GetNumVideoDisplays_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetNumVideoDrivers_d();

        private static SDL_GetNumVideoDrivers_d SDL_GetNumVideoDrivers_f;

        public static int SDL_GetNumVideoDrivers() => SDL_GetNumVideoDrivers_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetVideoDriver_d(int index);

        private static SDL_GetVideoDriver_d SDL_GetVideoDriver_f;

        public static byte* SDL_GetVideoDriver(int index) => SDL_GetVideoDriver_f(index);

        public static string SDL_GetVideoDriverString(int index)
        {
            return GetString(SDL_GetVideoDriver(index));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowBordersSize_d(SDL_Window window,
                    int* top, int* left, int* bottom, int* right);

        private static SDL_GetWindowBordersSize_d SDL_GetWindowBordersSize_f;

        public static int SDL_GetWindowBordersSize(SDL_Window window, int* top, int* left, int* bottom, int* right) => SDL_GetWindowBordersSize_f(window, top, left, bottom, right);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate float SDL_GetWindowBrightness_d(SDL_Window window);

        private static SDL_GetWindowBrightness_d SDL_GetWindowBrightness_f;

        public static float SDL_GetWindowBrightness(SDL_Window window) => SDL_GetWindowBrightness_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void* SDL_GetWindowData_d(SDL_Window window, string name);

        private static SDL_GetWindowData_d SDL_GetWindowData_f;

        public static void* SDL_GetWindowData(SDL_Window window, string name) => SDL_GetWindowData_f(window, name);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowDisplayIndex_d(SDL_Window window);

        private static SDL_GetWindowDisplayIndex_d SDL_GetWindowDisplayIndex_f;

        public static int SDL_GetWindowDisplayIndex(SDL_Window window) => SDL_GetWindowDisplayIndex_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowDisplayMode_d(SDL_Window window, SDL_DisplayMode* mode);

        private static SDL_GetWindowDisplayMode_d SDL_GetWindowDisplayMode_f;

        public static int SDL_GetWindowDisplayMode(SDL_Window window, SDL_DisplayMode* mode) => SDL_GetWindowDisplayMode_f(window, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_WindowFlags SDL_GetWindowFlags_d(SDL_Window window);

        private static SDL_GetWindowFlags_d SDL_GetWindowFlags_f;

        public static SDL_WindowFlags SDL_GetWindowFlags(SDL_Window window) => SDL_GetWindowFlags_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Window SDL_GetWindowFromID_d(uint id);

        private static SDL_GetWindowFromID_d SDL_GetWindowFromID_f;

        public static SDL_Window SDL_GetWindowFromID(uint id) => SDL_GetWindowFromID_f(id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowMaximumSize_d(SDL_Window window, int* w, int* h);

        private static SDL_GetWindowMaximumSize_d SDL_GetWindowMaximumSize_f;

        public static void SDL_GetWindowMaximumSize(SDL_Window window, int* w, int* h) => SDL_GetWindowMaximumSize_f(window, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowMinimumSize_d(SDL_Window window, int* w, int* h);

        private static SDL_GetWindowMinimumSize_d SDL_GetWindowMinimumSize_f;

        public static void SDL_GetWindowMinimumSize(SDL_Window window, int* w, int* h) => SDL_GetWindowMinimumSize_f(window, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetWindowOpacity_d(SDL_Window window, float* opacity);

        private static SDL_GetWindowOpacity_d SDL_GetWindowOpacity_f;

        public static int SDL_GetWindowOpacity(SDL_Window window, float* opacity) => SDL_GetWindowOpacity_f(window, opacity);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_GetWindowPixelFormat_d(SDL_Window window);

        private static SDL_GetWindowPixelFormat_d SDL_GetWindowPixelFormat_f;

        public static uint SDL_GetWindowPixelFormat(SDL_Window window) => SDL_GetWindowPixelFormat_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowPosition_d(SDL_Window window, int* x, int* y);

        private static SDL_GetWindowPosition_d SDL_GetWindowPosition_f;

        public static void SDL_GetWindowPosition(SDL_Window window, int* x, int* y) => SDL_GetWindowPosition_f(window, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GetWindowSize_d(SDL_Window window, int* w, int* h);

        private static SDL_GetWindowSize_d SDL_GetWindowSize_f;

        public static void SDL_GetWindowSize(SDL_Window window, int* w, int* h) => SDL_GetWindowSize_f(window, w, h);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GetWindowTitle_d(SDL_Window window);

        private static SDL_GetWindowTitle_d SDL_GetWindowTitle_f;

        public static byte* SDL_GetWindowTitle(SDL_Window window) => SDL_GetWindowTitle_f(window);

        public static string SDL_GetWindowTitleString(SDL_Window window)
        {
            return GetString(SDL_GetWindowTitle(window));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_HideWindow_d(SDL_Window window);

        private static SDL_HideWindow_d SDL_HideWindow_f;

        public static void SDL_HideWindow(SDL_Window window) => SDL_HideWindow_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_IsScreenSaverEnabled_d();

        private static SDL_IsScreenSaverEnabled_d SDL_IsScreenSaverEnabled_f;

        public static bool SDL_IsScreenSaverEnabled() => SDL_IsScreenSaverEnabled_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_MaximizeWindow_d(SDL_Window window);

        private static SDL_MaximizeWindow_d SDL_MaximizeWindow_f;

        public static void SDL_MaximizeWindow(SDL_Window window) => SDL_MaximizeWindow_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_MinimizeWindow_d(SDL_Window window);

        private static SDL_MinimizeWindow_d SDL_MinimizeWindow_f;

        public static void SDL_MinimizeWindow(SDL_Window window) => SDL_MinimizeWindow_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_RaiseWindow_d(SDL_Window window);

        private static SDL_RaiseWindow_d SDL_RaiseWindow_f;

        public static void SDL_RaiseWindow(SDL_Window window) => SDL_RaiseWindow_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_RestoreWindow_d(SDL_Window window);

        private static SDL_RestoreWindow_d SDL_RestoreWindow_f;

        public static void SDL_RestoreWindow(SDL_Window window) => SDL_RestoreWindow_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowBordered_d(SDL_Window window, bool bordered);

        private static SDL_SetWindowBordered_d SDL_SetWindowBordered_f;

        public static void SDL_SetWindowBordered(SDL_Window window, bool bordered) => SDL_SetWindowBordered_f(window, bordered);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowBrightness_d(SDL_Window window, float brightness);

        private static SDL_SetWindowBrightness_d SDL_SetWindowBrightness_f;

        public static int SDL_SetWindowBrightness(SDL_Window window, float brightness) => SDL_SetWindowBrightness_f(window, brightness);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void* SDL_SetWindowData_d(SDL_Window window, string name, void* userdata);

        private static SDL_SetWindowData_d SDL_SetWindowData_f;

        public static void* SDL_SetWindowData(SDL_Window window, string name, void* userdata) => SDL_SetWindowData_f(window, name, userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowDisplayMode_d(SDL_Window window, SDL_DisplayMode* mode);

        private static SDL_SetWindowDisplayMode_d SDL_SetWindowDisplayMode_f;

        public static int SDL_SetWindowDisplayMode(SDL_Window window, SDL_DisplayMode* mode) => SDL_SetWindowDisplayMode_f(window, mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowFullscreen_d(SDL_Window window, SDL_WindowFlags flags);

        private static SDL_SetWindowFullscreen_d SDL_SetWindowFullscreen_f;

        public static int SDL_SetWindowFullscreen(SDL_Window window, SDL_WindowFlags flags) => SDL_SetWindowFullscreen_f(window, flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowGammaRamp_d(SDL_Window window, ushort* red, ushort* green, ushort* blue);

        private static SDL_SetWindowGammaRamp_d SDL_SetWindowGammaRamp_f;

        public static int SDL_SetWindowGammaRamp(SDL_Window window, ushort* red, ushort* green, ushort* blue) => SDL_SetWindowGammaRamp_f(window, red, green, blue);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowGrab_d(SDL_Window window, bool grabbed);

        private static SDL_SetWindowGrab_d SDL_SetWindowGrab_f;

        public static void SDL_SetWindowGrab(SDL_Window window, bool grabbed) => SDL_SetWindowGrab_f(window, grabbed);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowHitTest_d(SDL_Window window, SDL_HitTest callback, void* data);

        private static SDL_SetWindowHitTest_d SDL_SetWindowHitTest_f;

        public static int SDL_SetWindowHitTest(SDL_Window window, SDL_HitTest callback, void* data) => SDL_SetWindowHitTest_f(window, callback, data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowInputFocus_d(SDL_Window window);

        private static SDL_SetWindowInputFocus_d SDL_SetWindowInputFocus_f;

        public static int SDL_SetWindowInputFocus(SDL_Window window) => SDL_SetWindowInputFocus_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowMaximumSize_d(SDL_Window window, int maxWidth, int maxHeight);

        private static SDL_SetWindowMaximumSize_d SDL_SetWindowMaximumSize_f;

        public static void SDL_SetWindowMaximumSize(SDL_Window window, int maxWidth, int maxHeight) => SDL_SetWindowMaximumSize_f(window, maxWidth, maxHeight);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowMinimumSize_d(SDL_Window window, int minWidth, int minHeight);

        private static SDL_SetWindowMinimumSize_d SDL_SetWindowMinimumSize_f;

        public static void SDL_SetWindowMinimumSize(SDL_Window window, int minWidth, int minHeight) => SDL_SetWindowMinimumSize_f(window, minWidth, minHeight);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowModalFor_d(SDL_Window modalWindow, SDL_Window parentWindow);

        private static SDL_SetWindowModalFor_d SDL_SetWindowModalFor_f;

        public static int SDL_SetWindowModalFor(SDL_Window modalWindow, SDL_Window parentWindow) => SDL_SetWindowModalFor_f(modalWindow, parentWindow);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_SetWindowOpacity_d(SDL_Window window, float opacity);

        private static SDL_SetWindowOpacity_d SDL_SetWindowOpacity_f;

        public static int SDL_SetWindowOpacity(SDL_Window window, float opacity) => SDL_SetWindowOpacity_f(window, opacity);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowPosition_d(SDL_Window window, int x, int y);

        private static SDL_SetWindowPosition_d SDL_SetWindowPosition_f;

        public static void SDL_SetWindowPosition(SDL_Window window, int x, int y) => SDL_SetWindowPosition_f(window, x, y);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowResizable_d(SDL_Window window, bool resizable);

        private static SDL_SetWindowResizable_d SDL_SetWindowResizable_f;

        public static void SDL_SetWindowResizable(SDL_Window window, bool resizable) => SDL_SetWindowResizable_f(window, resizable);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowSize_d(SDL_Window window, int width, int height);

        private static SDL_SetWindowSize_d SDL_SetWindowSize_f;

        public static void SDL_SetWindowSize(SDL_Window window, int width, int height) => SDL_SetWindowSize_f(window, width, height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetWindowTitle_d(SDL_Window window, string title);

        private static SDL_SetWindowTitle_d SDL_SetWindowTitle_f;

        public static void SDL_SetWindowTitle(SDL_Window window, string title) => SDL_SetWindowTitle_f(window, title);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_ShowWindow_d(SDL_Window window);

        private static SDL_ShowWindow_d SDL_ShowWindow_f;

        public static void SDL_ShowWindow(SDL_Window window) => SDL_ShowWindow_f(window);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_VideoInit_d(string driverName);

        private static SDL_VideoInit_d SDL_VideoInit_f;

        public static int SDL_VideoInit(string driverName) => SDL_VideoInit_f(driverName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_VideoQuit_d();

        private static SDL_VideoQuit_d SDL_VideoQuit_f;

        public static void SDL_VideoQuit() => SDL_VideoQuit_f();
    }
}

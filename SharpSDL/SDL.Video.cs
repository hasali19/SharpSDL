using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public const int WINDOWPOS_UNDEFINED = 0x1FFF0000;
        public const int WINDOWPOS_CENTERED = 0x2FFF0000;

        [Flags]
        public enum WindowFlags : uint
        {
            Fullscreen = 0x00000001,
            OpenGL = 0x00000002,
            Shown = 0x00000004,
            Hidden = 0x00000008,
            Borderless = 0x00000010,
            Resizable = 0x00000020,
            Minimized = 0x00000040,
            Maximized = 0x00000080,
            InputGrabbed = 0x00000100,
            InputFocus = 0x00000200,
            MouseFocus = 0x00000400,
            FullscreenDesktop = (Fullscreen | 0x00001000),
            Foreign = 0x00000800,
            AllowHighDPI = 0x00002000,
            MouseCapture = 0x00004000,
            AlwaysOnTop = 0x00008000,
            SkipTaskbar = 0x00010000,
            Utility = 0x00020000,
            Tooltip = 0x00040000,
            PopupMenu = 0x00080000,
            Vulkan = 0x10000000
        }

        public enum HitTestResult
        {
            Normal,
            Draggable,
            ResizeTopLeft,
            ResizeTop,
            ResizeTopRight,
            ResizeRight,
            ResizeBottomRight,
            ResizeBottom,
            ResizeBottomLeft,
            ResizeLeft
        }

        public enum WindowEventID : byte
        {
            None,
            Shown,
            Hidden,
            Exposed,
            Moved,
            Resized,
            SizeChanged,
            Minimized,
            Maximized,
            Restored,
            Enter,
            Leave,
            FocusGained,
            FocusLost,
            Close,
            TakeFocus,
            HitTest
        }

        public enum OpenGLProfile
        {
            Core = 0x0001,
            Compatibility = 0x0002,
            ES = 0x0004
        }

        public enum OpenGLContextFlag
        {
            Debug = 0x0001,
            FowardCompatible = 0x0002,
            RobustAccess = 0x0004,
            ResetIsolation = 0x0008
        }

        public enum OpenGLContextReleaseBehaviour
        {
            None = 0x0000,
            Flush = 0x0001
        }

        public enum OpenGLContextResetNotification
        {
            NoNotification = 0x0000,
            LoseContext = 0x0001
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Window
        {
            private readonly IntPtr ptr;

            public Window(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(Window window)
            {
                return window.ptr;
            }

            public static implicit operator Window(IntPtr ptr)
            {
                return new Window(ptr);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DisplayMode
        {
            public uint Format;
            public int Width;
            public int Height;
            public int RefreshRate;
            public IntPtr DriverData;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate HitTestResult HitTest(Window window, Point* area, void* data);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Window CreateWindow(string title, int x, int y, int width, int height, WindowFlags flags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Window CreateWindowFrom(IntPtr nativeWindow);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Window DestroyWindow(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisableScreenSaver();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableScreenSaver();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern DisplayMode* GetClosestDisplayMode(int displayIndex, DisplayMode* mode, DisplayMode* closest);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCurrentDisplayMode(int displayIndex, DisplayMode* mode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetCurrentVideoDriver();

        public static string GetCurrentVideoDriverString()
        {
            return GetString(GetCurrentVideoDriver());
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDesktopDisplayMode(int displayIndex, DisplayMode* mode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDisplayBounds(int displayIndex, Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDisplayDPI(int displayIndex, float* ddpi, float* hdpi, float* vdpi);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDisplayMode(int displayIndex, int modeIndex, DisplayMode* mode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetDisplayName(int displayIndex);

        public static string GetDisplayNameString(int displayIndex)
        {
            return GetString(GetDisplayName(displayIndex));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDisplayUsableBounds(int displayIndex, Rect* rect);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Window GetGrabbedWindow();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumDisplayModes(int displayIndex);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumVideoDisplays();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumVideoDrivers();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetVideoDriver(int index);

        public static string GetVideoDriverString(int index)
        {
            return GetString(GetVideoDriver(index));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetWindowBordersSize(Window window, int* top, int* left, int* bottom, int* right);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetWindowBrightness(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void* GetWindowData(Window window, string name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetWindowDisplayIndex(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetWindowDisplayMode(Window window, DisplayMode* mode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern WindowFlags GetWindowFlags(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Window GetWindowFromID(uint id);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowMaximumSize(Window window, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowMinimumSize(Window window, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetWindowOpacity(Window window, float* opacity);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetWindowPixelFormat(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowPosition(Window window, int* x, int* y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetWindowSize(Window window, int* w, int* h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* GetWindowTitle(Window window);

        public static string GetWindowTitleString(Window window)
        {
            return GetString(GetWindowTitle(window));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideWindow(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsScreenSaverEnabled();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MaximizeWindow(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MinimizeWindow(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RaiseWindow(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RestoreWindow(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowBordered(Window window, bool bordered);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowBrightness(Window window, float brightness);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void* SetWindowData(Window window, string name, void* userdata);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowDisplayMode(Window window, DisplayMode* mode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowFullscreen(Window window, WindowFlags flags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowGammaRamp(Window window, ushort* red, ushort* green, ushort* blue);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowGrab(Window window, bool grabbed);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowHitTest(Window window, HitTest callback, void* data);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowInputFocus(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMaximumSize(Window window, int maxWidth, int maxHeight);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowMinimumSize(Window window, int minWidth, int minHeight);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowModalFor(Window modalWindow, Window parentWindow);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetWindowOpacity(Window window, float opacity);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowPosition(Window window, int x, int y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowResizable(Window window, bool resizable);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowSize(Window window, int width, int height);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetWindowTitle(Window window, string title);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowWindow(Window window);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VideoInit(string driverName);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void VideoQuit();
    }
}

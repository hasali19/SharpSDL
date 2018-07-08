using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public const byte SDL_QUERY = unchecked((byte)-1);
        public const byte SDL_IGNORE = 0;
        public const byte SDL_DISABLE = 0;
        public const byte SDL_ENABLE = 1;

        public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = 32;
        public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = 32;

        public enum SDL_EventType : uint
        {
            SDL_FIRSTEVENT = 0,

            /* Application events */
            SDL_QUIT = 0x100,

            SDL_APP_TERMINATING,
            SDL_APP_LOWMEMORY,
            SDL_APP_WILLENTERBACKGROUND,
            SDL_APP_DIDENTERBACKGROUND,
            SDL_APP_WILLENTERFOREGROUND,
            SDL_APP_DIDENTERFOREGROUND,

            /* Window events */
            SDL_WINDOWEVENT = 0x200,
            SDL_SYSWMEVENT,

            /* Keyboard events */
            SDL_KEYDOWN = 0x300,
            SDL_KEYUP,
            SDL_TEXTEDITING,
            SDL_TEXTINPUT,
            SDL_KEYMAPCHANGED,

            /* Mouse events */
            SDL_MOUSEMOTION = 0x400,
            SDL_MOUSEBUTTONDOWN,
            SDL_MOUSEBUTTONUP,
            SDL_MOUSEWHEEL,

            /* Joystick events */
            SDL_JOYAXISMOTION = 0x600,
            SDL_JOYBALLMOTION,
            SDL_JOYHATMOTION,
            SDL_JOYBUTTONDOWN,
            SDL_JOYBUTTONUP,
            SDL_JOYDEVICEADDED,
            SDL_JOYDEVICEREMOVED,

            /* Game controller events */
            SDL_CONTROLLERAXISMOTION = 0x650,
            SDL_CONTROLLERBUTTONDOWN,
            SDL_CONTROLLERBUTTONUP,
            SDL_CONTROLLERDEVICEADDED,
            SDL_CONTROLLERDEVICEREMOVED,
            SDL_CONTROLLERDEVICEREMAPPED,

            /* Touch events */
            SDL_FINGERDOWN = 0x700,
            SDL_FINGERUP,
            SDL_FINGERMOTION,

            /* Gesture events */
            SDL_DOLLARGESTURE = 0x800,
            SDL_DOLLARRECORD,
            SDL_MULTIGESTURE,

            /* Clipboard events */
            SDL_CLIPBOARDUPDATE = 0x900,

            /* Drag and drop events */
            SDL_DROPFILE = 0x1000,
            SDL_DROPTEXT,
            SDL_DROPBEGIN,
            SDL_DROPCOMPLETE,

            /* Audio hotplug events */
            SDL_AUDIODEVICEADDED = 0x1100,
            SDL_AUDIODEVICEREMOVED,

            /* Render events */
            SDL_RENDER_TARGETS_RESET = 0x2000,
            SDL_RENDER_DEVICE_RESET,

            SDL_USEREVENT = 0x8000,

            SDL_LASTEVENT = 0xFFFF
        }

        public enum SDL_ButtonState : byte
        {
            SDL_RELEASED = 0,
            SDL_PRESSED = 1
        }

        public enum SDL_eventaction
        {
            SDL_ADDEVENT,
            SDL_PEEKEVENT,
            SDL_GETEVENT
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_CommonEvent
        {
            public SDL_EventType type;
            public uint timestamp;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_WindowEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint windowID;
            public SDL_WindowEventID evt;
            private fixed byte padding[3];
            public int data1;
            public int data2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_KeyboardEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint windowID;
            public SDL_ButtonState state;
            public byte repeat;
            public byte padding2;
            public byte padding3;
            public SDL_Keysym keysym;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_TextEditingEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint windowID;
            public fixed byte text[SDL_TEXTEDITINGEVENT_TEXT_SIZE];
            public int start;
            public int length;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_TextInputEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint windowID;
            public fixed byte text[SDL_TEXTINPUTEVENT_TEXT_SIZE];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseMotionEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint windowID;
            public uint which;
            public SDL_ButtonMask state;
            public int x;
            public int y;
            public int xrel;
            public int yrel;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseButtonEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint windowID;
            public uint which;
            public SDL_Button button;
            public SDL_ButtonState state;
            public byte clicks;
            public byte padding;
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseWheelEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint windowID;
            public uint which;
            public int x;
            public int y;
            public SDL_MouseWheelDirection direction;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_JoyAxisEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            SDL_JoystickID which;
            public byte axis;
            private fixed byte padding[3];
            public short value;
            private ushort padding4;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_JoyBallEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public SDL_JoystickID which;
            public byte ball;
            private fixed byte padding[3];
            public short xrel;
            public short yrel;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyHatEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public SDL_JoystickID which;
            public byte hat;
            public SDL_Hat value;
            private ushort padding;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyButtonEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public SDL_JoystickID which;
            public byte button;
            public SDL_ButtonState state;
            private ushort padding;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyDeviceEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public int which;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_ControllerAxisEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public SDL_JoystickID which;
            public SDL_GameControllerAxis axis;
            private fixed byte padding[3];
            public short value;
            private ushort padding4;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_ControllerButtonEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public SDL_JoystickID which;
            public SDL_GameControllerButton button;
            public SDL_ButtonState state;
            private ushort padding;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_ControllerDeviceEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public int which;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_AudioDeviceEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint which;
            public byte iscapture;
            private fixed byte padding[3];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_TouchFingerEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public SDL_TouchID touchId;
            public SDL_FingerID fingerId;
            public float x;
            public float y;
            public float dx;
            public float dy;
            public float pressure;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MultiGestureEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public SDL_TouchID touchId;
            public float dTheta;
            public float dDist;
            public float x;
            public float y;
            public ushort numFingers;
            private ushort padding;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_DollarGestureEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public SDL_TouchID touchId;
            public long gestureId;
            public uint numFingers;
            public float error;
            public float x;
            public float y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_DropEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public byte* file;
            public uint windowID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_QuitEvent
        {
            public SDL_EventType type;
            public uint timestamp;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_OSEvent
        {
            public SDL_EventType type;
            public uint timestamp;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SDL_UserEvent
        {
            public SDL_EventType type;
            public uint timestamp;
            public uint windowID;
            public int code;
            public void* data1;
            public void* data2;
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct SDL_Event
        {
            [FieldOffset(0)]
            public SDL_EventType type;

            [FieldOffset(0)]
            public SDL_CommonEvent common;

            [FieldOffset(0)]
            public SDL_WindowEvent window;

            [FieldOffset(0)]
            public SDL_KeyboardEvent keyboard;

            [FieldOffset(0)]
            public SDL_TextEditingEvent edit;

            [FieldOffset(0)]
            public SDL_TextInputEvent text;

            [FieldOffset(0)]
            public SDL_MouseMotionEvent motion;

            [FieldOffset(0)]
            public SDL_MouseButtonEvent button;

            [FieldOffset(0)]
            public SDL_MouseWheelEvent wheel;

            [FieldOffset(0)]
            public SDL_JoyAxisEvent jaxis;

            [FieldOffset(0)]
            public SDL_JoyBallEvent jball;

            [FieldOffset(0)]
            public SDL_JoyHatEvent jhat;

            [FieldOffset(0)]
            public SDL_JoyButtonEvent jbutton;

            [FieldOffset(0)]
            public SDL_JoyDeviceEvent jdevice;

            [FieldOffset(0)]
            public SDL_ControllerAxisEvent caxis;

            [FieldOffset(0)]
            public SDL_ControllerButtonEvent cbutton;

            [FieldOffset(0)]
            public SDL_ControllerDeviceEvent cdevice;

            [FieldOffset(0)]
            public SDL_AudioDeviceEvent adevice;

            [FieldOffset(0)]
            public SDL_QuitEvent quit;

            [FieldOffset(0)]
            public SDL_UserEvent user;

            [FieldOffset(0)]
            public SDL_TouchFingerEvent tfinger;

            [FieldOffset(0)]
            public SDL_MultiGestureEvent mgesture;

            [FieldOffset(0)]
            public SDL_DollarGestureEvent dgesture;

            [FieldOffset(0)]
            public SDL_DropEvent drop;

            [FieldOffset(0)]
            private fixed byte padding[56];
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int SDL_EventFilter(void* userdata, SDL_Event* evt);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_AddEventWatch_d(SDL_EventFilter filter, void* userdata);

        private static SDL_AddEventWatch_d SDL_AddEventWatch_f;

        public static void SDL_AddEventWatch(SDL_EventFilter filter, void* userdata) => SDL_AddEventWatch_f(filter, userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_DelEventWatch_d(SDL_EventFilter filter, void* userdata);

        private static SDL_DelEventWatch_d SDL_DelEventWatch_f;

        public static void SDL_DelEventWatch(SDL_EventFilter filter, void* userdata) => SDL_DelEventWatch_f(filter, userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte SDL_EventState_d(SDL_EventType type, int state);

        private static SDL_EventState_d SDL_EventState_f;

        public static byte SDL_EventState(SDL_EventType type, int state) => SDL_EventState_f(type, state);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FilterEvents_d(SDL_EventFilter filter, void* userdata);

        private static SDL_FilterEvents_d SDL_FilterEvents_f;

        public static void SDL_FilterEvents(SDL_EventFilter filter, void* userdata) => SDL_FilterEvents_f(filter, userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FlushEvent_d(SDL_EventType type);

        private static SDL_FlushEvent_d SDL_FlushEvent_f;

        public static void SDL_FlushEvent(SDL_EventType type) => SDL_FlushEvent_f(type);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_FlushEvents_d(SDL_EventType minType, SDL_EventType maxType);

        private static SDL_FlushEvents_d SDL_FlushEvents_f;

        public static void SDL_FlushEvents(SDL_EventType minType, SDL_EventType maxType) => SDL_FlushEvents_f(minType, maxType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_GetEventFilter_d(IntPtr* filter, void** userdata);

        private static SDL_GetEventFilter_d SDL_GetEventFilter_f;

        public static bool SDL_GetEventFilter(IntPtr* filter, void** userdata) => SDL_GetEventFilter_f(filter, userdata);

        public static unsafe bool SDL_GetEventFilter(out SDL_EventFilter filter, void** userdata)
        {
            IntPtr ptr;
            bool result = SDL_GetEventFilter(&ptr, userdata);
            if (result)
                filter = Marshal.GetDelegateForFunctionPointer<SDL_EventFilter>(ptr);
            else
                filter = null;
            return result;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_HasEvent_d(SDL_EventType type);

        private static SDL_HasEvent_d SDL_HasEvent_f;

        public static bool SDL_HasEvent(SDL_EventType type) => SDL_HasEvent_f(type);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_HasEvents_d(SDL_EventType minType, SDL_EventType maxType);

        private static SDL_HasEvents_d SDL_HasEvents_f;

        public static bool SDL_HasEvents(SDL_EventType minType, SDL_EventType maxType) => SDL_HasEvents_f(minType, maxType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_PeepEvents_d(SDL_Event* events, int numevents, SDL_eventaction action, SDL_EventType minType, SDL_EventType maxType);

        private static SDL_PeepEvents_d SDL_PeepEvents_f;

        public static int SDL_PeepEvents(SDL_Event* events, int numevents, SDL_eventaction action, SDL_EventType minType, SDL_EventType maxType) => SDL_PeepEvents_f(events, numevents, action, minType, maxType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_PollEvent_d(SDL_Event* evt);

        private static SDL_PollEvent_d SDL_PollEvent_f;

        public static int SDL_PollEvent(SDL_Event* evt) => SDL_PollEvent_f(evt);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_PumpEvents_d();

        private static SDL_PumpEvents_d SDL_PumpEvents_f;

        public static void SDL_PumpEvents() => SDL_PumpEvents_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_PushEvent_d(SDL_Event* evt);

        private static SDL_PushEvent_d SDL_PushEvent_f;

        public static int SDL_PushEvent(SDL_Event* evt) => SDL_PushEvent_f(evt);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint SDL_RegisterEvents_d(int numevents);

        private static SDL_RegisterEvents_d SDL_RegisterEvents_f;

        public static uint SDL_RegisterEvents(int numevents) => SDL_RegisterEvents_f(numevents);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_SetEventFilter_d(SDL_EventFilter filter, void* userdata);

        private static SDL_SetEventFilter_d SDL_SetEventFilter_f;

        public static void SDL_SetEventFilter(SDL_EventFilter filter, void* userdata) => SDL_SetEventFilter_f(filter, userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_WaitEvent_d(SDL_Event* evt);

        private static SDL_WaitEvent_d SDL_WaitEvent_f;

        public static int SDL_WaitEvent(SDL_Event* evt) => SDL_WaitEvent_f(evt);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_WaitEventTimeout_d(SDL_Event* evt, int timeout);

        private static SDL_WaitEventTimeout_d SDL_WaitEventTimeout_f;

        public static int SDL_WaitEventTimeout(SDL_Event* evt, int timeout) => SDL_WaitEventTimeout_f(evt, timeout);
    }
}

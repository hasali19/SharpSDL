using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public enum SDL_JoystickType
        {
            SDL_JOYSTICK_TYPE_UNKNOWN,
            SDL_JOYSTICK_TYPE_GAMECONTROLLER,
            SDL_JOYSTICK_TYPE_WHEEL,
            SDL_JOYSTICK_TYPE_ARCADE_STICK,
            SDL_JOYSTICK_TYPE_FLIGHT_STICK,
            SDL_JOYSTICK_TYPE_DANCE_PAD,
            SDL_JOYSTICK_TYPE_GUITAR,
            SDL_JOYSTICK_TYPE_DRUM_KIT,
            SDL_JOYSTICK_TYPE_ARCADE_PAD,
            SDL_JOYSTICK_TYPE_THROTTLE
        }

        public enum SDL_JoystickPowerLevel
        {
            SDL_JOYSTICK_POWER_UNKNOWN = -1,
            SDL_JOYSTICK_POWER_EMPTY,
            SDL_JOYSTICK_POWER_LOW,
            SDL_JOYSTICK_POWER_MEDIUM,
            SDL_JOYSTICK_POWER_FULL,
            SDL_JOYSTICK_POWER_WIRED,
            SDL_JOYSTICK_POWER_MAX
        }

        public enum SDL_Hat : byte
        {
            SDL_HAT_CENTERED = 0x00,
            SDL_HAT_UP = 0x01,
            SDL_HAT_RIGHT = 0x02,
            SDL_HAT_DOWN = 0x04,
            SDL_HAT_LEFT = 0x08,

            SDL_HAT_RIGHTUP = SDL_HAT_RIGHT | SDL_HAT_UP,
            SDL_HAT_RIGHTDOWN = SDL_HAT_RIGHT | SDL_HAT_DOWN,
            SDL_HAT_LEFTUP = SDL_HAT_LEFT | SDL_HAT_UP,
            SDL_HAT_LEFTDOWN = SDL_HAT_LEFT | SDL_HAT_DOWN
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Joystick
        {
            private IntPtr ptr;

            public SDL_Joystick(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(SDL_Joystick joystick)
            {
                return joystick.ptr;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoystickID
        {
            private int id;

            public SDL_JoystickID(int id)
            {
                this.id = id;
            }

            public static implicit operator int(SDL_JoystickID joystickID)
            {
                return joystickID.id;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_JoystickClose_d(SDL_Joystick joystick);

        private static SDL_JoystickClose_d SDL_JoystickClose_f;

        public static void SDL_JoystickClose(SDL_Joystick joystick) => SDL_JoystickClose_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel_d(SDL_Joystick joystick);

        private static SDL_JoystickCurrentPowerLevel_d SDL_JoystickCurrentPowerLevel_f;

        public static SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(SDL_Joystick joystick) => SDL_JoystickCurrentPowerLevel_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Joystick SDL_JoystickFromInstanceID_d(SDL_JoystickID joyid);

        private static SDL_JoystickFromInstanceID_d SDL_JoystickFromInstanceID_f;

        public static SDL_Joystick SDL_JoystickFromInstanceID(SDL_JoystickID joyid) => SDL_JoystickFromInstanceID_f(joyid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_JoystickGetAttached_d(SDL_Joystick joystick);

        private static SDL_JoystickGetAttached_d SDL_JoystickGetAttached_f;

        public static bool SDL_JoystickGetAttached(SDL_Joystick joystick) => SDL_JoystickGetAttached_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate short SDL_JoystickGetAxis_d(SDL_Joystick joystick, int axis);

        private static SDL_JoystickGetAxis_d SDL_JoystickGetAxis_f;

        public static short SDL_JoystickGetAxis(SDL_Joystick joystick, int axis) => SDL_JoystickGetAxis_f(joystick, axis);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_JoystickGetBall_d(SDL_Joystick joystick, int ball, int* dx, int* dy);

        private static SDL_JoystickGetBall_d SDL_JoystickGetBall_f;

        public static int SDL_JoystickGetBall(SDL_Joystick joystick, int ball, int* dx, int* dy) => SDL_JoystickGetBall_f(joystick, ball, dx, dy);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte SDL_JoystickGetButton_d(SDL_Joystick joystick, int button);

        private static SDL_JoystickGetButton_d SDL_JoystickGetButton_f;

        public static byte SDL_JoystickGetButton(SDL_Joystick joystick, int button) => SDL_JoystickGetButton_f(joystick, button);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Guid SDL_JoystickGetDeviceGUID_d(int deviceIndex);

        private static SDL_JoystickGetDeviceGUID_d SDL_JoystickGetDeviceGUID_f;

        public static Guid SDL_JoystickGetDeviceGUID(int deviceIndex) => SDL_JoystickGetDeviceGUID_f(deviceIndex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Guid SDL_JoystickGetGUID_d(SDL_Joystick joystick);

        private static SDL_JoystickGetGUID_d SDL_JoystickGetGUID_f;

        public static Guid SDL_JoystickGetGUID(SDL_Joystick joystick) => SDL_JoystickGetGUID_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Guid SDL_JoystickGetGUIDFromString_d(string pchGUID);

        private static SDL_JoystickGetGUIDFromString_d SDL_JoystickGetGUIDFromString_f;

        public static Guid SDL_JoystickGetGUIDFromString(string pchGUID) => SDL_JoystickGetGUIDFromString_f(pchGUID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_JoystickGetGUIDString_d(Guid guid, byte* pszGUID, int cbGUID);

        private static SDL_JoystickGetGUIDString_d SDL_JoystickGetGUIDString_f;

        public static void SDL_JoystickGetGUIDString(Guid guid, byte* pszGUID, int cbGUID) => SDL_JoystickGetGUIDString_f(guid, pszGUID, cbGUID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Hat SDL_JoystickGetHat_d(SDL_Joystick joystick, int hat);

        private static SDL_JoystickGetHat_d SDL_JoystickGetHat_f;

        public static SDL_Hat SDL_JoystickGetHat(SDL_Joystick joystick, int hat) => SDL_JoystickGetHat_f(joystick, hat);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_JoystickID SDL_JoystickInstanceID_d(SDL_Joystick joystick);

        private static SDL_JoystickInstanceID_d SDL_JoystickInstanceID_f;

        public static SDL_JoystickID SDL_JoystickInstanceID(SDL_Joystick joystick) => SDL_JoystickInstanceID_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_JoystickName_d(SDL_Joystick joystick);

        private static SDL_JoystickName_d SDL_JoystickName_f;

        public static byte* SDL_JoystickName(SDL_Joystick joystick) => SDL_JoystickName_f(joystick);

        public static string SDL_JoystickNameString(SDL_Joystick joystick)
        {
            return GetString(SDL_JoystickName(joystick));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_JoystickNameForIndex_d(int deviceIndex);

        private static SDL_JoystickNameForIndex_d SDL_JoystickNameForIndex_f;

        public static byte* SDL_JoystickNameForIndex(int deviceIndex) => SDL_JoystickNameForIndex_f(deviceIndex);

        public static string SDL_JoystickNameForIndexString(int deviceIndex)
        {
            return GetString(SDL_JoystickNameForIndex(deviceIndex));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_JoystickNumAxes_d(SDL_Joystick joystick);

        private static SDL_JoystickNumAxes_d SDL_JoystickNumAxes_f;

        public static int SDL_JoystickNumAxes(SDL_Joystick joystick) => SDL_JoystickNumAxes_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_JoystickNumBalls_d(SDL_Joystick joystick);

        private static SDL_JoystickNumBalls_d SDL_JoystickNumBalls_f;

        public static int SDL_JoystickNumBalls(SDL_Joystick joystick) => SDL_JoystickNumBalls_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_JoystickNumButtons_d(SDL_Joystick joystick);

        private static SDL_JoystickNumButtons_d SDL_JoystickNumButtons_f;

        public static int SDL_JoystickNumButtons(SDL_Joystick joystick) => SDL_JoystickNumButtons_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_JoystickNumHats_d(SDL_Joystick joystick);

        private static SDL_JoystickNumHats_d SDL_JoystickNumHats_f;

        public static int SDL_JoystickNumHats(SDL_Joystick joystick) => SDL_JoystickNumHats_f(joystick);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Joystick SDL_JoystickOpen_d(int deviceIndex);

        private static SDL_JoystickOpen_d SDL_JoystickOpen_f;

        public static SDL_Joystick SDL_JoystickOpen(int deviceIndex) => SDL_JoystickOpen_f(deviceIndex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_JoystickUpdate_d();

        private static SDL_JoystickUpdate_d SDL_JoystickUpdate_f;

        public static void SDL_JoystickUpdate() => SDL_JoystickUpdate_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_NumJoysticks_d();

        private static SDL_NumJoysticks_d SDL_NumJoysticks_f;

        public static int SDL_NumJoysticks() => SDL_NumJoysticks_f();
    }
}

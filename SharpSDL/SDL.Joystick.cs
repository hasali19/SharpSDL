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

            public static implicit operator SDL_Joystick(IntPtr ptr)
            {
                return new SDL_Joystick(ptr);
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

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickClose(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Joystick SDL_JoystickFromInstanceID(SDL_JoystickID joyid);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_JoystickGetAttached(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_JoystickGetAxis(SDL_Joystick joystick, int axis);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetBall(SDL_Joystick joystick, int ball, int* dx, int* dy);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetButton(SDL_Joystick joystick, int button);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetDeviceGUID(int deviceIndex);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUID(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUIDFromString(string pchGUID);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickGetGUIDString(Guid guid, byte* pszGUID, int cbGUID);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Hat SDL_JoystickGetHat(SDL_Joystick joystick, int hat);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickID SDL_JoystickInstanceID(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_JoystickName(SDL_Joystick joystick);

        public static string SDL_JoystickNameString(SDL_Joystick joystick)
        {
            return GetString(SDL_JoystickName(joystick));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_JoystickNameForIndex(int deviceIndex);

        public static string SDL_JoystickNameForIndexString(int deviceIndex)
        {
            return GetString(SDL_JoystickNameForIndex(deviceIndex));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumAxes(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumBalls(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumButtons(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumHats(SDL_Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Joystick SDL_JoystickOpen(int deviceIndex);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickUpdate();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumJoysticks();
    }
}

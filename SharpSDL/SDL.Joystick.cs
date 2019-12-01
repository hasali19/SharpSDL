using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public enum JoystickType
        {
            Unknown,
            GameController,
            Wheel,
            ArcadeStick,
            FlightStick,
            DancePad,
            Guitar,
            DrumKit,
            ArcadePad,
            Throttle
        }

        public enum JoystickPowerLevel
        {
            Unknown = -1,
            Empty,
            Low,
            Medium,
            Full,
            Wired,
            Max
        }

        public enum Hat : byte
        {
            Centered = 0x00,
            Up = 0x01,
            Right = 0x02,
            Down = 0x04,
            Left = 0x08,

            RightUp = Right | Up,
            RightDown = Right | Down,
            LeftUp = Left | Up,
            LeftDown = Left | Down
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Joystick
        {
            private readonly IntPtr ptr;

            public Joystick(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(Joystick joystick)
            {
                return joystick.ptr;
            }

            public static implicit operator Joystick(IntPtr ptr)
            {
                return new Joystick(ptr);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct JoystickID
        {
            private readonly int id;

            public JoystickID(int id)
            {
                this.id = id;
            }

            public static implicit operator int(JoystickID joystickID)
            {
                return joystickID.id;
            }
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void JoystickClose(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern JoystickPowerLevel JoystickCurrentPowerLevel(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Joystick JoystickFromInstanceID(JoystickID joyid);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool JoystickGetAttached(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short JoystickGetAxis(Joystick joystick, int axis);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JoystickGetBall(Joystick joystick, int ball, int* dx, int* dy);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte JoystickGetButton(Joystick joystick, int button);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid JoystickGetDeviceGUID(int deviceIndex);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid JoystickGetGUID(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid JoystickGetGUIDFromString(string pchGUID);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void JoystickGetGUIDString(Guid guid, byte* pszGUID, int cbGUID);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Hat JoystickGetHat(Joystick joystick, int hat);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern JoystickID JoystickInstanceID(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* JoystickName(Joystick joystick);

        public static string JoystickNameString(Joystick joystick)
        {
            return GetString(JoystickName(joystick));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* JoystickNameForIndex(int deviceIndex);

        public static string JoystickNameForIndexString(int deviceIndex)
        {
            return GetString(JoystickNameForIndex(deviceIndex));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JoystickNumAxes(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JoystickNumBalls(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JoystickNumButtons(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JoystickNumHats(Joystick joystick);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Joystick JoystickOpen(int deviceIndex);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void JoystickUpdate();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NumJoysticks();
    }
}

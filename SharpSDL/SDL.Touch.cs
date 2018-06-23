using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
    {
        public const uint SDL_TOUCH_MOUSEID = unchecked((uint)-1);

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_TouchID
        {
            private long id;

            public SDL_TouchID(long id)
            {
                this.id = id;
            }

            public static implicit operator long(SDL_TouchID touchID)
            {
                return touchID.id;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_FingerID
        {
            private long id;

            public SDL_FingerID(long id)
            {
                this.id = id;
            }

            public static implicit operator long(SDL_FingerID fingerID)
            {
                return fingerID.id;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Finger
        {
            public SDL_FingerID id;
            public float x;
            public float y;
            public float pressure;
        }

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchDevices();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_TouchID SDL_GetTouchDevice(int index);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchFingers(SDL_TouchID touchID);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Finger SDL_GetTouchFinger(SDL_TouchID touchID, int index);
    }
}

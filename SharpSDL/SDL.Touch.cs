using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetNumTouchDevices_d();

        private static SDL_GetNumTouchDevices_d SDL_GetNumTouchDevices_f;

        public static int SDL_GetNumTouchDevices() => SDL_GetNumTouchDevices_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_TouchID SDL_GetTouchDevice_d(int index);

        private static SDL_GetTouchDevice_d SDL_GetTouchDevice_f;

        public static SDL_TouchID SDL_GetTouchDevice(int index) => SDL_GetTouchDevice_f(index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GetNumTouchFingers_d(SDL_TouchID touchID);

        private static SDL_GetNumTouchFingers_d SDL_GetNumTouchFingers_f;

        public static int SDL_GetNumTouchFingers(SDL_TouchID touchID) => SDL_GetNumTouchFingers_f(touchID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Finger SDL_GetTouchFinger_d(SDL_TouchID touchID, int index);

        private static SDL_GetTouchFinger_d SDL_GetTouchFinger_f;

        public static SDL_Finger SDL_GetTouchFinger(SDL_TouchID touchID, int index) => SDL_GetTouchFinger_f(touchID, index);
    }
}

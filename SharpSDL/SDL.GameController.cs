using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static unsafe partial class SDL
    {
        public enum SDL_GameControllerBindType
        {
            SDL_CONTROLLER_BINDTYPE_NONE = 0,
            SDL_CONTROLLER_BINDTYPE_BUTTON,
            SDL_CONTROLLER_BINDTYPE_AXIS,
            SDL_CONTROLLER_BINDTYPE_HAT
        }

        public enum SDL_GameControllerAxis
        {
            SDL_CONTROLLER_AXIS_INVALID = -1,
            SDL_CONTROLLER_AXIS_LEFTX,
            SDL_CONTROLLER_AXIS_LEFTY,
            SDL_CONTROLLER_AXIS_RIGHTX,
            SDL_CONTROLLER_AXIS_RIGHTY,
            SDL_CONTROLLER_AXIS_TRIGGERLEFT,
            SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
            SDL_CONTROLLER_AXIS_MAX
        }

        public enum SDL_GameControllerButton
        {
            SDL_CONTROLLER_BUTTON_INVALID = -1,
            SDL_CONTROLLER_BUTTON_A,
            SDL_CONTROLLER_BUTTON_B,
            SDL_CONTROLLER_BUTTON_X,
            SDL_CONTROLLER_BUTTON_Y,
            SDL_CONTROLLER_BUTTON_BACK,
            SDL_CONTROLLER_BUTTON_GUIDE,
            SDL_CONTROLLER_BUTTON_START,
            SDL_CONTROLLER_BUTTON_LEFTSTICK,
            SDL_CONTROLLER_BUTTON_RIGHTSTICK,
            SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
            SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
            SDL_CONTROLLER_BUTTON_DPAD_UP,
            SDL_CONTROLLER_BUTTON_DPAD_DOWN,
            SDL_CONTROLLER_BUTTON_DPAD_LEFT,
            SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
            SDL_CONTROLLER_BUTTON_MAX
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_GameControllerButtonBind
        {
            public SDL_GameControllerBindType bindType;
            public SDL_GameControllerButtonBindUnion value;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct SDL_GameControllerButtonBindUnion
        {
            [FieldOffset(0)]
            public int button;
            [FieldOffset(0)]
            public int axis;
            [FieldOffset(0)]
            public Hat hat;

            [StructLayout(LayoutKind.Sequential)]
            public struct Hat
            {
                public int hat;
                public int hatMask;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_GameController
        {
            private IntPtr ptr;

            public SDL_GameController(IntPtr ptr)
            {
                this.ptr = ptr;
            }

            public static implicit operator IntPtr(SDL_GameController gameController)
            {
                return gameController.ptr;
            }

            public static implicit operator SDL_GameController(IntPtr ptr)
            {
                return new SDL_GameController(ptr);
            }
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerAddMapping(string mappingString);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerClose(SDL_GameController gamecontroller);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameController SDL_GameControllerFromInstanceID(SDL_JoystickID joyid);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_GameControllerGetAttached(SDL_GameController gamecontroller);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_GameControllerGetAxis(SDL_GameController gameController, SDL_GameControllerAxis axis);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(string pchString);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(SDL_GameController gameController, SDL_GameControllerAxis axis);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(SDL_GameController gameController, SDL_GameControllerButton buttons);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_GameControllerGetButton(SDL_GameController gameController, SDL_GameControllerButton button);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameControllerButton SDL_GameControllerGetButtonFromString(string pchString);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Joystick SDL_GameControllerGetJoystick(SDL_GameController gameController);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis);

        public static string SDL_GameControllerGetStringForAxisString(SDL_GameControllerAxis axis)
        {
            return GetString(SDL_GameControllerGetStringForAxis(axis));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GameControllerGetStringForButton(SDL_GameControllerButton button);

        public static string SDL_GameControllerGetStringForButtonString(SDL_GameControllerButton button)
        {
            return GetString(SDL_GameControllerGetStringForButton(button));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GameControllerMapping(SDL_GameController gameController);

        public static string SDL_GameControllerMappingString(SDL_GameController gameController)
        {
            return GetString(SDL_GameControllerMapping(gameController));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GameControllerMappingForGUID(Guid guid);

        public static string SDL_GameControllerMappingForGUIDString(Guid guid)
        {
            return GetString(SDL_GameControllerMappingForGUID(guid));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GameControllerName(SDL_GameController gameController);

        public static string SDL_GameControllerNameString(SDL_GameController gameController)
        {
            return GetString(SDL_GameControllerName(gameController));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* SDL_GameControllerNameForIndex(int joystickIndex);

        public static string SDL_GameControllerNameForIndexString(int joystickIndex)
        {
            return GetString(SDL_GameControllerNameForIndex(joystickIndex));
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_GameController SDL_GameControllerOpen(int joystickIndex);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerUpdate();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_IsGameController(int joystickIndex);
    }
}

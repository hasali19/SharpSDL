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
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GameControllerAddMapping_d(string mappingString);

        private static SDL_GameControllerAddMapping_d SDL_GameControllerAddMapping_f;

        public static int SDL_GameControllerAddMapping(string mappingString) => SDL_GameControllerAddMapping_f(mappingString);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SDL_GameControllerClose_d(SDL_GameController gamecontroller);

        private static SDL_GameControllerClose_d SDL_GameControllerClose_f;

        public static int SDL_GameControllerClose(SDL_GameController gamecontroller) => SDL_GameControllerClose_f(gamecontroller);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_GameController SDL_GameControllerFromInstanceID_d(SDL_JoystickID joyid);

        private static SDL_GameControllerFromInstanceID_d SDL_GameControllerFromInstanceID_f;

        public static SDL_GameController SDL_GameControllerFromInstanceID(SDL_JoystickID joyid) => SDL_GameControllerFromInstanceID_f(joyid);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_GameControllerGetAttached_d(SDL_GameController gamecontroller);

        private static SDL_GameControllerGetAttached_d SDL_GameControllerGetAttached_f;

        public static bool SDL_GameControllerGetAttached(SDL_GameController gamecontroller) => SDL_GameControllerGetAttached_f(gamecontroller);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate short SDL_GameControllerGetAxis_d(SDL_GameController gameController, SDL_GameControllerAxis axis);

        private static SDL_GameControllerGetAxis_d SDL_GameControllerGetAxis_f;

        public static short SDL_GameControllerGetAxis(SDL_GameController gameController, SDL_GameControllerAxis axis) => SDL_GameControllerGetAxis_f(gameController, axis);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_GameControllerAxis SDL_GameControllerGetAxisFromString_d(string pchString);

        private static SDL_GameControllerGetAxisFromString_d SDL_GameControllerGetAxisFromString_f;

        public static SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(string pchString) => SDL_GameControllerGetAxisFromString_f(pchString);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis_d(SDL_GameController gameController, SDL_GameControllerAxis axis);

        private static SDL_GameControllerGetBindForAxis_d SDL_GameControllerGetBindForAxis_f;

        public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(SDL_GameController gameController, SDL_GameControllerAxis axis) => SDL_GameControllerGetBindForAxis_f(gameController, axis);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton_d(SDL_GameController gameController, SDL_GameControllerButton buttons);

        private static SDL_GameControllerGetBindForButton_d SDL_GameControllerGetBindForButton_f;

        public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(SDL_GameController gameController, SDL_GameControllerButton buttons) => SDL_GameControllerGetBindForButton_f(gameController, buttons);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte SDL_GameControllerGetButton_d(SDL_GameController gameController, SDL_GameControllerButton button);

        private static SDL_GameControllerGetButton_d SDL_GameControllerGetButton_f;

        public static byte SDL_GameControllerGetButton(SDL_GameController gameController, SDL_GameControllerButton button) => SDL_GameControllerGetButton_f(gameController, button);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_GameControllerButton SDL_GameControllerGetButtonFromString_d(string pchString);

        private static SDL_GameControllerGetButtonFromString_d SDL_GameControllerGetButtonFromString_f;

        public static SDL_GameControllerButton SDL_GameControllerGetButtonFromString(string pchString) => SDL_GameControllerGetButtonFromString_f(pchString);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_Joystick SDL_GameControllerGetJoystick_d(SDL_GameController gameController);

        private static SDL_GameControllerGetJoystick_d SDL_GameControllerGetJoystick_f;

        public static SDL_Joystick SDL_GameControllerGetJoystick(SDL_GameController gameController) => SDL_GameControllerGetJoystick_f(gameController);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GameControllerGetStringForAxis_d(SDL_GameControllerAxis axis);

        private static SDL_GameControllerGetStringForAxis_d SDL_GameControllerGetStringForAxis_f;

        public static byte* SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis) => SDL_GameControllerGetStringForAxis_f(axis);

        public static string SDL_GameControllerGetStringForAxisString(SDL_GameControllerAxis axis)
        {
            return GetString(SDL_GameControllerGetStringForAxis(axis));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GameControllerGetStringForButton_d(SDL_GameControllerButton button);

        private static SDL_GameControllerGetStringForButton_d SDL_GameControllerGetStringForButton_f;

        public static byte* SDL_GameControllerGetStringForButton(SDL_GameControllerButton button) => SDL_GameControllerGetStringForButton_f(button);

        public static string SDL_GameControllerGetStringForButtonString(SDL_GameControllerButton button)
        {
            return GetString(SDL_GameControllerGetStringForButton(button));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GameControllerMapping_d(SDL_GameController gameController);

        private static SDL_GameControllerMapping_d SDL_GameControllerMapping_f;

        public static byte* SDL_GameControllerMapping(SDL_GameController gameController) => SDL_GameControllerMapping_f(gameController);

        public static string SDL_GameControllerMappingString(SDL_GameController gameController)
        {
            return GetString(SDL_GameControllerMapping(gameController));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GameControllerMappingForGUID_d(Guid guid);

        private static SDL_GameControllerMappingForGUID_d SDL_GameControllerMappingForGUID_f;

        public static byte* SDL_GameControllerMappingForGUID(Guid guid) => SDL_GameControllerMappingForGUID_f(guid);

        public static string SDL_GameControllerMappingForGUIDString(Guid guid)
        {
            return GetString(SDL_GameControllerMappingForGUID(guid));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GameControllerName_d(SDL_GameController gameController);

        private static SDL_GameControllerName_d SDL_GameControllerName_f;

        public static byte* SDL_GameControllerName(SDL_GameController gameController) => SDL_GameControllerName_f(gameController);

        public static string SDL_GameControllerNameString(SDL_GameController gameController)
        {
            return GetString(SDL_GameControllerName(gameController));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* SDL_GameControllerNameForIndex_d(int joystickIndex);

        private static SDL_GameControllerNameForIndex_d SDL_GameControllerNameForIndex_f;

        public static byte* SDL_GameControllerNameForIndex(int joystickIndex) => SDL_GameControllerNameForIndex_f(joystickIndex);

        public static string SDL_GameControllerNameForIndexString(int joystickIndex)
        {
            return GetString(SDL_GameControllerNameForIndex(joystickIndex));
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SDL_GameController SDL_GameControllerOpen_d(int joystickIndex);

        private static SDL_GameControllerOpen_d SDL_GameControllerOpen_f;

        public static SDL_GameController SDL_GameControllerOpen(int joystickIndex) => SDL_GameControllerOpen_f(joystickIndex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SDL_GameControllerUpdate_d();

        private static SDL_GameControllerUpdate_d SDL_GameControllerUpdate_f;

        public static void SDL_GameControllerUpdate() => SDL_GameControllerUpdate_f();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool SDL_IsGameController_d(int joystickIndex);

        private static SDL_IsGameController_d SDL_IsGameController_f;

        public static bool SDL_IsGameController(int joystickIndex) => SDL_IsGameController_f(joystickIndex);
    }
}

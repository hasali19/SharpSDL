using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using NativeLibraryLoader;

namespace SharpSDL
{
    public static partial class SDL
    {
        private static NativeLibrary _library;

        public static void LoadLibrary(string name = "SDL2")
        {
            _library?.Dispose();
            _library = new NativeLibrary(name);

            Type type = typeof(SDL);

            IEnumerable<FieldInfo> fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(field => field.Name.EndsWith("_f"));

            foreach (FieldInfo field in fields)
            {
                string functionName = field.Name.Substring(0, field.Name.Length - 2);
                IntPtr functionPointer = _library.LoadFunction(functionName);
                if (functionPointer != IntPtr.Zero)
                {
                    Delegate functionDelegate = Marshal.GetDelegateForFunctionPointer(functionPointer, field.FieldType);
                    field.SetValue(null, functionDelegate);
                }
            }
        }
    }
}

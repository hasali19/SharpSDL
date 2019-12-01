using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public static partial class SDL
    {
        private const string LibraryName = "SDL2";

#if NETCOREAPP3_0
        private static IntPtr _handle;

        static SDL()
        {
            NativeLibrary.SetDllImportResolver(typeof(SDL).Assembly, ResolveDllImport);
        }

        private static IntPtr ResolveDllImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (_handle == IntPtr.Zero)
            {
                var libPath = libraryName;
                var baseDir = Path.GetDirectoryName(assembly.Location);
                var nativeLibDir = Path.Combine(baseDir, "runtimes");

                if (Directory.Exists(nativeLibDir))
                {
                    libPath = Path.Combine(nativeLibDir, GetRuntimeIdentifier(), "native", GetNativeLibraryName());
                }
#if DEBUG
                Console.WriteLine($"Loading SDL2 from: {libPath}");
#endif
                _handle = NativeLibrary.Load(libPath);
            }

            return _handle;
        }

        private static string GetRuntimeIdentifier()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
                {
                    return "win-x64";
                }

                if (RuntimeInformation.ProcessArchitecture == Architecture.X86)
                {
                    return "win-x86";
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "linux-x64";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return "osx-x64";
            }

            throw new PlatformNotSupportedException();
        }

        private static string GetNativeLibraryName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "SDL2.dll";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "libSDL2.so";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return "libSDL2.dylib";
            }

            throw new PlatformNotSupportedException();
        }
#endif
    }
}

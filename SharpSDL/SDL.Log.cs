using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public enum LogPriority : int
    {
        LOG_PRIORITY_VERBOSE = 1,
        LOG_PRIORITY_DEBUG,
        LOG_PRIORITY_INFO,
        LOG_PRIORITY_WARN,
        LOG_PRIORITY_ERROR,
        LOG_PRIORITY_CRITICAL,
        NUM_LOG_PRIORITIES
    }

    public static unsafe partial class SDL
    {
        [DllImport(LibraryName, EntryPoint = "SDL_LogSetAllPriority", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError=true)]
        public static extern void LogSetAllPriority(LogPriority priority);

        [DllImport(LibraryName, EntryPoint = "SDL_Log", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        public static extern void Log(string fmt);
    }
}

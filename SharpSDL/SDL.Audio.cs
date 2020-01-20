using System;
using System.Runtime.InteropServices;

namespace SharpSDL
{
    public enum Boolean : int { 
        True = 1,
        False = 0
    }

    /**
    *  \brief Audio format flags.
    *
    *  These are what the 16 bits in SDL_AudioFormat currently mean...
    *  (Unspecified bits are always zero).
    *
    *  \verbatim
    ++-----------------------sample is signed if set
    ||
    ||       ++-----------sample is bigendian if set
    ||       ||
    ||       ||          ++---sample is float if set
    ||       ||          ||
    ||       ||          || +---sample bit size---+
    ||       ||          || |                     |
    15 14 13 12 11 10 09 08 07 06 05 04 03 02 01 00
    \endverbatim
    *
    *  There are macros in SDL 2.0 and later to query these bits.
    */

    /**
    *  \name Audio flags
    */
    /* @{ */
    public enum AudioFlags : uint
    {
        SDL_AUDIO_MASK_BITSIZE = 0xFF,
        SDL_AUDIO_MASK_DATATYPE = (1 << 8),
        SDL_AUDIO_MASK_ENDIAN = (1 << 12),
        SDL_AUDIO_MASK_SIGNED = (1 << 15)
    }

    /**
    *  \name Audio format flags
    *
    *  Defaults to LSB byte order.
    */
    /* @{ */
    public enum AudioFormatFlags : uint
    {
        AUDIO_U8 = 0x0008,  /**< Unsigned 8-bit samples */
        AUDIO_S8 = 0x8008,  /**< Signed 8-bit samples */
        AUDIO_U16LSB = 0x0010,  /**< Unsigned 16-bit samples */
        AUDIO_S16LSB = 0x8010,  /**< Signed 16-bit samples */
        AUDIO_U16MSB = 0x1010,  /**< As above, but big-endian byte order */
        AUDIO_S16MSB = 0x9010,  /**< As above, but big-endian byte order */
        AUDIO_U16 = AUDIO_U16LSB,
        AUDIO_S16 = AUDIO_S16LSB,
        AUDIO_S32LSB = 0x8020,  /**< 32-bit integer samples */
        AUDIO_S32MSB = 0x9020,  /**< As above, but big-endian byte order */
        AUDIO_S32 = AUDIO_S32LSB,
        AUDIO_F32LSB = 0x8120,  /**< 32-bit floating point samples */
        AUDIO_F32MSB = 0x9120,  /**< As above, but big-endian byte order */
        AUDIO_F32 = AUDIO_F32LSB,
        AUDIO_U16SYS = AUDIO_U16LSB,
        AUDIO_S16SYS = AUDIO_S16LSB,
        AUDIO_S32SYS = AUDIO_S32LSB,
        AUDIO_F32SYS = AUDIO_F32LSB
    }
    /* @} */

    /**
    *  \name Allow change flags
    *
    *  Which audio format changes are allowed when opening a device.
    */
    /* @{ */
    public enum AudioChangeFlags : uint
    {
        SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001,
        SDL_AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002,
        SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004,
        SDL_AUDIO_ALLOW_SAMPLES_CHANGE = 0x00000008,
        SDL_AUDIO_ALLOW_ANY_CHANGE = (SDL_AUDIO_ALLOW_FREQUENCY_CHANGE | SDL_AUDIO_ALLOW_FORMAT_CHANGE | SDL_AUDIO_ALLOW_CHANNELS_CHANGE | SDL_AUDIO_ALLOW_SAMPLES_CHANGE)
    }
    /* @} */

    /* @} *//* Audio flags */

    /**
    *  This function is called when the audio device needs more data.
    *
    *  \param userdata An application-specific parameter saved in
    *                  the SDL_AudioSpec structure
    *  \param stream A pointer to the audio data buffer.
    *  \param len    The length of that buffer in bytes.
    *
    *  Once the callback returns, the buffer will no longer be valid.
    *  Stereo samples are stored in a LRLRLR ordering.
    *
    *  You can choose to avoid callbacks and use SDL_QueueAudio() instead, if
    *  you like. Just open your audio device with a NULL callback.
    */
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AudioCallback(void* userdata, byte* stream, uint len);


    /**
    *  The calculated values in this structure are calculated by SDL_OpenAudio().
    *
    *  For multi-channel audio, the default SDL channel mapping is:
    *  2:  FL FR                       (stereo)
    *  3:  FL FR LFE                   (2.1 surround)
    *  4:  FL FR BL BR                 (quad)
    *  5:  FL FR FC BL BR              (quad + center)
    *  6:  FL FR FC LFE SL SR          (5.1 surround - last two can also be BL BR)
    *  7:  FL FR FC LFE BC SL SR       (6.1 surround)
    *  8:  FL FR FC LFE BL BR SL SR    (7.1 surround)
    */

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AudioSpec
    {
        public int freq;            /* DSP frequency -- samples per second */
        public short format;        /* Audio data format */
        public byte channels;       /* Number of channels: 1 mono; 2 stereo */
        public byte silence;        /* Audio buffer silence value (calculated) */
        public short samples;       /* Audio buffer size in sample FRAMES (total samples divided by channel count) */
        public short padding;       /* Necessary for some compile environments */
        public ulong size;          /* Audio buffer size in bytes (calculated) */
        public IntPtr callback;     /* Callback that feeds the audio device (NULL to use SDL_QueueAudio()). */
        public void* userdata;      /* Userdata passed to callback (ignored for NULL callbacks). */

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Wave
    {
        public uint Format;
        public int Width;
        public int Height;
        public int RefreshRate;
        public IntPtr DriverData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RWops
    {
        private readonly IntPtr ptr;

        public RWops(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public static implicit operator IntPtr(RWops ops)
        {
            return ops.ptr;
        }

        public static implicit operator RWops(IntPtr ptr)
        {
            return new RWops(ptr);
        }
    }


    public static unsafe partial class SDL
    {
        [DllImport(LibraryName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern RWops RWFromFile(string file, string mode);

        [DllImport(LibraryName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern AudioSpec* LoadWavRW( RWops src, 
            int freesrc,
            AudioSpec* audioSpec,
            byte** buf, 
            uint* len
            );

        public static AudioSpec* LoadWavFromFile(String file, AudioSpec* spec, byte** buf, uint* len) {
            var src = RWFromFile(file, "rb");
            var audSpec = LoadWavRW(src, 1, spec, buf, len);
            return audSpec;
        }

        [DllImport(LibraryName, EntryPoint = "SDL_GetNumAudioDrivers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumAudioDrivers();


        [DllImport(LibraryName, EntryPoint = "SDL_AudioDriver", CallingConvention = CallingConvention.Cdecl)]
        public static extern string GetAudioDrivers(int index);

        [DllImport(LibraryName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint OpenAudioDevice(
            string device, 
            int iscapture, 
            AudioSpec* desired, 
            AudioSpec* obtained, 
            int allowChanges 
            );

        [DllImport(LibraryName, EntryPoint = "SDL_CloseAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint CloseAudioDevice(
            uint deviceId
            );

        [DllImport(LibraryName, EntryPoint = "SDL_PauseAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern int PauseAudioDevice(
            uint deviceId,
            Boolean pauseOn
            );

        [DllImport(LibraryName, EntryPoint = "SDL_QueueAudio")]        
        public static extern int QueueAudio(uint device, byte* buf, uint length);

        [DllImport(LibraryName, EntryPoint = "SDL_Delay")]
        public static extern void Delay(uint ms);
    }
}

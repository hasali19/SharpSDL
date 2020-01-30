// Learn more about F# at http://fsharp.org
open System
open SharpSDL
open System.Runtime.InteropServices
#nowarn "9"

[<EntryPoint>]
let main argv =
    SDL.LogSetAllPriority(LogPriority.LOG_PRIORITY_DEBUG) 
    let initOk = SDL.Init(InitFlags.Audio ||| InitFlags.Events)
    let mutable spec = new AudioSpec()
    // soundBuffer is alloc'd by C code,
    let mutable sb = 0 |> byte
    let mutable sound = &&sb
    let mutable soundLen = 0 |> int32
    let audioSpec = 
        SDL.LoadWavFromFile(
            "./assets/beep beep beep.wav",
            &&spec ,  
            &&sound ,
            &&soundLen )
    
    let mutable device = 0u

    let noDevices = SDL.GetNumAudioDrivers()
    let readString p = 
      Marshal.PtrToStringAnsi(SDL.GetAudioDriver(p))
    
    let formatDevices x = 
      sprintf "Audio device (%i): %s" x (readString x)

    let logDevices = 
      formatDevices >> SDL.Log

    [0..(noDevices - 1)]
    |> List.iter logDevices
    
    let openaudio () = 
      device <-
          SDL.OpenAudioDevice(
              null, 
              0, 
              audioSpec , 
              new IntPtr(0), 
              0
          )
      SDL.Log (sprintf "Using device (%i): %s" device (readString (device |> int )))
      SDL.PauseAudioDevice(device, false) |> ignore

    let closeaudio () = 
      SDL.CloseAudioDevice(device) |> ignore

    let reopenAudio () = 
      closeaudio()
      openaudio ()

    openaudio()

    let rec looper keepgoing = 
      async {
        match keepgoing with 
        | true ->
              let mutable event = new Event()
      
              while SDL.PollEvent(&&event) > 0 do
                SDL.Log(event.Type.ToString())
                match event.Type with 
                | EventType.Quit -> return! looper false
                | EventType.AudioDeviceAdded when event.ADevice.IsCapture = 0uy -> reopenAudio ()
                | EventType.AudioDeviceRemoved when event.ADevice.IsCapture = 0uy && event.ADevice.Which = device -> reopenAudio ()
                | _ -> ()

              let remainingAudio = SDL.GetQueuedAudioSize(device)
              match remainingAudio > 10000u with // this is a bit of a hack
              | true -> ()
              | _ -> 
                SDL.Log("Buffer Consumed, loading more audio")
                SDL.QueueAudio(device, sound, soundLen |> int) |> ignore
              
              do! Async.Sleep 10
              return! looper true
        | _ -> return ()
        }
    
    looper true |> Async.Start

    let rec forever () = 
      async {
          do! Async.Sleep 10
          return! forever ()
      } 
    forever () |> Async.RunSynchronously
    // block the app as console.readkey doesn't work for WinExe type app
    0 // return an integer exit code

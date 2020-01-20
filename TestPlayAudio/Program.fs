// Learn more about F# at http://fsharp.org
open System
open SharpSDL

[<EntryPoint>]
let main argv =
    
    let initOk = SDL.Init(InitFlags.Audio ||| InitFlags.Events)
    let mutable spec = new AudioSpec()
    // soundBuffer is alloc'd by C code,
    let mutable sb = 0 |> byte
    let mutable soundBuffer = &&sb
    let mutable soundLen = 0 |> uint32
    // spec.callback <- fun a
    let audioSpec = 
        SDL.LoadWavFromFile(
            "./assets/beep beep beep.wav",
            &&spec ,  
            &&soundBuffer ,
            &&soundLen )
    
    let device = SDL.OpenAudioDevice(null, 0, &&spec , &&spec, 0)
    

    let queue = SDL.QueueAudio(device, soundBuffer, soundLen)
    let unpauseSuccess = SDL.PauseAudioDevice(device, Boolean.False)

    Console.ReadLine() |> ignore 
    0 // return an integer exit code

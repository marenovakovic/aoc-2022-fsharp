module aoc_2022_fsharp.day6.Day6

open FSharpPlus

let private packetMarkerSize = 4
let private messageMarkerSize = 14

let private findMarkerPosition markerSize parts =
    let indexOfWindowWithDistinctCharacters =
        parts |> Seq.findIndex (fun x -> Array.length x = markerSize)

    indexOfWindowWithDistinctCharacters + markerSize

let findPacketMarkerPosition s =
    Seq.windowed packetMarkerSize s
    |> Seq.map Array.distinct
    |> findMarkerPosition packetMarkerSize

let findMessageMarkerPosition s =
    Seq.windowed messageMarkerSize s
    |> Seq.map Array.distinct
    |> findMarkerPosition messageMarkerSize

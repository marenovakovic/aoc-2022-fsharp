module aoc_2022_fsharp.day6.Day6

open FSharpPlus

let private packetMarkerSize = 4

let private findMarkerPosition' markerSize parts =
    let indexOfWindowWithDistinctCharacters =
        parts |> Seq.findIndex (fun x -> Array.length x = markerSize)

    indexOfWindowWithDistinctCharacters + markerSize

let findMarkerPosition s =
    Seq.windowed packetMarkerSize s
    |> Seq.map Array.distinct
    |> findMarkerPosition' packetMarkerSize

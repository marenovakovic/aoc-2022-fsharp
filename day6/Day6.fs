module aoc_2022_fsharp.day6.Day6

open FSharpPlus

let private windowSize = 4

let private findMarkerPosition' parts =
    let indexOfWindowWithDistinctCharacters =
        parts |> Seq.findIndex (fun x -> Array.length x = windowSize)

    indexOfWindowWithDistinctCharacters + windowSize

let findMarkerPosition s =
    Seq.windowed windowSize s |> Seq.map Array.distinct |> findMarkerPosition'

module aoc_2022_fsharp.day6.Day6

open FSharpPlus

let private packetMarkerSize = 4
let private messageMarkerSize = 14

let splitSignal markerSize signal = Seq.windowed markerSize signal

let private findIndexOfPartWithAllDistinctCharacters markerSize parts =
    Seq.findIndex (fun x -> Array.length x = markerSize) parts

let private findMarkerStart markerSize signal =
    (markerSize, signal)
    ||> splitSignal
    |> Seq.map Array.distinct
    |> findIndexOfPartWithAllDistinctCharacters markerSize
    |> (fun x -> x + markerSize)

let findPacketStart signal = findMarkerStart packetMarkerSize signal

let findMessageStart signal = findMarkerStart messageMarkerSize signal

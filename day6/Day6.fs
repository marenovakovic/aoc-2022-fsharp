module aoc_2022_fsharp.day6.Day6

open FSharpPlus

let private packetMarkerSize = 4
let private messageMarkerSize = 14

let splitSignal markerSize signal = Seq.windowed markerSize signal

let isDistinct array = array |> Array.distinct = array

let private findMarkerStart markerSize =
    Seq.windowed markerSize >> Seq.findIndex isDistinct >> ((+) markerSize)

let findPacketStart signal = findMarkerStart packetMarkerSize signal

let findMessageStart signal = findMarkerStart messageMarkerSize signal

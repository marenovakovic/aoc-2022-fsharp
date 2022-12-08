module aoc_2022_fsharp.day2.Day2

open aoc_2022_fsharp.ReadFile
open aoc_2022_fsharp.Split

exception IllegalState

type Play =
    | Rock
    | Paper
    | Scissors

let private translation =
    Map [ "A", Rock; "B", Paper; "C", Scissors; "X", Rock; "Y", Paper; "Z", Scissors ]

let private parseTurns strategy =
    strategy |> split "\n" |> List.map (split " ")

let readStrategy fileName = fileName |> readFile

let private mapTurns turns =
    turns
    |> List.map (fun turn ->
        match turn with
        | opponent :: player :: _ -> translation[opponent], translation[player]
        | _ -> raise IllegalState)

let parseStrategy strategy = strategy |> parseTurns |> mapTurns

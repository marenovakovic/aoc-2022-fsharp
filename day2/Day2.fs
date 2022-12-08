module aoc_2022_fsharp.day2.Day2

open System
open aoc_2022_fsharp.ReadFile
open aoc_2022_fsharp.Split

exception IllegalState

type Play =
    | Rock
    | Paper
    | Scissors

let private translation =
    Map [ "A", Rock; "B", Paper; "C", Scissors; "X", Rock; "Y", Paper; "Z", Scissors ]

let private wins = [ (Rock, Paper); (Paper, Scissors); (Scissors, Rock) ]

let private loses = [ (Paper, Rock); (Scissors, Paper); (Rock, Scissors) ]

let private score = Map [ Rock, 1; Paper, 2; Scissors, 3 ]

let private parseTurns strategy =
    strategy |> split "\n" |> List.map (split " ")

let private mapTurns turns =
    turns
    |> List.map (fun turn ->
        match turn with
        | opponent :: player :: _ -> translation[opponent], translation[player]
        | _ -> raise IllegalState)

let private scoreTurn turn =
    let _, player = turn

    if wins |> List.contains turn then 6 + score[player]
    elif loses |> List.contains turn then score[player]
    else 3 + score[player]

let parseStrategy strategy = strategy |> parseTurns |> mapTurns

let scoreStrategy (strategy: (Play * Play) list) =
    List.fold (fun acc turn -> acc + scoreTurn turn) 0 strategy

// let scoreStrategy (strategy: (Play * Play) list) =
//     let rec loop score turns =
//         match turns with
//         | turn :: rest -> loop (score + scoreTurn turn) rest
//         | _ -> score
//
//     loop 0 strategy

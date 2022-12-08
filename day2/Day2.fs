module aoc_2022_fsharp.day2.Day2

open System
open aoc_2022_fsharp.ReadFile
open aoc_2022_fsharp.Split

exception IllegalState

type Play =
    | Rock
    | Paper
    | Scissors

let private assumedTranslation =
    Map [ "A", Rock; "B", Paper; "C", Scissors; "X", Rock; "Y", Paper; "Z", Scissors ]

let private wins = [ (Rock, Paper); (Paper, Scissors); (Scissors, Rock) ]

let private loses = [ (Paper, Rock); (Scissors, Paper); (Rock, Scissors) ]

let private score = Map [ Rock, 1; Paper, 2; Scissors, 3 ]

let private parseRounds strategy =
    strategy |> split "\n" |> List.map (split " ")

let private mapRounds rounds =
    rounds
    |> List.map (fun round ->
        match round with
        | opponent :: player :: _ -> assumedTranslation[opponent], assumedTranslation[player]
        | _ -> raise IllegalState)

let private scoreRound round =
    let _, player = round

    if wins |> List.contains round then 6 + score[player]
    elif loses |> List.contains round then score[player]
    else 3 + score[player]

let readStrategy fileName = fileName |> readFile |> parseRounds |> mapRounds

let scoreStrategy (strategy: (Play * Play) list) =
    List.fold (fun acc round -> acc + scoreRound round) 0 strategy

module aoc_2022_fsharp.day2.Day2

open aoc_2022_fsharp.ReadFile
open aoc_2022_fsharp.Split

exception IllegalState

type Play =
    | Rock
    | Paper
    | Scissors
    | Win
    | Lose
    | Draw

let private assumedTranslation =
    Map [ "A", Rock; "B", Paper; "C", Scissors; "X", Rock; "Y", Paper; "Z", Scissors ]

let private actualTranslation =
    Map [ "A", Rock; "B", Paper; "C", Scissors; "X", Lose; "Y", Draw; "Z", Win ]

let private wins = [ (Rock, Paper); (Paper, Scissors); (Scissors, Rock) ]

let private loses = [ (Paper, Rock); (Scissors, Paper); (Rock, Scissors) ]

let private score = Map [ Rock, 1; Paper, 2; Scissors, 3 ]

let private parseStrategy strategy =
    strategy |> split "\n" |> List.map (split " ")

let private mapRounds (translation: Map<string, Play>) rounds =
    rounds
    |> List.map (fun round ->
        match round with
        | opponent :: player :: _ -> translation[opponent], translation[player]
        | _ -> raise IllegalState)

let private scoreRound round =
    let _, player = round

    if List.contains round wins then 6 + score[player]
    elif List.contains round loses then score[player]
    else 3 + score[player]

let readStrategy fileName =
    fileName |> readFile |> parseStrategy |> mapRounds assumedTranslation

let scoreStrategy (strategy: (Play * Play) list) =
    List.fold (fun acc round -> acc + scoreRound round) 0 strategy

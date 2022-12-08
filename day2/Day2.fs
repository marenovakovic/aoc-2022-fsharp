module aoc_2022_fsharp.day2.Day2

open aoc_2022_fsharp.ReadFile
open aoc_2022_fsharp.Split

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

let private winResponses = Map [ Rock, Paper; Paper, Scissors; Scissors, Rock ]

let private loseResponses = Map [ Rock, Scissors; Paper, Rock; Scissors, Paper ]

let private score = Map [ Rock, 1; Paper, 2; Scissors, 3 ]

let private parseStrategy strategy =
    strategy |> split "\n" |> List.map (split " ")

let private mapRounds (translation: Map<string, Play>) rounds =
    rounds
    |> List.map (fun round ->
        match round with
        | opponent :: player :: _ -> translation[opponent], translation[player]
        | _ -> failwith $"invalid round: {round}")

let private scoreRound round =
    let _, player = round

    if List.contains round wins then 6 + score[player]
    elif List.contains round loses then score[player]
    else 3 + score[player]

let scoreStrategy (strategy: (Play * Play) list) =
    List.fold (fun acc round -> acc + scoreRound round) 0 strategy

let readAssumedStrategy fileName =
    fileName |> readFile |> parseStrategy |> mapRounds assumedTranslation

let playAssumedStrategy fileName =
    fileName |> readAssumedStrategy |> scoreStrategy

let readActualStrategy fileName =
    fileName |> readFile |> parseStrategy |> mapRounds actualTranslation

let playActualStrategy fileName =
    fileName |> readActualStrategy |> scoreStrategy

let chooseResponse round =
    let opponent, outcome = round

    match outcome with
    | Win -> winResponses[opponent]
    | Lose -> loseResponses[opponent]
    | Draw -> opponent
    | _ -> failwith $"not an outcome: {outcome}"

module aoc_2022_fsharp.day2.Day2

open aoc_2022_fsharp.ReadFile
open aoc_2022_fsharp.Split

type Play =
    | Rock
    | Paper
    | Scissors

let private parsePlay play =
    match play with
    | "A" -> Rock
    | "B" -> Paper
    | "C" -> Scissors
    | "X" -> Rock
    | "Y" -> Paper
    | "Z" -> Scissors
    | _ -> failwith $"invalid play: {play}"

type Result =
    | Win
    | Loss
    | Draw

let parseResult result =
    match result with
    | "X" -> Loss
    | "Y" -> Draw
    | "Z" -> Win
    | _ -> failwith $"invalid result: {result}"

let private parseRound (round: string list) =
    (parsePlay round[0], parsePlay round[1])

let private calculateResult (opponent, player) =
    match (player, opponent) with
    | Rock, Scissors -> Win
    | Paper, Rock -> Win
    | Scissors, Paper -> Win
    | x, y -> if x = y then Draw else Loss

let private scorePlay (_, player) =
    match player with
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

let private scoreResult x =
    match x with
    | Win -> 6
    | Draw -> 3
    | Loss -> 0

let chooseResponse round =
    match round with
    | x, Draw -> x
    | Rock, Win -> Paper
    | Paper, Win -> Scissors
    | Scissors, Win -> Rock
    | Rock, Loss -> Scissors
    | Paper, Loss -> Rock
    | Scissors, Loss -> Paper

let private parseStrategy strategy =
    strategy |> split "\n" |> List.map (split " ")

let private scoreRound round =
    (calculateResult round |> scoreResult) + (scorePlay round)

let scoreRounds (rounds: (Play * Play) list) =
    List.fold (fun acc round -> acc + scoreRound round) 0 rounds

let readAssumedStrategy fileName =
    fileName
    |> readFile
    |> parseStrategy
    |> List.map parseRound

let playAssumedStrategy fileName =
    fileName |> readAssumedStrategy |> scoreRounds

// let readActualStrategy fileName =
//     fileName |> readFile |> parseStrategy |> mapRounds actualTranslation
//
// let playActualStrategy fileName =
//     fileName |> readActualStrategy |> scoreRounds

module aoc_2022_fsharp.day5.Day5

open System
open FSharpPlus
open aoc_2022_fsharp.Split

let separateStacksAndMoves input = input |> split "\n\n"

let determineNumberOfStacks input =
    input
    |> separateStacksAndMoves
    |> List.head
    |> split "\n"
    |> List.last
    |> String.filter Char.IsDigit
    |> String.length

let parseMove move =
    move
    |> String.filter Char.IsDigit
    |> String.toList
    |> List.map string
    |> List.map int

let parseMoves moves =
    moves |> split "\n" |> List.map parseMove

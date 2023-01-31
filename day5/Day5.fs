module aoc_2022_fsharp.day5.Day5

open System
open FSharpPlus
open aoc_2022_fsharp.Split

let separateStacksAndMoves (input: string) = input |> split "\n\n"

let numberOfStacks stacks =
    stacks
    |> separateStacksAndMoves
    |> List.head
    |> split "\n"
    |> List.last
    |> String.filter Char.IsDigit
    |> String.length

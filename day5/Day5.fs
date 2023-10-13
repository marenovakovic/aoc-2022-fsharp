module aoc_2022_fsharp.day5.Day5

open System
open aoc_2022_fsharp.Split

let separateStacksAndMoves s = split "\n\n" s

let determineNumberOfStacks stacks =
    stacks |> split "\n" |> List.last |> String.filter Char.IsDigit |> String.length

let private removeLast list =
    list |> List.rev |> List.skip 1 |> List.rev

let extractStackNames s = s |> split "\n" |> removeLast

module aoc_2022_fsharp.day3.Day3

open System
open FSharpPlus
open aoc_2022_fsharp.Split
open aoc_2022_fsharp.ReadFile

let parseRucksack (items: string) =
    let length = String.length items
    let half = length / 2
    items[0 .. half - 1], items[half..length]

let findCommonItem (rucksack: string * string) =
    let firstHalf = fst rucksack |> Seq.toList
    let secondHalf = snd rucksack |> Seq.toList
    let intersection = Set.intersect (Set.ofList firstHalf) (Set.ofList secondHalf)
    Set.fold (fun x acc -> acc :: x) [] intersection

let priority c =
    match c with
    | c when Char.IsLower c -> int c - 96
    | c -> int c - 65 + 27

let commonItem (group: string list) =
    group
    |> List.map String.toList
    |> List.map Set.ofList
    |> Set.intersectMany
    |> Set.toList
    |> String.ofList

let splitIntoGroups (lines: string list) =
    let groupCount = (List.length lines) / 3
    List.splitInto groupCount lines

let prioritizeLine line =
    line |> String.toList |> List.map priority |> List.sum

let prioritizeGroups groups = groups |> commonItem |> prioritizeLine

let private prioritizeLines lines =
    lines
    |> List.map parseRucksack
    |> List.map findCommonItem
    |> List.map String.ofList
    |> List.map prioritizeLine
    |> List.sum

let private readRucksacks fileName = readFile fileName |> split "\n"

let readTestLines = "day3/test_input.txt" |> readRucksacks

let private readActualLines = "day3/input.txt" |> readRucksacks

let prioritizeTestLines = readTestLines |> prioritizeLines

let prioritizeActualLines = readActualLines |> prioritizeLines

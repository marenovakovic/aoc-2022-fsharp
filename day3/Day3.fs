module aoc_2022_fsharp.day3.Day3

open System
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

let prioritizeLine line = List.map priority line |> List.sum

let private readRucksacks fileName = readFile fileName |> split "\n"

let prioritizeTestLine fileName =
    fileName
    |> readRucksacks
    |> List.map parseRucksack
    |> List.map findCommonItem
    |> List.map prioritizeLine
    |> List.sum

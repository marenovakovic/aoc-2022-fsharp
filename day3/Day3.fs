module aoc_2022_fsharp.day3.Day3

open System

let parseRucksack (items: string) =
    let length = String.length items
    let half = length / 2
    items[0 .. half - 1], items[half..length]

let findCommonItem rucksack =
    let firstHalf = fst rucksack |> Seq.toList
    let secondHalf = snd rucksack |> Seq.toList
    Set.intersect (Set.ofList firstHalf) (Set.ofList secondHalf)

let priority c =
    match c with
    | c when Char.IsLower c ->  int c - 96
    | c -> int c - 65 + 27

let prioritizeLine line =
    List.map priority line |> List.sum

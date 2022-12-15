module aoc_2022_fsharp.day3.Day3

let parseRucksack (items: string) =
    let length = String.length items
    let half = length / 2
    items[0 .. half - 1], items[half..length]

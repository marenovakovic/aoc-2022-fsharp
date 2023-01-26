module aoc_2022_fsharp.day4.Day4

open aoc_2022_fsharp.Split

let rangeToSections range =
    let split = range |> split "-" |> List.map string |> List.map int
    [ split[0] .. split[1] ]

module aoc_2022_fsharp.day4.Day4

open aoc_2022_fsharp.ReadFile
open aoc_2022_fsharp.Split

let rangeToSections range =
    let split = range |> split "-" |> List.map string |> List.map int
    [ split[0] .. split[1] ]

let lineToAssignment line =
    line |> split "," |> List.map rangeToSections

let pairAssignments lines =
    lines |> split "\n" |> List.map lineToAssignment

let findOverlap (assignments: int list list) =
    let first = assignments[0]
    let second = assignments[1]

    Set.intersect (Set.ofList first) (Set.ofList second) |> Set.toList

let isFullOverlap (assignments: int list list) =
    let overlap = findOverlap assignments
    assignments |> List.exists (fun x -> x.Length = overlap.Length)

let overlaps (assignments: int list list) =
    assignments |> findOverlap |> List.isEmpty |> not

let countFullOverlaps fileName =
    fileName
    |> readFile
    |> pairAssignments
    |> List.filter isFullOverlap
    |> List.length

let countOverlaps fileName =
    fileName
    |> readFile
    |> pairAssignments
    |> List.filter overlaps
    |> List.length
module aoc_2022_fsharp.day2.Day2Test

open NUnit.Framework
open FsUnit
open aoc_2022_fsharp.day2.Day2

[<Test>]
let ``should parses input`` () =
    "day2/test_input.txt"
    |> readStrategy
    |> parseStrategy
    |> should equal [ (Rock, Paper); (Paper, Rock); (Scissors, Scissors) ]

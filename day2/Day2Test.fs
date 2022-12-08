module aoc_2022_fsharp.day2.Day2Test

open NUnit.Framework
open FsUnit
open aoc_2022_fsharp.day2.Day2

[<Test>]
let ``should parses input`` () =
    "day2/test_input.txt"
    |> readStrategy
    |> should equal [ (Rock, Paper); (Paper, Rock); (Scissors, Scissors) ]

[<Test>]
let ``should score rock paper`` () =
    [ (Rock, Paper) ] |> scoreStrategy |> should equal 8

[<Test>]
let ``should score rock rock`` () =
    [ (Rock, Rock) ] |> scoreStrategy |> should equal 4

[<Test>]
let ``should score rock scissors`` () =
    [ (Rock, Scissors) ] |> scoreStrategy |> should equal 3

[<Test>]
let ``should score paper scissors`` () =
    [ (Paper, Scissors) ] |> scoreStrategy |> should equal 9

[<Test>]
let ``should score two turns`` () =
    [ (Rock, Paper); (Paper, Scissors) ] |> scoreStrategy |> should equal 17

[<Test>]
let ``should score test game`` () =
    "day2/test_input.txt" |> readStrategy |> scoreStrategy |> should equal 15

[<Test>]
let ``should score actual game (part one)`` () =
    "day2/input.txt" |> readStrategy |> scoreStrategy |> should equal 12458

module aoc_2022_fsharp.day2.Day2Test

open NUnit.Framework
open FsUnit
open aoc_2022_fsharp.day2.Day2

[<Test>]
let ``parses input`` () =
    "day2/test_input.txt"
    |> readAssumedStrategy
    |> should equal [ (Rock, Paper); (Paper, Rock); (Scissors, Scissors) ]

[<Test>]
let ``score Rock Raper`` () =
    [ (Rock, Paper) ] |> scoreStrategy |> should equal 8

[<Test>]
let ``score Rock Rock`` () =
    [ (Rock, Rock) ] |> scoreStrategy |> should equal 4

[<Test>]
let ``score Rock Scissors`` () =
    [ (Rock, Scissors) ] |> scoreStrategy |> should equal 3

[<Test>]
let ``score Paper Scissors`` () =
    [ (Paper, Scissors) ] |> scoreStrategy |> should equal 9

[<Test>]
let ``score two turns`` () =
    [ (Rock, Paper); (Paper, Scissors) ] |> scoreStrategy |> should equal 17

[<Test>]
let ``score assumed test game`` () =
    "day2/test_input.txt" |> playAssumedStrategy |> should equal 15

[<Test>]
let ``score assumed game (part one)`` () =
    "day2/input.txt" |> playAssumedStrategy |> should equal 12458

[<Test>]
let ``choose Paper for Rock Win`` () =
    chooseResponse (Rock, Win) |> should equal Paper

[<Test>]
let ``choose Rock for Rock Draw`` () =
    chooseResponse (Rock, Draw) |> should equal Rock

[<Test>]
let ``choose Scissors for Rock Lose`` () =
    chooseResponse (Rock, Lose) |> should equal Scissors

[<Test>]
let ``choose Rock for Paper Lose`` () =
    chooseResponse (Paper, Lose) |> should equal Rock

[<Test>]
let ``score actual test game`` () =
    "day2/test_input.txt" |> readActualStrategy |> scoreStrategy |> should equal 12

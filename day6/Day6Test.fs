module aoc_2022_fsharp.day6.Day6Test

open aoc_2022_fsharp.ReadFile
open Day6
open NUnit.Framework
open FsUnit
open aoc_2022_fsharp

[<Test>]
let ``find marker position for four different characters`` () =
    "abcd" |> findMarkerPosition |> should equal 4

[<Test>]
let ``find marker position for five characters first two of which are the same`` () =
    "aabcd" |> findMarkerPosition |> should equal 5

[<Test>]
let ``find marker position for six characters first two of which are the same`` () =
    "aabcde" |> findMarkerPosition |> should equal 5

[<Test>]
let ``find marker position for seven characters first two of which are the same`` () =
    "aabcdef" |> findMarkerPosition |> should equal 5

[<Test>]
let ``find marker position for eight characters first four of which are the same`` () =
    "aaaabcde" |> findMarkerPosition |> should equal 7

[<Test>]
let ``part one test input`` () =
    "day6/test_input.txt" |> readFile |> findMarkerPosition |> should equal 7

[<Test>]
let ``part one real input`` () =
    "day6/input.txt" |> readFile |> findMarkerPosition |> should equal 1598

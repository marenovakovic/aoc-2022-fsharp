module aoc_2022_fsharp.day6.Day6Test

open aoc_2022_fsharp.ReadFile
open Day6
open NUnit.Framework
open FsUnit
open aoc_2022_fsharp

[<Test>]
let ``find marker position for four different characters`` () =
    "abcd" |> findPacketMarkerPosition |> should equal 4

[<Test>]
let ``find marker position for five characters first two of which are the same`` () =
    "aabcd" |> findPacketMarkerPosition |> should equal 5

[<Test>]
let ``find marker position for six characters first two of which are the same`` () =
    "aabcde" |> findPacketMarkerPosition |> should equal 5

[<Test>]
let ``find marker position for seven characters first two of which are the same`` () =
    "aabcdef" |> findPacketMarkerPosition |> should equal 5

[<Test>]
let ``find marker position for eight characters first four of which are the same`` () =
    "aaaabcde" |> findPacketMarkerPosition |> should equal 7

[<Test>]
let ``part one test input`` () =
    "day6/test_input.txt" |> readFile |> findPacketMarkerPosition |> should equal 7

[<Test>]
let ``part one real input`` () =
    "day6/input.txt" |> readFile |> findPacketMarkerPosition |> should equal 1598

[<Test>]
let ``part two test input`` () =
    "day6/test_input.txt"
    |> readFile
    |> findMessageMarkerPosition
    |> should equal 19

[<Test>]
let ``part two real input`` () =
    "day6/input.txt" |> readFile |> findMessageMarkerPosition |> should equal 2414

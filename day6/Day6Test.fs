module aoc_2022_fsharp.day6.Day6Test

open aoc_2022_fsharp.ReadFile
open Day6
open NUnit.Framework
open FsUnit

[<Test>]
let ``find packet marker start for four different characters`` () =
    "abcd" |> findPacketStart |> should equal 4

[<Test>]
let ``find packet marker start for five characters first two of which are the same`` () =
    "aabcd" |> findPacketStart |> should equal 5

[<Test>]
let ``find packet marker start for six characters first two of which are the same`` () =
    "aabcde" |> findPacketStart |> should equal 5

[<Test>]
let ``find packet marker start for seven characters first two of which are the same`` () =
    "aabcdef" |> findPacketStart |> should equal 5

[<Test>]
let ``find packet marker start for eight characters first four of which are the same`` () =
    "aaaabcde" |> findPacketStart |> should equal 7

[<Test>]
let ``part one test input`` () =
    "day6/test_input.txt" |> readFile |> findPacketStart |> should equal 7

[<Test>]
let ``part one real input`` () =
    "day6/input.txt" |> readFile |> findPacketStart |> should equal 1598

[<Test>]
let ``part two test input`` () =
    "day6/test_input.txt" |> readFile |> findMessageStart |> should equal 19

[<Test>]
let ``part two real input`` () =
    "day6/input.txt" |> readFile |> findMessageStart |> should equal 2414

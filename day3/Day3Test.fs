module aoc_2022_fsharp.day3.Day3Test

open NUnit.Framework
open FsUnit
open Day3

[<Test>]
let ``parse two chars`` () =
    "ab" |> parseRucksack |> should equal ("a", "b")

[<Test>]
let ``parse four chars`` () =
    "abcd" |> parseRucksack |> should equal ("ab", "cd")

[<Test>]
let ``find common item`` () =
    "abac" |> parseRucksack |> findCommonItem |> should equal "a"
    "abbc" |> parseRucksack |> findCommonItem |> should equal "b"
    "acbc" |> parseRucksack |> findCommonItem |> should equal "c"

[<Test>]
let ``item priority`` () =
    priority 'a' |> should equal 1
    priority 'A' |> should equal 27
    priority 'z' |> should equal 26
    priority 'Z' |> should equal 52

[<Test>]
let ``line priority`` () =
    prioritizeLine [ 'a'; 'b' ] |> should equal 3
    prioritizeLine [ 'a'; 'b'; 'c' ] |> should equal 6
    prioritizeLine [ 'a'; 'Z' ] |> should equal 53

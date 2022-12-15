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
let priority () =
    getPriority 'a' |> should equal 1
    getPriority 'A' |> should equal 27
    getPriority 'z' |> should equal 26
    getPriority 'Z' |> should equal 52

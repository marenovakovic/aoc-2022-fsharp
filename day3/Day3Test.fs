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

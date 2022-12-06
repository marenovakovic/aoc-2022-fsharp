module aoc_2022_fsharp.day1.Day1Test

open NUnit.Framework
open FsUnit
open aoc_2022_fsharp.day1.partOne

[<Test>]
let rec ``part one`` () =
    "1000" |> partOne |> should equal 1000

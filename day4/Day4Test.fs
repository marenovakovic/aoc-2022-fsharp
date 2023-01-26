module aoc_2022_fsharp.day4.Day4Test

open NUnit.Framework
open FsUnit
open Day4

[<Test>]
let ``creates section set from range`` () =
    "2-4" |> rangeToSections |> should equal [ 2; 3; 4 ]

[<Test>]
let ``creates pair assignment from line`` () =
    "2-4,4-6" |> lineToAssignment |> should equal [[2; 3; 4]; [4; 5; 6]]

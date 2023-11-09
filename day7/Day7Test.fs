module aoc_2022_fsharp.day7.Day7Test

open NUnit.Framework
open FsUnit
open Day7

[<Test>]
let ``parse line`` () =
    "$ cd /" |> parseLine |> should equal (EnterDirectory "/")
    "$ cd .." |> parseLine |> should equal GoToParentDirectory
    "$ ls" |> parseLine |> should equal ListFiles
    "dir a" |> parseLine |> should equal (Directory "a")
    "123 a" |> parseLine |> should equal (File(123, "a"))

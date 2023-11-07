module aoc_2022_fsharp.day7.Day7Test

open NUnit.Framework
open FsUnit
open Day7

[<Test>]
let ``parse line`` () =
    "$ cd /" |> parseLine |> should equal (TerminalLine.Command "cd")
    "$ ls" |> parseLine |> should equal (TerminalLine.Command "ls")
    "dir a" |> parseLine |> should equal (TerminalLine.Directory "a")
    "123 a" |> parseLine |> should equal (TerminalLine.File(123, "a"))

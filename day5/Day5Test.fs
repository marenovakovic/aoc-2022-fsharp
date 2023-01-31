module aoc_2022_fsharp.day5.Day5Test

open NUnit.Framework
open FsUnit
open Day5

[<Test>]
let ``splits stack diagram and moving instructions`` () =
    """[A] [B]
 1   2

move 1 from 2 to 1"""
    |> separateStacksAndMoves
    |> should
        equal
        [ """[A] [B]
 1   2"""
          """move 1 from 2 to 1""" ]

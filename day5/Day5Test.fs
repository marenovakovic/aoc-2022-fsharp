module aoc_2022_fsharp.day5.Day5Test

open NUnit.Framework
open FsUnit
open Day5

[<Test>]
let ``split diagram and moves`` () =
    """[A] [B]
 1   2

move 1 from 2 to 1"""
    |> separateStacksAndMoves
    |> should
        equal
        [ """[A] [B]
 1   2"""
          """move 1 from 2 to 1""" ]

[<Test>]
let ``determines number of stack by counting last line`` () =
    determineNumberOfStacks
        """[A] [B] [C]
 1   2   3"""
    |> should equal 3

[<Test>]
let ``extracts stack names`` () =
    extractStackNames
        """    [A]      
[B] [C] [D]
 1   2   3"""
    |> should equal [ [ " "; "A"; " " ]; [ "B"; "C"; "D" ] ]

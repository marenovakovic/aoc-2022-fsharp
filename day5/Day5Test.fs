module aoc_2022_fsharp.day5.Day5Test

open NUnit.Framework
open FsUnit
open Day5
open FSharpPlus

[<Test>]
let ``splits stack diagram and moving instructions`` () =
    """
[A] [B]
 1   2

move 1 from 2 to 1"""
    |> separateStacksAndMoves
    |> should
        equal
        [ """
[A] [B]
 1   2"""
          """move 1 from 2 to 1""" ]

[<Test>]
let ``get number of stacks from last line of the diagram`` () =
    """
[A] [B] [C]
 1   2   3

move 1 from 2 to 1"""
    |> determineNumberOfStacks
    |> should equal 3

[<Test>]
let ``parse move`` () =
    "move 1 from 2 to 1" |> parseMove |> should equal [ 1; 2; 1 ]

[<Test>]
let ``parse moves`` () =
    """
    move 1 from 2 to 3
    move 3 from 2 to 1
    """
    |> String.trimWhiteSpaces
    |> parseMoves
    |> should equal [ [ 1; 2; 3 ]; [ 3; 2; 1 ] ]

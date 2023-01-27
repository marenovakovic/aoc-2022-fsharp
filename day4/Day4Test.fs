module aoc_2022_fsharp.day4.Day4Test

open NUnit.Framework
open FsUnit
open Day4

[<Test>]
let ``creates section set from range`` () =
    "2-4" |> rangeToSections |> should equal [ 2; 3; 4 ]

[<Test>]
let ``creates pair assignment from line`` () =
    "2-4,4-6" |> lineToAssignment |> should equal [ [ 2; 3; 4 ]; [ 4; 5; 6 ] ]

[<Test>]
let ``creates list of pair assignments`` () =
    "2-4,4-6\n3-5,6-8"
    |> pairAssignments
    |> should equal [ [ [ 2; 3; 4 ]; [ 4; 5; 6 ] ]; [ [ 3; 4; 5 ]; [ 6; 7; 8 ] ] ]

[<Test>]
let ``find single assignment overlap`` () =
    [ [ 2; 3; 4 ]; [ 4; 5; 6 ] ] |> findOverlap |> should equal [ 4 ]

[<Test>]
let ``find multiple assignment overlaps`` () =
    [ [ 2; 3; 4 ]; [ 3; 4; 5 ] ] |> findOverlap |> should equal [ 3; 4 ]

[<Test>]
let ``full overlap`` () =
    [ [ 2; 3; 4 ]; [ 2; 3; 4 ] ] |> isFullOverlap |> should equal true
    [ [ 2; 3; 4 ]; [ 1; 2; 3; 4; 5; 6; 7 ] ] |> isFullOverlap |> should equal true
    [ [ 1; 2; 3; 4; 5; 6; 7 ]; [ 2; 3; 4 ] ] |> isFullOverlap |> should equal true

[<Test>]
let ``solves test input part one`` () =
    "day4/test_input.txt" |> countFullOverlaps |> should equal 2

[<Test>]
let ``solve actual input part one`` () =
    "day4/input.txt" |> countFullOverlaps |> should equal 657

[<Test>]
let ``any overlap`` () =
    [ [ 2; 3; 4 ]; [ 4; 5; 6 ] ] |> overlaps |> should equal true
    [ [ 2; 3; 4; 5 ]; [ 4; 5; 6; 7; 8 ] ] |> overlaps |> should equal true
    [ [ 2; 3; 4 ]; [ 5; 6; 7 ] ] |> overlaps |> should equal false

[<Test>]
let ``solve test input part two`` () =
    "day4/test_input.txt" |> countOverlaps |> should equal 4
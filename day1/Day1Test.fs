module aoc_2022_fsharp.day1.Day1Test

open NUnit.Framework
open FsUnit
open aoc_2022_fsharp.day1.Day1
open aoc_2022_fsharp.ReadFile

[<Test>]
let ``part one`` () =
    "1000" |> findMaxCalories |> should equal 1000
    "2000" |> findMaxCalories |> should equal 2000
    "2000\n\n1000" |> findMaxCalories |> should equal 2000
    "1000\n\n2000" |> findMaxCalories |> should equal 2000
    "1000\n2000\n\n2000" |> findMaxCalories |> should equal 3000
    "1000\n2000\n\n4000" |> findMaxCalories |> should equal 4000
    "day1/test_input.txt" |> readFile |> findMaxCalories |> should equal 24000

[<Test>]
let ``part two`` () =
    "1000\n\n1000\n\n1000" |> findMaxCaloriesForTopThreeElves |> should equal 3000
    "1000\n\n1000\n\n2000" |> findMaxCaloriesForTopThreeElves |> should equal 4000
    "1000\n\n1000\n\n2000\n\n500" |> findMaxCaloriesForTopThreeElves |> should equal 4000
    "1000\n\n1000\n\n2000\n\n500\n\n2000" |> findMaxCaloriesForTopThreeElves |> should equal 5000
    "day1/test_input.txt" |> readFile |> findMaxCaloriesForTopThreeElves |> should equal 45000

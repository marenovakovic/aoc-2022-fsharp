open aoc_2022_fsharp.ReadFile
open aoc_2022_fsharp.day1.Day1

"day1/input.txt"
|> readFile
|> findMaxCaloriesForTopThreeElves
|> System.Console.Write

module aoc_2022_fsharp.day1.Day1

open aoc_2022_fsharp.Split

let separateElfCalories (input: string) = split "\n\n" input |> Seq.ofList

let private splitElfCalories (calories: seq<string>) = calories |> Seq.map (split "\n")

let private sumCaloriesPerElf caloriesList =
    caloriesList
    |> Seq.map (fun calories -> calories |> Seq.map int)
    |> Seq.map Seq.sum

let private calculateCaloriesPerElf (input: string) =
    input |> separateElfCalories |> splitElfCalories |> sumCaloriesPerElf

let findMaxCalories (input: string) =
    input |> calculateCaloriesPerElf |> Seq.max

let findMaxCaloriesForTopThreeElves (input: string) =
    input |> calculateCaloriesPerElf |> Seq.sortDescending |> Seq.take 3 |> Seq.sum

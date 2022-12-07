module aoc_2022_fsharp.day1.Day1

let split (separator: string) (s: string) = s.Split(separator)

let separateElfCalories (input: string) = split "\n\n" input |> Seq.ofArray

let private splitElfCalories (calories: seq<string>) =
    calories |> Seq.map (split "\n")

let private sumCaloriesPerElf caloriesList =
    caloriesList
    |> Seq.map (fun calories -> calories |> Seq.map int)
    |> Seq.map Seq.sum

let private calculateCaloriesPerElf (input: string) =
    input
    |> separateElfCalories
    |> splitElfCalories
    |> sumCaloriesPerElf

let partOne (input: string) =
    input |> calculateCaloriesPerElf |> Seq.max

let partTwo (input: string) =
    input
    |> calculateCaloriesPerElf
    |> Seq.sortDescending
    |> Seq.take 3
    |> Seq.sum

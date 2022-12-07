module aoc_2022_fsharp.day1.partOne

let private splitCaloriesList (calories: seq<string>) =
    calories |> Seq.map (fun s -> s.Split "\n")

let private sumCaloriesPerElf caloriesList =
    caloriesList
    |> Seq.map (fun calories -> calories |> Array.map int)
    |> Seq.map Array.sum

let partOne (input: string) =
    input.Split "\n\n"
    |> Seq.ofArray
    |> splitCaloriesList
    |> sumCaloriesPerElf
    |> Seq.max

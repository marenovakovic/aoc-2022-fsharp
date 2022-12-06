module aoc_2022_fsharp.ReadFile

open System.IO

let readFile fileName =
    File.ReadAllText($"{__SOURCE_DIRECTORY__}/{fileName}")

open aoc_2022_fsharp.ReadFile

"day1/input.txt"
|> readFile
|> Seq.iter (fun x -> printfn $"%s{x}")

module aoc_2022_fsharp.ReadFile

open System.IO

let readFile fileName =
    let basePath =
        "/Users/markonovakovic/Developer/RiderProjects/aoc-2022-fsharp/"

    seq {
        use reader =
            new StreamReader(File.OpenRead($"{basePath}/{fileName}"))

        while not reader.EndOfStream do
            yield reader.ReadLine()
    }

module aoc_2022_fsharp.ReadFile

open System.IO

let readFile fileName =
    seq {
        use reader =
            new StreamReader(File.OpenRead($"{__SOURCE_DIRECTORY__}/{fileName}"))

        while not reader.EndOfStream do
            yield reader.ReadLine()
    }

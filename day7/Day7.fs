module aoc_2022_fsharp.day7.Day7

open FSharpPlus
open System
open aoc_2022_fsharp.Split

type TerminalLine =
    | Command of command: string
    | Directory of name: string
    | File of size: int * name: string

let private determineLine =
    function
    | "$" :: rest -> Command(rest |> List.head)
    | "dir" :: [ name ] -> Directory name
    | size :: [ name ] -> File(int size, name)
    | _ -> raise (Exception())

let parseLine = split " " >> determineLine

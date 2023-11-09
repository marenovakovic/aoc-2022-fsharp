module aoc_2022_fsharp.day7.Day7

open FSharpPlus
open System
open aoc_2022_fsharp.Split

type TerminalLine =
    | EnterDirectory of directory: string
    | ListFiles
    | Directory of name: string
    | File of size: int * name: string

let private determineLine =
    function
    | "$" :: "cd" :: rest -> EnterDirectory(rest |> List.head)
    | [ "$"; "ls" ] -> ListFiles
    | "dir" :: [ name ] -> Directory name
    | size :: [ name ] -> File(int size, name)
    | _ -> raise (Exception())

let parseLine = split " " >> determineLine

module aoc_2022_fsharp.day7.Day7

open System
open aoc_2022_fsharp.Split

type TerminalLine =
    | EnterDirectory of directory: string
    | ListFiles
    | GoToParentDirectory
    | Directory of name: string
    | File of size: int * name: string

let private determineLine =
    function
    | [ "$"; "cd"; ".." ] -> GoToParentDirectory
    | [ "$"; "cd"; directory ] -> EnterDirectory directory
    | [ "$"; "ls" ] -> ListFiles
    | "dir" :: [ name ] -> Directory name
    | size :: [ name ] -> File(int size, name)
    | _ -> raise (Exception())

let parseLine = split " " >> determineLine

let runCommands lines =
    let rec loop structure lines =
        match lines with
        | EnterDirectory directory :: ListFiles :: rest -> loop (Map [ directory, rest ]) rest
        | _ -> structure

    loop (Map []) lines

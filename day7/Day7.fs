module aoc_2022_fsharp.day7.Day7

open System
open aoc_2022_fsharp.Split

type TerminalLine =
    | EnterDirectory of directory: string
    | ListFiles
    | GoToParentDirectory
    | Directory of name: string
    | File of size: int * name: string

let private parseLine' =
    function
    | [ "$"; "cd"; ".." ] -> GoToParentDirectory
    | [ "$"; "cd"; directory ] -> EnterDirectory directory
    | [ "$"; "ls" ] -> ListFiles
    | "dir" :: [ name ] -> Directory name
    | size :: [ name ] -> File(int size, name)
    | _ -> raise (Exception())

let parseLine = split " " >> parseLine'

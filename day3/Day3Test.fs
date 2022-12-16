module aoc_2022_fsharp.day3.Day3Test

open NUnit.Framework
open FsUnit
open Day3

[<Test>]
let ``parse two chars`` () =
    "ab" |> parseRucksack |> should equal ("a", "b")

[<Test>]
let ``parse four chars`` () =
    "abcd" |> parseRucksack |> should equal ("ab", "cd")

[<Test>]
let ``find common item`` () =
    "abac" |> parseRucksack |> findCommonItem |> should equal "a"
    "abbc" |> parseRucksack |> findCommonItem |> should equal "b"
    "acbc" |> parseRucksack |> findCommonItem |> should equal "c"

[<Test>]
let ``item priority`` () =
    priority 'a' |> should equal 1
    priority 'A' |> should equal 27
    priority 'z' |> should equal 26
    priority 'Z' |> should equal 52

[<Test>]
let ``line priority`` () =
    prioritizeLine "ab" |> should equal 3
    prioritizeLine "abc" |> should equal 6
    prioritizeLine "aZ" |> should equal 53

[<Test>]
let ``prioritize test line`` () = prioritizeTestLines |> should equal 157

[<Test>]
let ``prioritize actual line`` () =
    prioritizeActualLines |> should equal 8185

[<Test>]
let ``common item in a group`` () =
    [ "abc"; "ade"; "afg" ] |> commonItem |> should equal "a"

    [ "vJrwpWtwJgWrhcsFMMfFFhFp"
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
      "PmmdzqPrVvPwwTWBwg" ]
    |> commonItem
    |> should equal "r"

    [ "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
      "ttgJtRGJQctTZtZT"
      "CrZsJsPPZsGzwwsLwLmpwMDw" ]
    |> commonItem
    |> should equal "Z"

[<Test>]
let ``split test lines into groups`` () =
    let groups = readTestLines |> splitIntoGroups

    groups |> should haveLength 2

    groups
    |> should
        equal
        [ [ "vJrwpWtwJgWrhcsFMMfFFhFp"
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
            "PmmdzqPrVvPwwTWBwg" ]
          [ "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
            "ttgJtRGJQctTZtZT"
            "CrZsJsPPZsGzwwsLwLmpwMDw" ] ]

[<Test>]
let ``split three line groups`` () =
    let lines =
        [ "vJrwpWtwJgWrhcsFMMfFFhFp"
          "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
          "PmmdzqPrVvPwwTWBwg"
          "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
          "ttgJtRGJQctTZtZT"
          "CrZsJsPPZsGzwwsLwLmpwMDw"
          "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
          "ttgJtRGJQctTZtZT"
          "CrZsJsPPZsGzwwsLwLmpwMDw" ]

    let groups = lines |> splitIntoGroups

    groups |> should haveLength 3

    groups
    |> should
        equal
        [ [ "vJrwpWtwJgWrhcsFMMfFFhFp"
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
            "PmmdzqPrVvPwwTWBwg" ]
          [ "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
            "ttgJtRGJQctTZtZT"
            "CrZsJsPPZsGzwwsLwLmpwMDw" ]
          [ "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
            "ttgJtRGJQctTZtZT"
            "CrZsJsPPZsGzwwsLwLmpwMDw" ] ]

[<Test>]
let ``prioritize test groups`` () = prioritizeTestGroups |> should equal 70

[<Test>]
let ``prioritize actual groups`` () = prioritizeActualGroups |> should equal 2817

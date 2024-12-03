module Program

open System;
open System.IO;

let splitInts xs =
    xs
    |> List.map (fun (s:string) -> s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    |> List.map (fun (ss:string[]) -> ss.[0] |> int, ss.[1] |> int) // this is kind of gross
    |> List.unzip

let sumDistances xs ys = 
    List.fold2 (fun acc e1 e2 -> acc + abs (e1 - e2)) 0 (List.sort xs) (List.sort ys)

let getOccurrance x xs = 
    match List.tryFind (fun e -> fst e = x) xs with
    | Some value -> snd value
    | None -> 0

let sumSimilatrity xs ys = 
    xs
    |> List.fold (fun acc e -> acc + (e * (getOccurrance e ys))) 0


let (result1:int list), (result2:int list) = splitInts (List.ofArray (File.ReadAllLines "input/1"))
printfn "First answer is: %d" (sumDistances result1 result2)
printfn "Second answer is: %d" (sumSimilatrity result1 (result2 |> List.countBy id))

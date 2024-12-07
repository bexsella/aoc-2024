namespace AoC2024
    module public Day1 =
        open System
        open System.IO

        let readInput (inputPath:string) =
            List.ofArray (File.ReadAllLines inputPath)
            |> List.map (fun s -> s.Split(' ', StringSplitOptions.RemoveEmptyEntries) |> Array.map(fun e -> e |> int) |> Array.pairwise |> List.ofArray)
            |> List.concat |> List.unzip

        let sumDistances xs ys = 
            List.fold2 (fun acc e1 e2 -> acc + abs (e1 - e2)) 0 (List.sort xs) (List.sort ys)

        let getOccurrance (x:int) (xs) = 
            match List.tryFind (fun e -> fst e = x) xs with
            | Some value -> snd value
            | None -> 0

        let sumSimilatrity (xs:int list) ys = 
            xs |> List.fold (fun acc e -> acc + (e * (getOccurrance e ys))) 0

        let solve =
            let leftList, rightList = readInput "input/1"
            sumDistances leftList rightList, sumSimilatrity leftList (rightList |> List.countBy id)

namespace AoC2024
    module public Day2 =
        open System
        open System.IO

        type Safety = | None | Inc | Dec

        let diff (xs:int list) = xs |> List.pairwise |> List.map(fun p -> fst p - snd p)

        let readIntLists (inputPath:string) =
            List.ofArray (File.ReadAllLines inputPath)
            |> List.map (fun e -> e.Split(' ', StringSplitOptions.RemoveEmptyEntries) |> Array.map(fun e -> e |> int) |> List.ofArray)

        let safetyPredicate (xs:int list) = xs |> List.forall(fun e -> e > 0 && e <= 3) || xs |> List.forall(fun e -> e < 0 && e >= -3)

        let determineSafety (xs:int list list) = 
            xs
            |> List.map(fun e -> e |> diff)
            |> List.filter safetyPredicate
            |> List.length

        let dampenSafety (xs:int list) =
            match safetyPredicate (diff xs) with
            | true -> true
            | false -> (
                let mutable dampened = []
                for i = 0 to xs.Length - 1 do 
                    dampened <- diff (xs |> List.removeAt i) :: dampened
            
                dampened
                |> List.filter safetyPredicate
                |> List.length > 0)

        let determineSafetyDampen (xs:int list list) = 
            xs
            |> List.filter dampenSafety
            |> List.length

        let solve =
            let nums = readIntLists "input/2"
            (determineSafety nums, determineSafetyDampen nums)

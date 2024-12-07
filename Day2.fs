namespace AoC2024
    module public Day2 =
        open System
        open System.IO

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
            let rec safeTest (xs:int list) (i:int) =
                if i = xs.Length then false
                elif xs |> List.removeAt(i) |> diff |> safetyPredicate then true
                else safeTest xs (i+1)

            safeTest xs 0

        let determineSafetyDampen (xs:int list list) = 
            xs
            |> List.filter (fun e -> safetyPredicate (diff e) || dampenSafety e)
            |> List.length

        let solve =
            let nums = readIntLists "input/2"
            (determineSafety nums, determineSafetyDampen nums)

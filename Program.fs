namespace AoC2024
    module Program =
        let solvedDays = [
            Day1.solve;
            Day2.solve;
            Day3.solve;
        ]

        List.iteri(fun i e -> printfn "Day %d: (%d, %d)" (i + 1) (fst e) (snd e)) solvedDays


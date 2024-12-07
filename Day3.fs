namespace AoC2024
    module Day3 =
        open System
        open System.IO
        open System.Text.RegularExpressions

        let readInput (path:string) = (File.ReadAllText path)

        let pullMuls (s:string) (d:bool)= 
            let pattern = "(mul\((?<left>\d+)\,(?<right>\d+)\))|(do\(\))|(don\'t\(\))"
            let matches = Regex.Matches(s, pattern)
            let mutable muls = []
            let mutable indo = true
            for m in matches do
                if m.Value = "do()" then indo <- true elif m.Value = "don't()" then indo <- false
                elif not d || indo then muls <- (m.Groups["left"].Value |> int, m.Groups["right"].Value |> int) :: muls
            muls

        let mul (xs:(int*int) list) = 
            List.fold(fun acc e -> acc + (fst e * snd e)) 0 xs

        let solve = 
            let input = readInput "input/3"
            (mul (pullMuls input false)), (mul (pullMuls input true))

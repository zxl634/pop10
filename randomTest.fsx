
let g = System.Random(4)           // SAME generator everytime we run this line
                                   // a MUST during development / testing
printfn "%A" (g.Next (1,53)) ;;    // NOT good, ie. BAD (see below line 24)
printfn "%A" (g.Next (1,53)) ;;
printfn "%A" (g.Next (1,53)) ;;

printfn ""

printfn "%A" (System.Random(4).Next (1,53)) ;;  // REALLY BAD !!!
printfn "%A" (System.Random(4).Next (1,53)) ;;
printfn "%A" (System.Random(4).Next (1,53)) ;;

// Read:  https://msdn.microsoft.com/en-us/library/system.random(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#UniqueArray

let spilKort = 
    [ for k in 1..4 do
          for v in 1..13 do
              yield (k, v) ]
;;
printfn ""
printfn "spilKort = %A" spilKort
printfn "antal før blande = %A" spilKort.Length

let blandeKort kortBunke =   // this is much BETTER than line 2-5 above
    let gen = new System.Random ()   // numbers is taken from range 0 .. 2,147,483,647
    kortBunke 
        |> List.map (fun kort -> (gen.Next (), kort))  // VERY small chance for duplicates
        |> List.sortBy fst |> List.map snd             // but chance is NOT zero !!! 
;;
printfn ""
let blandetSpilKort = (blandeKort spilKort)
printfn "Blandet spilKort = %A" blandetSpilKort
printfn "antal efter blande = %A" blandetSpilKort.Length

let run () =
    let blandetSpilKort = (blandeKort spilKort)
    
    let BF = spilKort |> Set.ofList            // convert to Set
    let BE = blandetSpilKort |> Set.ofList     // Set removes duplicates

    if BF.Count <> BE.Count then printfn " DUP "
    // else printf "."  // DO NOT activate this line, as printf is VERY slow
;;
printfn ""
printfn "Running... many, many times ... checking for duplicates, every time..."
for _ in 1..100000 do run ()

// end
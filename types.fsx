// https://fsharpforfunandprofit.com/posts/discriminated-unions/

type IntOrBool = I of int | B of bool

let b = I 99
printfn "%A" b

type Face = | Two of int | Three | Four | Five 
            | Six | Seven | Eight | Nine | Ten
            | Jack | Queen | King | Ace

printfn "%A" (Two 99)

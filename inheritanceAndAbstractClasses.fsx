//https://fsharpforfunandprofit.com/posts/inheritance/
type BaseClass(param1) =
   member this.Param1 = param1

type DerivedClass(param1, param2) =
   inherit BaseClass(param1)
   member this.Param2 = param2

// test
let derived = new DerivedClass(1,2)
printfn "param1=%O" derived.Param1
printfn "param2=%O" derived.Param2


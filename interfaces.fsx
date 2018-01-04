// https://fsharpforfunandprofit.com/posts/interfaces/
type MyInterface =
   // abstract method
   abstract member Add: int -> int -> int

   // abstract immutable property
   abstract member Pi : float 

   // abstract read/write property
   abstract member Area : float with get,set

[<AbstractClass>]
type AbstractBaseClass() =
   // abstract method
   abstract member Add: int -> int -> int

   // abstract immutable property
   abstract member Pi : float 

   // abstract read/write property
   abstract member Area : float with get,set

type IAddingService =
    abstract member Add: int -> int -> int

type MyAddingService() =
    interface IAddingService with 
        member this.Add x y = 
            x + y
    interface System.IDisposable with 
        member this.Dispose() = 
            printfn "disposed"

let mas = new MyAddingService()
let adder = mas :> IAddingService
printfn "%i" (adder.Add 1 2)

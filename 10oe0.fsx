type Counter () =
  let mutable c = 0
  member this.get () : int = c
  member this.incr () =
    c <- c + 1
  member this.reset () =
    c <- 0

let counter = Counter ()

printfn "Tester Counter-klassen"
printfn "Tjekker, om startværdien er 0: %b" (counter.get () = 0)

counter.incr ()
printfn "Tjekker, om værdien er 1 efter en gang .incr (): %b" (counter.get () = 1)

counter.reset ()
printfn "Tjekker, at værdien er 0 efter reset: %b" (counter.get () = 0)


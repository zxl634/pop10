(*
  Anders V. Riis
  10g.0
*)
open Cards
open simpleJack
let table = Table (2)
printfn "%A" table
//table.turn ()
(*
//
let player = Player ()

let hand = player.getHand ()

printfn "%A" (hand)
printfn "Værdien af hånden er: %d" (player.getValueOfHand()) 
printfn "Status: %A" (player.getPlayerStatus ())

// Spørg, om der skal tilføjes et kort
let userInteraction =
  System.Console.Write "Hit [h] or stand [s]? "
  let answer = System.Console.ReadLine ()
  if answer = "h" then
    player.addCard ()
    printfn "Hånd efter nyt kort er tilføjet: %A" (player.getHand ())
    printfn "Status: %A" (player.getPlayerStatus ())

userInteraction

// Tilføjer nyt kort
*)

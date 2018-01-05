(*
    10g
    Anders V. Riis
    This file tests the functions etc.
 *)

open Cards
open simpleJack

// Tester diverse fra cards.fs
let deck = new DeckCls ()
// Tester, om antallet af kort er 52
printfn "%b" (deck.getDeckSize() = 52)
// Tester, om det er typen kort, der trækkes
let card = deck.drawCardFromDeck()
printfn "%A" (card.GetType() = typeof<Card>)
// Tester, om antallet af kort er 51 efter et kort er trukket
printfn "%b" (deck.getDeckSize() = 51)
// Tester, om createDeck laver et objekt af typen Deck
printfn "%b" (createDeck.GetType() = typeof<Deck>)
// Tester, om udregningen af kortværdien er korrekt
let card2 = {Face = Some Two; Suit = Some Clubs}
printfn "%b" (getCardValue card2 = 2)
let card3 = {Face = Some King; Suit = Some Diamonds}
printfn "%b" (getCardValue card3 = 10)
// Tester, om funktion handContainsAce er korrekt
let card4 = {Face = Some Ace; Suit = Some Diamonds}
let hand = [card4;card3]
printfn "%b" (handContainsAce hand = true)
let hand2 = [card3;deck.drawCardFromDeck()]
printfn "%b" (handContainsAce hand2 = false)

// Tester player-klassen
let player = new Player(hand,true)
let player2 = new Player(hand,false)
// Test AI-parameter
printfn "%b" (player.AI() = true)
printfn "%b" (player2.AI() = false)
// Test AIstring
printfn "%b" (player.AIstring() = " (AI)")
printfn "%b" (player2.AIstring() = " (human)")
// Test addCard, dvs. er der tre kort nu?
player.addCard(card2)
let newHand = player.getHand()
printfn "%b" (newHand.Length = 3)
// Test getValueOfHand
// Værdien skal være 13, da vi har en konge (10), en toer (2) og et es (1/11). Da værdien ville være over 21, hvis esset talte som 11, tæller det som 1
printfn "%b" (player.getValueOfHand() = 13) 



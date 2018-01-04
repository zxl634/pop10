module Sandbox
type Suit =
  | Spades
  | Clubs
  | Diamonds
  | Hearts
type Face =
  | Two
  | Three
  | Four
  | Five
  | Six
  | Seven
  | Eight
  | Nine
  | Ten
  | Jack
  | Queen
  | King
  | Ace
type Card =
  {Face: Face;
   Suit: Suit;}
type Deck = Card list
type Hand = Card list
type Score = | Score of int
val cards : Card list
val cases : Reflection.UnionCaseInfo []


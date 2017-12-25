module Cards
val fromString : s:string -> 'a option
type Suit =
  | Spades
  | Clubs
  | Diamonds
  | Hearts
  with
    static member fromString : s:string -> Suit option
  end
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
  with
    static member fromString : s:string -> Face option
  end
type Card =
  {Face: Face option;
   Suit: Suit option;}
type Deck = Card list
type Hand = Card list
type Score = | Score of int
val generateRandomNumber : l:int -> int
val drawCase : cases:Reflection.UnionCaseInfo [] -> Reflection.UnionCaseInfo
val drawCard : Card
val getName : x:Reflection.UnionCaseInfo -> string
val constructCard : face:Face option -> suit:Suit option -> Card
val drawFace : Face option
val drawSuit : Suit option
val drawCard2 : Card
val getCardValue : card:Card -> int


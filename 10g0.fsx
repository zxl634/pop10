(*
  Anders V. Riis
  10g.0
*)

type Suit = | Spades | Clubs | Diamonds | Hearts
 
type Face = | Two | Three | Four | Five 
            | Six | Seven | Eight | Nine | Ten
            | Jack | Queen | King | Ace

type FaceEnum = | Two = 2 | Three = 3 | Four = 4 
                | Five = 5 | Six = 6 | Seven = 7
                | Eight = 8 | Nine = 9 | Ten = 10
                | Jack = 10 | Queen = 10 | King = 10
                | Ace = 1

// This is a record
type Card = {Face:Face; Suit:Suit}
type Deck = Card list
type Hand = Card list
type Score = Score of int

(*
type Status = SimpleJack | Bust of Score | Stand of Score | CardsDealt 

type Dealer = {Hand:Hand; Status:Status}

type Player = {Hand:Hand; Status:Status; Id:int}
type Players = Player list
type Game = {Deck:Deck; Dealer:Dealer; Players;Players}
type Points = Hard of int | Soft of int*int
type Actions = Hit | Stand
*)

(*
let drawCard deck =
  match deck with
  | [] -> None
  | topCard :: restOfDeck -> Some (topCard,restOfDeck)
*)

(*
let setupPlayer drawCard id deck =
  match drawCard deck with
  | None -> None
  | Some(firstCard, deck) ->
    match drawCard deck with
    | None -> None
    | Some(secondCard, deck) ->
      let hand = [firstCard; secondCard]
      Some ({Hand=hand; Id=id; Status=CardsDealt},deck)
*)

//let card = { Face = Two; Suit = Clubs }
//printfn "%A" card

(*
let calculateCardValue face =
  match face with
  | Jack | Queen | King -> 10
  | Ace -> 1
  | Two -> 2
  | Three -> 3
  | Four ->
*)

//let c = k

//type Card = 


type cardValue =
  {
    Royalty : int
    Ace : int
    Numbers : int
  }

(*
type Participant() =
  abstract member numberOfCards : int 
  abstract member valueOfCards : int
  abstract member addCard : int -> int
  //abstract member removeCard : int -> int
  //abstract member addCardValue : int -> int
  // defaults
  default this.numberOfCards = 2
  default this.valueOfCards = 0
  default this.addCard = numberOfCards + 1
  //default this.removeCard = numberOfCards - 1
  //default this.addCardValue value = valueOfCards + value
*)

type Player () =
  let mutable numberOfCards = 2
  member this.getNumberOfCards = numberOfCards
  member this.addCard () =
    numberOfCards <- numberOfCards + 1
  //member this.Cards () =
 // inherit Participant()

//type Dealer () =
//  inherit Participant()

type Table (numberOfPlayers : int) =
  /// Define number of players
  let numberOfPlayers = numberOfPlayers
  /// Print welcome at construction time
  let printWelcome() =
    do printfn "Welcome to this game of Simple Jack with %i players including the dealer." numberOfPlayers
  do printWelcome()

  /// Instantiate participants
  let player = new Player()
  //let dealer = new Dealer()

  /// Function to draw cards
  member this.drawCard (52) =
    let gen = System.Random()
    let cardNumber = gen.Next(1,52)
    cardNumber
  
  /// Print table
  override this.ToString() = 
    let mutable str = "\nThe players have the following cards:"
    for i in 1 .. numberOfPlayers do
      let mutable participant = ""
      match i with
      | 1 ->
          participant <- "dealer"
      | _ -> 
          participant <- "player " + string (i-1)
      str <- str + sprintf "\n  Cards of " + participant + ":"
      /// Insert cards here
      str <- str + string player.getNumberOfCards
    str
  member this.turn (numberOfPlayers : int) =
    /// In a turn all players that are AI should be ...
    1

let table = Table (3)
printfn "%A" table


 

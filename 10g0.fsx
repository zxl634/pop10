(*
  Anders V. Riis
  10g.0
*)

open Cards

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
  //member this.getCards () = cards

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



 
